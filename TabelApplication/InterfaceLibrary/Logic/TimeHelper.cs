using System;

namespace InterfaceLibrary.Logic
{
    public class TimeHelper
    {
        public static string GetSpeed(DateTime firstDate, DateTime lastDate)
        {
            if (lastDate == DateTime.MinValue
                || firstDate == DateTime.MinValue)
                return string.Empty;
            var speed = lastDate.Subtract(firstDate);
            return ConvertDate(speed);
        }

        public static string ConvertDate(DateTime date)
        {
            if (date == DateTime.MinValue)
                return string.Empty;
            return date.ToString("dd.MM.yyyy HH:mm");
        }

        public static string ConvertDate(TimeSpan time)
        {
            if (time == TimeSpan.MinValue)
                return "Нет данных";
            var resultString = string.Empty;
            if (time.Ticks < TimeSpan.TicksPerDay)
            {
                resultString = time.ToString(@"hh\:mm");
            }
            else
            {
                resultString = time.ToString(@"d\.hh\:mm");
                int dotIndex = resultString.IndexOf(".", StringComparison.Ordinal);
                resultString = resultString.Insert(dotIndex, "д");
            }
            int index = resultString.IndexOf(":", StringComparison.Ordinal);
            resultString = resultString.Insert(index, "ч");
            resultString = resultString.Insert(resultString.Length, "м");
            return resultString;
        }
    }
}
