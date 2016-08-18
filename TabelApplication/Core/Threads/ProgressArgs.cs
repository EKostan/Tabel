namespace Core.Threads
{
    public class ProgressArgs
    {
        

        public ProgressArgs(int percent, string statusString)
        {
            Percent = percent;
            StatusString = statusString;
            ForceReport = false;
        }

        public ProgressArgs(int percent, string statusString, bool forceReport)
        {
            Percent = percent;
            StatusString = statusString;
            ForceReport = forceReport;
        }

        /// <summary>
        /// Влияет на логику отправки прогресса. Если false, то работает ограничения Core.Threads.ReportProgressTimeChecker
        /// что сообщения прогресса могут быть отправлены не чаще чем раз в 100 милисекунд.
        /// Если true, то сообщение отправляется всегда.
        /// </summary>
        public bool ForceReport { get; set; }

        public int Percent { get; set; }
        public string StatusString { get; set; }
    }
}
