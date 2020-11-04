using System;
using System.Collections.Generic;

namespace ActivityTracker
{
     class ActivityLog
    {
        public void Add(Activity activity)
            {
                ActivitiesList.Add(activity);
            }

        public void Summary()
        {
            var maxExcertion = double.MinValue;
            var totalExcertion = 0.0;
            var totalDuration = 0;

            System.Console.WriteLine($"You have logged the following activities:");
            foreach (Activity a in ActivitiesList)
            {
                System.Console.WriteLine(a.Name);
                maxExcertion = Math.Max(a.PerceivedExertion, maxExcertion);
                totalExcertion += a.PerceivedExertion;
                totalDuration += a.Duration;
                
            }

            var avgExcertion = totalExcertion/ActivitiesList.Count;

            System.Console.WriteLine($"Your max excertion thus far is {maxExcertion}.");
            System.Console.WriteLine($"Your average excertion is {avgExcertion:N1}.");
            System.Console.WriteLine($"You have worked out for a total of {totalDuration} minutes.");

        }

         public List<Activity> ActivitiesList = new List<Activity>();

    }


}