namespace AscadWeb.Core.Models;

public abstract record FormulaExpression;

public record NumberLiteral(double Value) : FormulaExpression;

public record ParameterRef(string Name) : FormulaExpression;

public record BinaryOp(FormulaExpression Left, string Operator, FormulaExpression Right) : FormulaExpression;

public record ComparisonOp(FormulaExpression Left, string Operator, FormulaExpression Right) : FormulaExpression;

public record ConditionalExpr(FormulaExpression Condition, FormulaExpression ThenExpr, FormulaExpression ElseExpr) : FormulaExpression;
