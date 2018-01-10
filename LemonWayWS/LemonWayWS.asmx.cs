using LemonWayTools;
using log4net;
using System.Numerics;
using System.Threading;
using System.Web.Services;
namespace LemonWayWS
{
    /// <summary>
    /// Description résumée de LemonWayWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    //[System.Web.Script.Services.ScriptService]
    public class LemonWayWS : System.Web.Services.WebService
    {
        //Log4net
        private static readonly ILog _Log = LogManager.GetLogger(typeof(LemonWayWS));

        /// <summary>
        /// Fibonaccis the specified n.
        /// </summary>
        /// <param name="n">int between 1 and 100</param>
        /// <param name="sleep">if set to <c>true</c> [sleep 2000 ].</param>
        /// <returns>
        /// Fibonacci
        /// </returns>
        [WebMethod]
        public string Fibonacci(int n, bool sleep)
        {
            if (sleep)
                Thread.Sleep(2000);
            string fibonacci = LemonWayTools.Fibonacci.GetFibonacci(n).ToString();
            _Log.DebugFormat("Fibonacci: in: {0} --> out: {1}", n.ToString(), fibonacci);
            return fibonacci;
        }

        /// <summary>
        /// XML to json.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns>The Json</returns>
        [WebMethod]
        public string XmlToJson(string xml)
        {
            string _json = Transformer.TransformXML(xml);
            _Log.DebugFormat("XmlToJson: XML in: {0} --> JSON out: {1}", xml, _json);
            return _json;
        }
    }
}
