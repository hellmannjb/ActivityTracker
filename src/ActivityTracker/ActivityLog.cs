using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace ActivityTracker
{
    class ActivityLog
    {
        //ActivityLog class maintains list of activity objects and related functions

        //method adds newly created activities to list
        public void Add(Activity activity)
            {
                ActivitiesList.Add(activity);
            }

        //loads activites from json file
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

        //method uses LINQ to extract activities logged within the past week and displays in console.
        public void WeeklySummary()
        {
            var maxExcertion = double.MinValue;
            var totalExcertion = 0.0;
            var totalDuration = 0.0;
            var oneWeekago = DateTime.Today.AddDays(-7);
            var activityCount = 0;

            System.Console.WriteLine($"You have logged the following activities this week:");
            System.Console.WriteLine();
            System.Console.WriteLine("{0, -15} {1,-15} {2,-15} {3,-25}", "Activity", "Exertion", "Duration(min)", "When");

            //querying activity objects from past week
            IEnumerable<Activity> weekQuery = from a in ActivitiesList 
                                              where a.timeStamp <= DateTime.Now && a.timeStamp >= oneWeekago
                                              select a;
            
            foreach (Activity a in weekQuery)
            {
                activityCount += 1;
                System.Console.WriteLine("{0, -15} {1,-15} {2,-15} {3,-25}", a.Name, a.PerceivedExertion, a.Duration, a.timeStamp);
                maxExcertion = Math.Max(a.PerceivedExertion, maxExcertion);
                totalExcertion += a.PerceivedExertion;
                totalDuration += a.Duration;
            }

            var durationHours = totalDuration/60.0;
            var avgExcertion = totalExcertion/activityCount;
            System.Console.WriteLine();
            System.Console.WriteLine($"Your max excertion this week is {maxExcertion}.");
            System.Console.WriteLine($"Your average excertion this week is {avgExcertion:N1}.");
            System.Console.WriteLine($"You have performed these activities for a total of {durationHours:N1} hours this week.");
        }

        //method displays all activities in list to console. 
        public void AllTimeSummary()
        {
            var maxExcertion = double.MinValue;
            var totalExcertion = 0.0;
            var totalDuration = 0.0;

            System.Console.WriteLine($"You have logged the following activities:");
            System.Console.WriteLine();
            System.Console.WriteLine("{0, -15} {1,-15} {2,-15} {3,-25}", "Activity", "Exertion", "Duration(min)", "When");

            foreach (Activity a in ActivitiesList)
            {
                System.Console.WriteLine("{0, -15} {1,-15} {2,-15} {3,-25}", a.Name, a.PerceivedExertion, a.Duration, a.timeStamp);
                maxExcertion = Math.Max(a.PerceivedExertion, maxExcertion);
                totalExcertion += a.PerceivedExertion;
                totalDuration += a.Duration;
            }

            var durationHours = totalDuration/60.0;
            var avgExcertion = totalExcertion/ActivitiesList.Count;
            System.Console.WriteLine();
            System.Console.WriteLine($"Your max excertion thus far is {maxExcertion}.");
            System.Console.WriteLine($"Your average excertion is {avgExcertion:N1}.");
            System.Console.WriteLine($"You have performed these activities for a total of {durationHours:N1} hours.");
        }

        //saves activities list to json file
        public void SaveActivities(string path)
        {
            var activityJson = JsonConvert.SerializeObject(ActivitiesList);
            File.WriteAllText(path, activityJson);
        }


        //method deletes activities from lsit
        public void DeleteActivityLog()
        { 
                ActivitiesList.Clear();
        }

        //list of activity objects
        public List<Activity> ActivitiesList = new List<Activity>();

    }


}