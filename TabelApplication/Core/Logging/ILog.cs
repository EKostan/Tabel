
using System;

namespace Core.Logging
{
    /// <summary>
    /// Implementers handle logging and filtering based on logging levels.
    /// </summary>
    public interface ILog
    {
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }

        void Log(LogLevel level, object obj);
        void Log(LogLevel level, object obj, Exception exception);
        void Log(LogLevel level, LogOutputProvider messageProvider);
        void LogFormat(LogLevel level, IFormatProvider formatProvider, string format, params object[] args);
        void LogFormat(LogLevel level, string format, params object[] args);

        void Debug(object obj);
        void Debug(object obj, Exception exception);
        void Debug(LogOutputProvider messageProvider);
        void DebugFormat(IFormatProvider formatProvider, string format, params object[] args);
        void DebugFormat(string format, params object[] args);

        void Info(object obj);
        void Info(object obj, Exception exception);
        void Info(LogOutputProvider messageProvider);
        void InfoFormat(IFormatProvider formatProvider, string format, params object[] args);
        void InfoFormat(string format, params object[] args);

        void Warn(object obj);
        void Warn(object obj, Exception exception);
        void Warn(LogOutputProvider messageProvider);
        void WarnFormat(IFormatProvider formatProvider, string format, params object[] args);
        void WarnFormat(string format, params object[] args);

        void Error(object obj);
        void Error(object obj, Exception exception);
        void Error(LogOutputProvider messageProvider);
        void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args);
        void ErrorFormat(string format, params object[] args);

        void Fatal(object obj);
        void Fatal(object obj, Exception exception);
        void Fatal(LogOutputProvider messageProvider);
        void FatalFormat(IFormatProvider formatProvider, string format, params object[] args);
        void FatalFormat(string format, params object[] args);
    }
}