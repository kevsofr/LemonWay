using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using log4net;
using System.Text;

namespace LemonWayWS
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// The log
        /// </summary>
        private static readonly ILog _Log = LogManager.GetLogger(typeof(LemonWayWS));

        #region GlobalEvents
        protected void Application_Start(object sender, EventArgs e)
        {
            _Log.Info("Appliction Start");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var inputStream = Context.Request.InputStream;
            if (inputStream.Length > 0)
            {
                inputStream.Position = 0;
                byte[] rawBytes = new byte[inputStream.Length];
                inputStream.Read(rawBytes, 0, rawBytes.Length);
                inputStream.Position = 0;
                _Log.InfoFormat("{0}: {1} : body : {2} .", Request.UserHostAddress, base.Context.Request.Url.AbsoluteUri, Encoding.UTF8.GetString(rawBytes));
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            StringBuilder _errorMsg = new StringBuilder("Application_Error: Unhandled exception:");
            _errorMsg.AppendLine(string.Format("exception: {0}", ex.Message));
            _errorMsg.AppendLine(string.Format("InnerExcepion: {0}", ex.InnerException));
            _Log.InfoFormat(_errorMsg.ToString());
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            _Log.Info("Application End");
        }
        #endregion
    }
}