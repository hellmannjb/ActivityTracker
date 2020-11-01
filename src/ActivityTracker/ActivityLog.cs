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
            foreach (Activity a in ActivitiesList)
            {
                System.Console.WriteLine(a);
            }
        }
         public List<Activity> ActivitiesList = new List<Activity>();

    }


}