using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Core.Extensions
{
    public static class EnumerableActionExtansions
    {
        public static void ExecAsync(this IEnumerable<Action> actions)
        {
            int count = 0;
            var enumerable = actions as Action[] ?? actions.ToArray();
            AutoResetEvent[] events = new AutoResetEvent[enumerable.Count()];
            IAsyncResult[] results = new IAsyncResult[enumerable.Count()];
            for (int i = 0; i < events.Length; i++)
            {
                events[i] = new AutoResetEvent(false);
            }

            foreach (var action in enumerable)
            {
                int localCount = count;
                results[count++] =
                    action.BeginInvoke(r =>
                    {
                        try
                        {
                            if (r.IsCompleted)
                            {
                                Action act = r.AsyncState as Action;
                                if (act != null) 
                                    act.EndInvoke(results[localCount]);
                            }
                        }
                        finally
                        {
                            events[localCount].Set();
                        }
                    }, action);
            }
            WaitHandle.WaitAll(events);
        }  
    }
}