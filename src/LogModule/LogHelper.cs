using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Core;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace LogModule
{
    /// <summary>
    /// 日志
    /// </summary>
    public class LogHelper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static void WriteMsg(object msg, Exception exception = null)
        {
            WriteMsg(msg,Level.Error,exception);
        }

        public static void WriteMsg(object msg, Level level, Exception exception = null)
        {
            if(level==Level.Debug) log.Debug(msg,exception);
            else    if(level== Level.Error) log.Error(msg,exception);
        }
    }
}
