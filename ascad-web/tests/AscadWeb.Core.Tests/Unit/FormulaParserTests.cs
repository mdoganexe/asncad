using AscadWeb.Core.Exceptions;
using AscadWeb.Core.Models;
using AscadWeb.Core.Services;

namespace AscadWeb.Core.Tests.Unit;

public class FormulaParserTests
{
    private readonly FormulaParserService _parser = new();

    // ── Numeric literals ─────────────────────────────────────────

    [Theory]
    [InlineData("123", 123)]
    [InlineData("3.14", 3.14)]
    [InlineData("0", 0)]
    [InlineData("0.5", 0.5)]
    public void Parse_NumberLiteral_ReturnsCorrectValue(string input, double expected)
    {
        var result = _parser.Parse(input);
        var num = Assert.IsType<NumberLiteral>(result);
        Assert.Equal(expected, num.Value);
    }

    [Fact]
    public void Parse_NegativeNumber_ReturnsNegativeNumberLiteral()
    {
        var result = _parser.Parse("-5");
        var num = Assert.IsType<NumberLiteral>(result);
        Assert.Equal(-5, num.Value);
    }

    // ── Parameter references ─────────────────────────────────────

    [Theory]
    [InlineData("KabinGen")]
    [InlineData("BeyanYuk")]
    [InlineData("x")]
    public void Parse_Identifier_ReturnsParameterRef(string input)
    {
        var result = _parser.Parse(input);
        var param = Assert.IsType<ParameterRef>(result);
        Assert.Equal(input, param.Name);
    }

    // ── Binary operators ─────────────────────────────────────────

    [Fact]
    public void Parse_Addition_ReturnsBinaryOp()
    {
        var result = _parser.Parse("1 + 2");
        var op = Assert.IsType<BinaryOp>(result);
        Assert.Equal("+", op.Operator);
        Assert.Equal(1, ((NumberLiteral)op.Left).Value);
        Assert.Equal(2, ((NumberLiteral)op.Right).Value);
    }

    [Fact]
    public void Parse_MultiplicationPrecedence_CorrectTree()
    {
        // 1 + 2 * 3 should parse as 1 + (2 * 3)
        var result = _parser.Parse("1 + 2 * 3");
        var add = Assert.IsType<BinaryOp>(result);
        Assert.Equal("+", add.Operator);
        Assert.Equal(1, ((NumberLiteral)add.Left).Value);
        var mul = Assert.IsType<BinaryOp>(add.Right);
        Assert.Equal("*", mul.Operator);
        Assert.Equal(2, ((NumberLiteral)mul.Left).Value);
        Assert.Equal(3, ((NumberLiteral)mul.Right).Value);
    }

    [Fact]
    public void Parse_LeftAssociativity_Addition()
    {
        // 1 - 2 + 3 should parse as (1 - 2) + 3
        var result = _parser.Parse("1 - 2 + 3");
        var outer = Assert.IsType<BinaryOp>(result);
        Assert.Equal("+", outer.Operator);
        var inner = Assert.IsType<BinaryOp>(outer.Left);
        Assert.Equal("-", inner.Operator);
    }

    // ── Comparison operators ─────────────────────────────────────

    [Theory]
    [InlineData("a > 5", ">")]
    [InlineData("a < 5", "<")]
    [InlineData("a >= 5", ">=")]
    [InlineData("a <= 5", "<=")]
    [InlineData("a == 5", "==")]
    [InlineData("a != 5", "!=")]
    public void Parse_ComparisonOperators_ReturnsComparisonOp(string input, string expectedOp)
    {
        var result = _parser.Parse(input);
        var cmp = Assert.IsType<ComparisonOp>(result);
        Assert.Equal(expectedOp, cmp.Operator);
    }

    // ── Parentheses ──────────────────────────────────────────────

    [Fact]
    public void Parse_Parentheses_OverridePrecedence()
    {
        // (1 + 2) * 3 should parse as (1 + 2) * 3
        var result = _parser.Parse("(1 + 2) * 3");
        var mul = Assert.IsType<BinaryOp>(result);
        Assert.Equal("*", mul.Operator);
        var add = Assert.IsType<BinaryOp>(mul.Left);
        Assert.Equal("+", add.Operator);
    }

    // ── Conditional expressions ──────────────────────────────────

    [Fact]
    public void Parse_IfExpression_ReturnsConditionalExpr()
    {
        var result = _parser.Parse("if(x > 5, 10, 20)");
        var cond = Assert.IsType<ConditionalExpr>(result);
        Assert.IsType<ComparisonOp>(cond.Condition);
        Assert.Equal(10, ((NumberLiteral)cond.ThenExpr).Value);
        Assert.Equal(20, ((NumberLiteral)cond.ElseExpr).Value);
    }

    [Fact]
    public void Parse_NestedIf_ReturnsNestedConditional()
    {
        var result = _parser.Parse("if(a > 0, if(b > 0, 1, 2), 3)");
        var outer = Assert.IsType<ConditionalExpr>(result);
        var inner = Assert.IsType<ConditionalExpr>(outer.ThenExpr);
        Assert.Equal(1, ((NumberLiteral)inner.ThenExpr).Value);
    }

    // ── Complex expressions ──────────────────────────────────────

    [Fact]
    public void Parse_ComplexFormula_ParsesCorrectly()
    {
        var result = _parser.Parse("KabinGen * KabinDer / 1000000");
        var div = Assert.IsType<BinaryOp>(result);
        Assert.Equal("/", div.Operator);
        var mul = Assert.IsType<BinaryOp>(div.Left);
        Assert.Equal("*", mul.Operator);
    }

    // ── PrettyPrint ──────────────────────────────────────────────

    [Fact]
    public void PrettyPrint_NumberLiteral_FormatsCorrectly()
    {
        Assert.Equal("42", _parser.PrettyPrint(new NumberLiteral(42)));
        Assert.Equal("3.14", _parser.PrettyPrint(new NumberLiteral(3.14)));
        Assert.Equal("-5", _parser.PrettyPrint(new NumberLiteral(-5)));
    }

    [Fact]
    public void PrettyPrint_BinaryOp_IncludesParentheses()
    {
        var expr = new BinaryOp(new NumberLiteral(1), "+", new NumberLiteral(2));
        Assert.Equal("(1 + 2)", _parser.PrettyPrint(expr));
    }

    [Fact]
    public void PrettyPrint_ConditionalExpr_FormatsCorrectly()
    {
        var expr = new ConditionalExpr(
            new ComparisonOp(new ParameterRef("x"), ">", new NumberLiteral(5)),
            new NumberLiteral(10),
            new NumberLiteral(20));
        Assert.Equal("if((x > 5), 10, 20)", _parser.PrettyPrint(expr));
    }

    // ── Round-trip ───────────────────────────────────────────────

    [Theory]
    [InlineData("42")]
    [InlineData("KabinGen")]
    [InlineData("1 + 2")]
    [InlineData("if(x > 5, 10, 20)")]
    public void ParsePrintParse_RoundTrip_ProducesEquivalentAST(string input)
    {
        var ast1 = _parser.Parse(input);
        var printed = _parser.PrettyPrint(ast1);
        var ast2 = _parser.Parse(printed);
        Assert.Equal(ast1, ast2);
    }

    // ── Error handling ───────────────────────────────────────────

    [Fact]
    public void Parse_EmptyString_ThrowsFormulaParseException()
    {
        var ex = Assert.Throws<FormulaParseException>(() => _parser.Parse(""));
        Assert.Equal(0, ex.Position);
    }

    [Fact]
    public void Parse_UnbalancedParenthesis_ThrowsWithPosition()
    {
        var ex = Assert.Throws<FormulaParseException>(() => _parser.Parse("(1 + 2"));
        Assert.Contains("')'", ex.Description);
    }

    [Fact]
    public void Parse_InvalidCharacter_ThrowsWithPosition()
    {
        var ex = Assert.Throws<FormulaParseException>(() => _parser.Parse("1 @ 2"));
        Assert.Equal(2, ex.Position);
    }

    [Fact]
    public void Parse_TrailingTokens_ThrowsWithPosition()
    {
        var ex = Assert.Throws<FormulaParseException>(() => _parser.Parse("1 2"));
        Assert.True(ex.Position > 0);
    }

    [Fact]
    public void Parse_IncompleteIf_ThrowsFormulaParseException()
    {
        Assert.Throws<FormulaParseException>(() => _parser.Parse("if(x > 5, 10)"));
    }

    [Fact]
    public void Parse_UnaryNegationOnExpression_Works()
    {
        // -x should parse as (0 - x)
        var result = _parser.Parse("-x");
        var op = Assert.IsType<BinaryOp>(result);
        Assert.Equal("-", op.Operator);
        Assert.Equal(0, ((NumberLiteral)op.Left).Value);
        Assert.IsType<ParameterRef>(op.Right);
    }
}
