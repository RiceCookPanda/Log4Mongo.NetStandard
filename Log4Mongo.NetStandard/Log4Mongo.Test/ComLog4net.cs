using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Log4Mongo.Test
{   /// <summary>
    /// 公共日志记录辅助类
    /// </summary>
    public class ComLog4net
    {

        private static ILoggerRepository loggerRepository;

        /// <summary>
        /// Logger仓储
        /// </summary>
        public static ILoggerRepository LoggerRepository { get; private set; }

        /// <summary>
        /// Log对象
        /// </summary>
        public static ILog Log { get; private set; }


        /// <summary>
        /// 初始化日志
        /// </summary>
        /// <returns></returns>
        public static void LoadLogger()
        {
            LoggerRepository = CreateLoggerRepository();
            LoadLog4NetConfig();
        }

        /// <summary>
        /// 创建日志仓储实例
        /// </summary>
        /// <returns></returns>
        private static ILoggerRepository CreateLoggerRepository()
        {
            loggerRepository = loggerRepository ?? LogManager.CreateRepository("GlobalExceptionHandler"); // 单例
            return loggerRepository;
        }

        /// <summary>
        /// 加载log4net配置
        /// </summary>
        private static void LoadLog4NetConfig()
        {
            // 配置log4net
            log4net.Config.XmlConfigurator.Configure(loggerRepository, new System.IO.FileInfo(System.IO.Directory.GetCurrentDirectory() + "/log4net.config"));

            // 创建log实例
            Log = LogManager.GetLogger(loggerRepository.Name, AppDomain.CurrentDomain.FriendlyName);
        }


        ///// <summary>
        ///// 明确的异常,日志记录处理
        ///// </summary>
        ///// <param name="exception">异常对象</param>
        ///// <param name="message">自定义的明确的异常消息</param>
        ///// <returns></returns>
        //public static Exception WriteExceptionLog(Exception exception, string message)
        //{

        //    Log.Error(exception.Message, exception);

        //    ComException comException = new ComException(message);

        //    return comException;
        //}
    }
}
