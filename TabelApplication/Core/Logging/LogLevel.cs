
using System.Collections.Generic;
using System.Diagnostics;

namespace Core.Logging
{
    public class LogLevel
    {
        public static readonly LogLevel All = new LogLevel("All", 6, SourceLevels.All, TraceEventType.Verbose);
        public static readonly LogLevel Debug = new LogLevel("Debug", 5, SourceLevels.Verbose, TraceEventType.Verbose);
        public static readonly LogLevel Error = new LogLevel("Error", 2, SourceLevels.Error, TraceEventType.Error);
        public static readonly LogLevel Fatal = new LogLevel("Fatal", 1, SourceLevels.Critical, TraceEventType.Critical);

        public static readonly LogLevel Info = new LogLevel("Info", 4, SourceLevels.Information,
            TraceEventType.Information);

        public static readonly LogLevel None = new LogLevel("None", 0, SourceLevels.Off, TraceEventType.Critical);
        public static readonly LogLevel Warn = new LogLevel("Warn", 3, SourceLevels.Warning, TraceEventType.Warning);

        readonly int _index;
        readonly string _name;
        readonly SourceLevels _sourceLevel;
        readonly TraceEventType _traceEventType;

        LogLevel(string name, int index, SourceLevels sourceLevel, TraceEventType traceEventType)
        {
            _name = name;
            _index = index;
            _sourceLevel = sourceLevel;
            _traceEventType = traceEventType;
        }

        public static IEnumerable<LogLevel> Values
        {
            get
            {
                yield return All;
                yield return Debug;
                yield return Info;
                yield return Warn;
                yield return Error;
                yield return Fatal;
                yield return None;
            }
        }

        public TraceEventType TraceEventType
        {
            get { return _traceEventType; }
        }

        public string Name
        {
            get { return _name; }
        }

        public SourceLevels SourceLevel
        {
            get { return _sourceLevel; }
        }

        public override string ToString()
        {
            return _name;
        }

        public static bool operator >(LogLevel left, LogLevel right)
        {
            return right != null && (left != null && left._index > right._index);
        }

        public static bool operator <(LogLevel left, LogLevel right)
        {
            return right != null && (left != null && left._index < right._index);
        }

        public static bool operator >=(LogLevel left, LogLevel right)
        {
            return right != null && (left != null && left._index >= right._index);
        }

        public static bool operator <=(LogLevel left, LogLevel right)
        {
            return right != null && (left != null && left._index <= right._index);
        }

        public static LogLevel FromSourceLevels(SourceLevels level)
        {
            switch (level)
            {
                case SourceLevels.Information:
                    return Info;
                case SourceLevels.Verbose:
                    return Debug;
                case ~SourceLevels.Off:
                    return Debug;
                case SourceLevels.Critical:
                    return Fatal;
                case SourceLevels.Error:
                    return Error;
                case SourceLevels.Warning:
                    return Warn;
                default:
                    return None;
            }
        }
    }
}