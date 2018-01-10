using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LemonWayTools

{
    public static class Transformer
    {
        /// <summary>
        /// Transforms the XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>The Json</returns>
        public static string TransformXML(string xml)
        {
            XmlDocument x = new XmlDocument();
            try
            {
                x.LoadXml(xml);
            }
            catch (Exception)
            {
                return "Bad Xml format";
            }
            return JsonConvert.SerializeXmlNode(x);
        }
    }
}
