namespace AscadWeb.Core.Exceptions;

public class FormulaParseException : Exception
{
    public int Position { get; }
    public string Description { get; }

    public FormulaParseException(int position, string description)
        : base($"Parse error at position {position}: {description}")
    {
        Position = position;
        Description = description;
    }
}
