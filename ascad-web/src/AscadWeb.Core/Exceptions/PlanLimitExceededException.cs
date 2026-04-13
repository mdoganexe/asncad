namespace AscadWeb.Core.Exceptions;

public class PlanLimitExceededException : Exception
{
    public PlanLimitExceededException(string message) : base(message)
    {
    }

    public PlanLimitExceededException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
