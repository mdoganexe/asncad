using AscadWeb.Core.Models;

namespace AscadWeb.Core.Interfaces;

public interface IFormulaParser
{
    FormulaExpression Parse(string formula);
    string PrettyPrint(FormulaExpression expression);
}
