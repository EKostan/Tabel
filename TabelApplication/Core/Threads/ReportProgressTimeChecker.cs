using System;

namespace Core.Threads
{
    class ReportProgressTimeChecker
    {
        public const int MIN_TIME_SEND_PROGRESS = 100;

        private DateTime prevTimeSendReportProgress = DateTime.MinValue;

        private object lockObject = new object();

        public bool CanYouReportProgress()
        {
            var nowDate = DateTime.Now;

            lock (lockObject)
            {

                if (prevTimeSendReportProgress != DateTime.MinValue)
                {
                    if ((nowDate - prevTimeSendReportProgress).Milliseconds < MIN_TIME_SEND_PROGRESS)
                    {
                        return false;
                    }
                }
                prevTimeSendReportProgress = nowDate;
                return true;
                
            }
        }


    }
}
