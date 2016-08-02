using System;

namespace Piwik.NETCore.Analytics
{
    public class PiwikApiException : Exception
    {
        public PiwikApiException(string message) : base(message)
        {
        }
        
        public PiwikApiException(string message, Exception ex) : base(message, ex)
        {   
        }
    }
}