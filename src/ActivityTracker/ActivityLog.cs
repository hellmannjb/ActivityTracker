using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace ActivityTracker
{
    class ActivityLog
    {
        public void Add(Activity activity)
            {
                ActivitiesList.Add(activity);
            }

        public void LoadActivities(string path)
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                try
                {
                    ActivitiesList = JsonConvert.DeserializeObject<List<Activity>>(json);
                }
                catch
                {
                }
            }
        }

        public void WeeklySummary()
        {
            var maxExcertion = double.MinValue;
            var totalExcertion = 0.0;
            var totalDuration = 0;
            var oneWeekago = DateTime.Today.AddDays(-7);

            System.Console.WriteLine($"You have logged the following activities this week:");
            System.Console.WriteLine();

            IEnumerable<Activity> weekQuery = from a in ActivitiesList 
                                              where a.timeStamp <= DateTime.Now && a.timeStamp >= oneWeekago
                                              select a;

            foreach (Activity a in weekQuery)
            {
                System.Console.WriteLine(a.Name);
                maxExcertion = Math.Max(a.PerceivedExertion, maxExcertion);
                totalExcertion += a.PerceivedExertion;
                totalDuration += a.Duration;
            }

            var avgExcertion = totalExcertion/ActivitiesList.Count;
            System.Console.WriteLine();
            System.Console.WriteLine($"Your max excertion this week is {maxExcertion}.");
            System.Console.WriteLine($"Your average excertion this week is {avgExcertion:N1}.");
            System.Console.WriteLine($"You have worked out for a total of {totalDuration} minutes this week.");

        }

        public void AllTimeSummary()
        {
            var maxExcertion = double.MinValue;
            var totalExcertion = 0.0;
            var totalDuration = 0;

            System.Console.WriteLine($"You have logged the following activities:");
            System.Console.WriteLine();

            foreach (Activity a in ActivitiesList)
            {
                System.Console.WriteLine(a.Name);
                maxExcertion = Math.Max(a.PerceivedExertion, maxExcertion);
                totalExcertion += a.PerceivedExertion;
                totalDuration += a.Duration;
            }

            var avgExcertion = totalExcertion/ActivitiesList.Count;
            System.Console.WriteLine();
            System.Console.WriteLine($"Your max excertion thus far is {maxExcertion}.");
            System.Console.WriteLine($"Your average excertion is {avgExcertion:N1}.");
            System.Console.WriteLine($"You have worked out for a total of {totalDuration} minutes.");
        }

        public void SaveActivities(string path)
        {
            var activityJson = JsonConvert.SerializeObject(ActivitiesList);
            File.WriteAllText(path, activityJson);
        }

        public void DeleteActivityLog()
        { 
                ActivitiesList.Clear();
        }

        public List<Activity> ActivitiesList = new List<Activity>();

    }


}