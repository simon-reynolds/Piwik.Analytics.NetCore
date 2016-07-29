#region license

// http://www.gnu.org/licenses/gpl-3.0.html GPL v3 or later

#endregion

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