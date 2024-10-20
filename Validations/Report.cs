﻿namespace JWTAuthAuthentication.Validations
{
    public class Report
    {
        public string Message { get; set; }

        public Report() { }

        public Report(string message)
        {
            Message = message;
        }

        public static Report Create(string message) => new Report(message);

    }
}
