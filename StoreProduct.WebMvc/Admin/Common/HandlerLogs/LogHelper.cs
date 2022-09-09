using System;
using System.Linq;
using System.Security.Claims;

namespace Admin.Common.HandlerLogs
{
    public class LogHelper
    {
        public static void WriteLogStatus(Guid visitId, string action, string content = "WRITE_LOG", string url = "STATUS_BY_ADMIN", string info = "INFO", Guid? fromId = null)
        {
            if (string.IsNullOrEmpty(content))
            {
                content = "WRITE_LOG";
            }
            if (string.IsNullOrEmpty(url))
            {
                url = "STATUS_BY_ADMIN";
            }
            if (string.IsNullOrEmpty(info))
            {
                info = "INFO";
            }

            if (fromId != null)
            {
                info = $"{info} @ VisitId: {visitId}, FromId :{fromId.ToString().ToUpper()}";
            }
            else
            {
                info = $"{info} @ VisitId: {visitId.ToString().ToUpper()}";
            }
            var user = GetUserName();
        }
        private static string GetUserName()
        {
            try
            {
                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                return claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name, StringComparison.OrdinalIgnoreCase))?.Value;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}