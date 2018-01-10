using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace LemonWayWS.Tests
{
    [TestClass()]
    public class XMLtoJSONTests
    {
        private LemonWayWS _ws = new LemonWayWS();
        [TestMethod()]
        public void XmlToJsonTest1()
        {
            string _in = @"<foo>bar</foo>";
            string _out = @"{""foo"": ""bar"" }";
            JObject _jOut = JObject.Parse(_out);
            JObject _jExpected = JObject.Parse(_ws.XmlToJson(_in));
            Assert.IsTrue(JToken.DeepEquals(_jOut, _jExpected));
        }
        public void XmlToJsonTest2()
        {
            string _in = @"<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>";
            string _out = @"{""TRANS"": {""HPAY"": {""ID"": ""103"",""STATUS"": ""3"",""EXTRA"": {""IS3DS"": ""0"",""AUTH"": ""031183""},""MLABEL"": ""501767XXXXXX6700"",""MTOKEN"": ""project01""}}}";
            JObject _jOut = JObject.Parse(_out);
            JObject _jExpected = JObject.Parse(_ws.XmlToJson(_in));
            Assert.IsTrue(JToken.DeepEquals(_jOut, _jExpected));
        }
        [TestMethod()]
        public void XmlToJsonFail()
        {
            string _in = @"<foo>hello</bar>";
            Assert.AreEqual("Bad Xml format", _ws.XmlToJson(_in));
        }
    }
}