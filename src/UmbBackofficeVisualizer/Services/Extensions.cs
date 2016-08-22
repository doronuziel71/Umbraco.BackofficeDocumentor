using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UmbBackofficeVisualizer.Services
{
    public static class Extensions
    {
        public static bool IsValidJson(this string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) ||
                (strInput.StartsWith("[") && strInput.EndsWith("]")))
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}