using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Umbraco.BackofficeDocumentor.Models;

namespace Umbraco.BackofficeDocumentor.Services
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

        public static string FormatId(this VisualizerContentTypeModel model)
        {
            return string.Format("cmp_{0}", model.Id);
        }

        public static IHtmlString ContentTypeLink(this HtmlHelper html, VisualizerContentTypeModel model, object htmlAttributes=null)
        {
            if (model == null)
                return null;
            var tb=new TagBuilder("a");
            tb.MergeAttribute("class","small");
            tb.MergeAttribute("href","#" + model.FormatId());
            tb.InnerHtml = model.Name;

            if (htmlAttributes != null)
            {
                var dictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                tb.MergeAttributes(dictionary,true);
            }
            

            return new MvcHtmlString(tb.ToString());
        }
    }
}