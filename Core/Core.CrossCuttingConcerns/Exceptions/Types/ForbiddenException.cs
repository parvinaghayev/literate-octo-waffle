﻿namespace Core.CrossCuttingConcerns.Exceptions.Types
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base()
        {
        }

        public ForbiddenException(string message) : base(message)
        {
        }
    }
}