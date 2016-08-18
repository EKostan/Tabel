

using System;
using System.Diagnostics;
using System.Globalization;

namespace Core.Logging.Tracing
{
    public class TraceLog :
        ILog
    {
        readonly LogLevel _level;
        readonly TraceSource _source;

        public TraceLog(TraceSource source)
        {
            _source = source;
            _level = LogLevel.FromSourceLevels(source.Switch.Level);
        }

        public bool IsDebugEnabled
        {
            get { return _level >= LogLevel.Debug; }
        }

        public bool IsInfoEnabled
        {
            get { return _level >= LogLevel.Info; }
        }

        public bool IsWarnEnabled
        {
            get { return _level >= LogLevel.Warn; }
        }

        public bool IsErrorEnabled
        {
            get { return _level >= LogLevel.Error; }
        }

        public bool IsFatalEnabled
        {
            get { return _level >= LogLevel.Fatal; }
        }

        public void LogFormat(LogLevel level, string format, params object[] args)
        {
            if (_level < level)
                return;

            LogInternal(level, string.Format(format, args), null);
        }

        /// <summary>
        /// Logs a debug message.
        /// 
        /// </summary>
        /// <param name="message">The message to log</param>
        public void Debug(object message)
        {
            if (!IsDebugEnabled)
                return;
            Log(LogLevel.Debug, message, null);
        }

        /// <summary>
        /// Logs a debug message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        public void Debug(object message, Exception exception)
        {
            if (!IsDebugEnabled)
                return;
            Log(LogLevel.Debug, message, exception);
        }

        public void Debug(LogOutputProvider messageProvider)
        {
            if (!IsDebugEnabled)
                return;

            object obj = messageProvider();

            LogInternal(LogLevel.Debug, obj, null);
        }

        /// <summary>
        /// Logs a debug message.
        /// 
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void DebugFormat(string format, params object[] args)
        {
            if (!IsDebugEnabled)
                return;
            LogInternal(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, format, args), null);
        }

        /// <summary>
        /// Logs a debug message.
        /// 
        /// </summary>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (!IsDebugEnabled)
                return;
            LogInternal(LogLevel.Debug, string.Format(formatProvider, format, args), null);
        }

        /// <summary>
        /// Logs an info message.
        /// 
        /// </summary>
        /// <param name="message">The message to log</param>
        public void Info(object message)
        {
            if (!IsInfoEnabled)
                return;
            Log(LogLevel.Info, message, null);
        }

        /// <summary>
        /// Logs an info message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        public void Info(object message, Exception exception)
        {
            if (!IsInfoEnabled)
                return;
            Log(LogLevel.Info, message, exception);
        }

        public void Info(LogOutputProvider messageProvider)
        {
            if (!IsInfoEnabled)
                return;

            object obj = messageProvider();

            LogInternal(LogLevel.Info, obj, null);
        }

        /// <summary>
        /// Logs an info message.
        /// 
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void InfoFormat(string format, params object[] args)
        {
            if (!IsInfoEnabled)
                return;
            LogInternal(LogLevel.Info, string.Format(CultureInfo.CurrentCulture, format, args), null);
        }

        /// <summary>
        /// Logs an info message.
        /// 
        /// </summary>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (!IsInfoEnabled)
                return;
            LogInternal(LogLevel.Info, string.Format(formatProvider, format, args), null);
        }

        /// <summary>
        /// Logs a warn message.
        /// 
        /// </summary>
        /// <param name="message">The message to log</param>
        public void Warn(object message)
        {
            if (!IsWarnEnabled)
                return;
            Log(LogLevel.Warn, message, null);
        }

        /// <summary>
        /// Logs a warn message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        public void Warn(object message, Exception exception)
        {
            if (!IsWarnEnabled)
                return;
            Log(LogLevel.Warn, message, exception);
        }

        public void Warn(LogOutputProvider messageProvider)
        {
            if (!IsWarnEnabled)
                return;

            object obj = messageProvider();

            LogInternal(LogLevel.Warn, obj, null);
        }

        /// <summary>
        /// Logs a warn message.
        /// 
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void WarnFormat(string format, params object[] args)
        {
            if (!IsWarnEnabled)
                return;
            LogInternal(LogLevel.Warn, string.Format(CultureInfo.CurrentCulture, format, args), null);
        }

        /// <summary>
        /// Logs a warn message.
        /// 
        /// </summary>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (!IsWarnEnabled)
                return;
            LogInternal(LogLevel.Warn, string.Format(formatProvider, format, args), null);
        }

        /// <summary>
        /// Logs an error message.
        /// 
        /// </summary>
        /// <param name="message">The message to log</param>
        public void Error(object message)
        {
            if (!IsErrorEnabled)
                return;
            Log(LogLevel.Error, message, null);
        }

        /// <summary>
        /// Logs an error message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        public void Error(object message, Exception exception)
        {
            if (!IsErrorEnabled)
                return;
            Log(LogLevel.Error, message, exception);
        }

        public void Error(LogOutputProvider messageProvider)
        {
            if (!IsErrorEnabled)
                return;

            object obj = messageProvider();

            LogInternal(LogLevel.Error, obj, null);
        }

        /// <summary>
        /// Logs an error message.
        /// 
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void ErrorFormat(string format, params object[] args)
        {
            if (!IsErrorEnabled)
                return;
            LogInternal(LogLevel.Error, string.Format(CultureInfo.CurrentCulture, format, args), null);
        }

        /// <summary>
        /// Logs an error message.
        /// 
        /// </summary>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (!IsErrorEnabled)
                return;
            LogInternal(LogLevel.Error, string.Format(formatProvider, format, args), null);
        }

        /// <summary>
        /// Logs a fatal message.
        /// 
        /// </summary>
        /// <param name="message">The message to log</param>
        public void Fatal(object message)
        {
            if (!IsFatalEnabled)
                return;
            Log(LogLevel.Fatal, message, null);
        }

        /// <summary>
        /// Logs a fatal message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        public void Fatal(object message, Exception exception)
        {
            if (!IsFatalEnabled)
                return;
            Log(LogLevel.Fatal, message, exception);
        }

        public void Fatal(LogOutputProvider messageProvider)
        {
            if (!IsFatalEnabled)
                return;

            object obj = messageProvider();

            LogInternal(LogLevel.Fatal, obj, null);
        }

        /// <summary>
        /// Logs a fatal message.
        /// 
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void FatalFormat(string format, params object[] args)
        {
            if (!IsFatalEnabled)
                return;
            LogInternal(LogLevel.Fatal, string.Format(CultureInfo.CurrentCulture, format, args), null);
        }

        /// <summary>
        /// Logs a fatal message.
        /// 
        /// </summary>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            if (!IsFatalEnabled)
                return;
            LogInternal(LogLevel.Fatal, string.Format(formatProvider, format, args), null);
        }

        public void Log(LogLevel level, object obj)
        {
            if (_level < level)
                return;

            LogInternal(level, obj, null);
        }

        public void Log(LogLevel level, object obj, Exception exception)
        {
            if (_level < level)
                return;

            LogInternal(level, obj, exception);
        }

        public void Log(LogLevel level, LogOutputProvider messageProvider)
        {
            if (_level < level)
                return;

            object obj = messageProvider();

            LogInternal(level, obj, null);
        }

        public void LogFormat(LogLevel level, IFormatProvider formatProvider, string format, params object[] args)
        {
            if (_level < level)
                return;

            LogInternal(level, string.Format(formatProvider, format, args), null);
        }

        /// <summary>
        /// Logs a debug message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void DebugFormat(Exception exception, string format, params object[] args)
        {
            if (!IsDebugEnabled)
                return;
            LogInternal(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, format, args), exception);
        }

        /// <summary>
        /// Logs a debug message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void DebugFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            if (!IsDebugEnabled)
                return;
            LogInternal(LogLevel.Debug, string.Format(formatProvider, format, args), exception);
        }

        /// <summary>
        /// Logs an info message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void InfoFormat(Exception exception, string format, params object[] args)
        {
            if (!IsInfoEnabled)
                return;
            LogInternal(LogLevel.Info, string.Format(CultureInfo.CurrentCulture, format, args), exception);
        }

        /// <summary>
        /// Logs an info message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void InfoFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            if (!IsInfoEnabled)
                return;
            LogInternal(LogLevel.Info, string.Format(formatProvider, format, args), exception);
        }

        /// <summary>
        /// Logs a warn message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void WarnFormat(Exception exception, string format, params object[] args)
        {
            if (!IsWarnEnabled)
                return;
            LogInternal(LogLevel.Warn, string.Format(CultureInfo.CurrentCulture, format, args), exception);
        }

        /// <summary>
        /// Logs a warn message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void WarnFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            if (!IsWarnEnabled)
                return;
            LogInternal(LogLevel.Warn, string.Format(formatProvider, format, args), exception);
        }

        /// <summary>
        /// Logs an error message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void ErrorFormat(Exception exception, string format, params object[] args)
        {
            if (!IsErrorEnabled)
                return;
            LogInternal(LogLevel.Error, string.Format(CultureInfo.CurrentCulture, format, args), exception);
        }

        /// <summary>
        /// Logs an error message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void ErrorFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            if (!IsErrorEnabled)
                return;
            LogInternal(LogLevel.Error, string.Format(formatProvider, format, args), exception);
        }

        /// <summary>
        /// Logs a fatal message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void FatalFormat(Exception exception, string format, params object[] args)
        {
            if (!IsFatalEnabled)
                return;
            LogInternal(LogLevel.Fatal, string.Format(CultureInfo.CurrentCulture, format, args), exception);
        }

        /// <summary>
        /// Logs a fatal message.
        /// 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        public void FatalFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
        {
            if (!IsFatalEnabled)
                return;
            LogInternal(LogLevel.Fatal, string.Format(formatProvider, format, args), exception);
        }

        void LogInternal(LogLevel level, object obj, Exception exception)
        {
            string message = obj == null
                                 ? ""
                                 : obj.ToString();

            if (exception == null)
                _source.TraceEvent(level.TraceEventType, 0, message);
            else
                _source.TraceData(level.TraceEventType, 0, (object)message, (object)exception);
        }
    }
}