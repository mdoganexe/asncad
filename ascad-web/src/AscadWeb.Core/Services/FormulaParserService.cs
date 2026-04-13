using System.Globalization;
using AscadWeb.Core.Exceptions;
using AscadWeb.Core.Interfaces;
using AscadWeb.Core.Models;

namespace AscadWeb.Core.Services;

public class FormulaParserService : IFormulaParser
{
    // ── Token types ──────────────────────────────────────────────
    private enum TokenType
    {
        Number,
        Identifier,
        Plus,
        Minus,
        Star,
        Slash,
        LeftParen,
        RightParen,
        Comma,
        Greater,
        Less,
        GreaterEqual,
        LessEqual,
        EqualEqual,
        BangEqual,
        If,
        Eof
    }

    private readonly record struct Token(TokenType Type, string Value, int Position);

    // ── Tokenizer ────────────────────────────────────────────────
    private static List<Token> Tokenize(string input)
    {
        var tokens = new List<Token>();
        int i = 0;

        while (i < input.Length)
        {
            char c = input[i];

            // Skip whitespace
            if (char.IsWhiteSpace(c))
            {
                i++;
                continue;
            }

            // Number literal: digits with optional decimal point
            if (char.IsDigit(c) || (c == '.' && i + 1 < input.Length && char.IsDigit(input[i + 1])))
            {
                int start = i;
                while (i < input.Length && char.IsDigit(input[i]))
                    i++;
                if (i < input.Length && input[i] == '.')
                {
                    i++;
                    if (i >= input.Length || !char.IsDigit(input[i]))
                        throw new FormulaParseException(start, "Invalid number literal: trailing decimal point");
                    while (i < input.Length && char.IsDigit(input[i]))
                        i++;
                }
                tokens.Add(new Token(TokenType.Number, input[start..i], start));
                continue;
            }

            // Identifier or 'if' keyword
            if (char.IsLetter(c) || c == '_')
            {
                int start = i;
                while (i < input.Length && (char.IsLetterOrDigit(input[i]) || input[i] == '_'))
                    i++;
                string word = input[start..i];
                var type = word == "if" ? TokenType.If : TokenType.Identifier;
                tokens.Add(new Token(type, word, start));
                continue;
            }

            // Two-character operators
            if (i + 1 < input.Length)
            {
                string two = input.Substring(i, 2);
                switch (two)
                {
                    case ">=":
                        tokens.Add(new Token(TokenType.GreaterEqual, two, i));
                        i += 2;
                        continue;
                    case "<=":
                        tokens.Add(new Token(TokenType.LessEqual, two, i));
                        i += 2;
                        continue;
                    case "==":
                        tokens.Add(new Token(TokenType.EqualEqual, two, i));
                        i += 2;
                        continue;
                    case "!=":
                        tokens.Add(new Token(TokenType.BangEqual, two, i));
                        i += 2;
                        continue;
                }
            }

            // Single-character operators / punctuation
            switch (c)
            {
                case '+':
                    tokens.Add(new Token(TokenType.Plus, "+", i));
                    i++;
                    continue;
                case '-':
                    tokens.Add(new Token(TokenType.Minus, "-", i));
                    i++;
                    continue;
                case '*':
                    tokens.Add(new Token(TokenType.Star, "*", i));
                    i++;
                    continue;
                case '/':
                    tokens.Add(new Token(TokenType.Slash, "/", i));
                    i++;
                    continue;
                case '(':
                    tokens.Add(new Token(TokenType.LeftParen, "(", i));
                    i++;
                    continue;
                case ')':
                    tokens.Add(new Token(TokenType.RightParen, ")", i));
                    i++;
                    continue;
                case ',':
                    tokens.Add(new Token(TokenType.Comma, ",", i));
                    i++;
                    continue;
                case '>':
                    tokens.Add(new Token(TokenType.Greater, ">", i));
                    i++;
                    continue;
                case '<':
                    tokens.Add(new Token(TokenType.Less, "<", i));
                    i++;
                    continue;
            }

            throw new FormulaParseException(i, $"Unexpected character '{c}'");
        }

        tokens.Add(new Token(TokenType.Eof, "", input.Length));
        return tokens;
    }

    // ── Recursive-descent parser ─────────────────────────────────
    private List<Token> _tokens = null!;
    private int _pos;

    private Token Current => _tokens[_pos];

    private Token Advance()
    {
        var token = _tokens[_pos];
        _pos++;
        return token;
    }

    private Token Expect(TokenType type, string expected)
    {
        if (Current.Type != type)
            throw new FormulaParseException(Current.Position,
                $"Expected {expected} but found '{Current.Value}'");
        return Advance();
    }

    // expression → comparison
    private FormulaExpression ParseExpression()
    {
        return ParseComparison();
    }

    // comparison → addition ((">" | "<" | ">=" | "<=" | "==" | "!=") addition)?
    private FormulaExpression ParseComparison()
    {
        var left = ParseAddition();

        if (Current.Type is TokenType.Greater or TokenType.Less
            or TokenType.GreaterEqual or TokenType.LessEqual
            or TokenType.EqualEqual or TokenType.BangEqual)
        {
            var op = Advance();
            var right = ParseAddition();
            return new ComparisonOp(left, op.Value, right);
        }

        return left;
    }

    // addition → multiplication (("+" | "-") multiplication)*
    private FormulaExpression ParseAddition()
    {
        var left = ParseMultiplication();

        while (Current.Type is TokenType.Plus or TokenType.Minus)
        {
            var op = Advance();
            var right = ParseMultiplication();
            left = new BinaryOp(left, op.Value, right);
        }

        return left;
    }

    // multiplication → unary (("*" | "/") unary)*
    private FormulaExpression ParseMultiplication()
    {
        var left = ParseUnary();

        while (Current.Type is TokenType.Star or TokenType.Slash)
        {
            var op = Advance();
            var right = ParseUnary();
            left = new BinaryOp(left, op.Value, right);
        }

        return left;
    }

    // unary → "-" unary | primary
    private FormulaExpression ParseUnary()
    {
        if (Current.Type == TokenType.Minus)
        {
            Advance();
            var operand = ParseUnary();
            // Optimise: -number → NumberLiteral with negative value
            if (operand is NumberLiteral num)
                return new NumberLiteral(-num.Value);
            return new BinaryOp(new NumberLiteral(0), "-", operand);
        }

        return ParsePrimary();
    }

    // primary → NUMBER | IDENTIFIER | "(" expression ")" | "if" "(" expression "," expression "," expression ")"
    private FormulaExpression ParsePrimary()
    {
        switch (Current.Type)
        {
            case TokenType.Number:
            {
                var tok = Advance();
                return new NumberLiteral(double.Parse(tok.Value, CultureInfo.InvariantCulture));
            }

            case TokenType.Identifier:
            {
                var tok = Advance();
                return new ParameterRef(tok.Value);
            }

            case TokenType.LeftParen:
            {
                Advance(); // consume '('
                var expr = ParseExpression();
                Expect(TokenType.RightParen, "')'");
                return expr;
            }

            case TokenType.If:
            {
                Advance(); // consume 'if'
                Expect(TokenType.LeftParen, "'('");
                var condition = ParseExpression();
                Expect(TokenType.Comma, "','");
                var thenExpr = ParseExpression();
                Expect(TokenType.Comma, "','");
                var elseExpr = ParseExpression();
                Expect(TokenType.RightParen, "')'");
                return new ConditionalExpr(condition, thenExpr, elseExpr);
            }

            case TokenType.Eof:
                throw new FormulaParseException(Current.Position, "Unexpected end of formula");

            default:
                throw new FormulaParseException(Current.Position,
                    $"Unexpected token '{Current.Value}'");
        }
    }

    // ── Public API ───────────────────────────────────────────────
    public FormulaExpression Parse(string formula)
    {
        if (string.IsNullOrWhiteSpace(formula))
            throw new FormulaParseException(0, "Formula cannot be empty");

        _tokens = Tokenize(formula);
        _pos = 0;

        var expr = ParseExpression();

        if (Current.Type != TokenType.Eof)
            throw new FormulaParseException(Current.Position,
                $"Unexpected token '{Current.Value}' after expression");

        return expr;
    }

    public string PrettyPrint(FormulaExpression expression)
    {
        return expression switch
        {
            NumberLiteral n => FormatNumber(n.Value),
            ParameterRef p => p.Name,
            BinaryOp b => $"({PrettyPrint(b.Left)} {b.Operator} {PrettyPrint(b.Right)})",
            ComparisonOp c => $"({PrettyPrint(c.Left)} {c.Operator} {PrettyPrint(c.Right)})",
            ConditionalExpr cond =>
                $"if({PrettyPrint(cond.Condition)}, {PrettyPrint(cond.ThenExpr)}, {PrettyPrint(cond.ElseExpr)})",
            _ => throw new ArgumentException($"Unknown expression type: {expression.GetType().Name}")
        };
    }

    private static string FormatNumber(double value)
    {
        if (value == Math.Floor(value) && !double.IsInfinity(value))
            return ((long)value).ToString(CultureInfo.InvariantCulture);
        return value.ToString("G", CultureInfo.InvariantCulture);
    }
}


