namespace Football_Standings.Exceptions;

public class SameTeamException : Exception
{
    public SameTeamException()
    {
    }

    public SameTeamException(string message)
        : base(message)
    {
    }
}