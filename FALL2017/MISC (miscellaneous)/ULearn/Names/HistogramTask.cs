using System;

namespace Names
{
    internal static class HistogramTask
    {

        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            int minDay = 2;
            int maxDay = int.MinValue;
            foreach (NameData day in names)
                maxDay = Math.Max(maxDay, day.BirthDate.Day);
            string[] days = new string[maxDay - minDay + 1];
            for (int a = 1; a < days.Length; a++)
            {
                days[a] = (a + minDay).ToString();
            }
            var birthdayCounts = new double[maxDay - minDay + 1];
            foreach (NameData day in names)
            {
                if (day.Name == name && day.BirthDate.Day > 1)
                    birthdayCounts[day.BirthDate.Day - minDay]++;
            }

            return new HistogramData(String.Format("Рождаемость людей с именем '{0}'", name), days, birthdayCounts);
        }
    }
}