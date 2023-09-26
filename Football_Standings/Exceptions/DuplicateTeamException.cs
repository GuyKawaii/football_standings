namespace Football_Standings.Exceptions;

using System;

public class DuplicateTeamException : Exception
{
    public DuplicateTeamException()
    {
    }

    public DuplicateTeamException(string message)
        : base(message)
    {
        
    }
}