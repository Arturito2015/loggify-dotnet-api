using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Loggify
{
    public static class LoggifyApp
    {
        public static string workspaceId { get; set; }
        public static string workspaceCode { get; set; }
        public static string workspaceName { get; set; }
        public static string hashCode { get; set; }

        public static void Init(string _workSpaceId, string _workSpaceCode, string _workSpaceName, string _hashCode)
        {
            workspaceCode = _workSpaceCode;
            workspaceName = _workSpaceName;
            workspaceId = _workSpaceId;
            hashCode = _hashCode;
        }

        public static void Init() { }
        public static void Log(string title, string message, string state = "error", string group = "ffff")
        {

            HttpClient client = new HttpClient();
            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();

            values.Add(new KeyValuePair<string, string>("workspaceId", workspaceId));
            values.Add(new KeyValuePair<string, string>("workspaceCode", workspaceCode));
            values.Add(new KeyValuePair<string, string>("workspaceName", workspaceName));
            values.Add(new KeyValuePair<string, string>("hashCode", hashCode));
            values.Add(new KeyValuePair<string, string>("title", title));
            values.Add(new KeyValuePair<string, string>("message", message));
            values.Add(new KeyValuePair<string, string>("estado", state));
            values.Add(new KeyValuePair<string, string>("grupo", group));

            FormUrlEncodedContent content = new FormUrlEncodedContent(values);

            Uri uri = new Uri("http://104.248.103.156:1339/loggify");

            client.PostAsync(uri, content).GetAwaiter().GetResult();
        }
    }
}
