using System;
using System.Collections.Generic;

namespace ActivityTracker
{
    public class MainMenu
    {

        ActivityLog activityLog = new ActivityLog();
        internal void DisplayMenu()
        {

            var quitMenu = false;
            while (!quitMenu)
            {
                System.Console.WriteLine("Activity Manager");
                System.Console.WriteLine();
                System.Console.WriteLine("1. Log an Activity");
                System.Console.WriteLine("2. Get Activities Summary");
                System.Console.WriteLine("3. Clear Activity Logs");
                System.Console.WriteLine("4. Exit");

                var result = System.Console.ReadLine();
                
                switch(result)
                {
                    case "1":
                    {
                        LogActivity();
                        break;
                    }

                    case "2":
                    {
                        ListActivitySummary();
                        //"You have performed the following activities: {activitiesList}. Total duration of {totalDuration}. Avg Duration of {avgDuration}. Avg excertion of {avgExcertion}. Max excertion of {maxExcertion}.
                        break;
                    }

                    case "3":
                    {
                        ClearActivityLog();
                        break;
                    }

                    case "4":
                    {
                        quitMenu = true;
                        System.Console.WriteLine("Keep up the good work!");
                        break;
                    }
                }
            }
        }
        
        private void LogActivity()
        {
            Activity activity = new Activity();
            System.Console.WriteLine("What activity would you like to log?");
            var input = Console.ReadLine();
            activity.Name = input;
            System.Console.WriteLine("How long did you perform the activity?");
            activity.Duration = double.Parse(Console.ReadLine());
            System.Console.WriteLine("What was your percieved exertion (1-10)?");
            activity.PerceivedExertion = int.Parse(Console.ReadLine());
            activityLog.Add(activity);
            activity.SummarizeEntry();
        }

        private void ListActivitySummary()
        {
            activityLog.Summary();
        }

        private void ClearActivityLog()
        {
            throw new NotImplementedException();
        }

        //public void Add(Activity activity)
            //{
                //ActivitiesList.Add(activity);
            //}

        //public void Summary()
        //{
            //foreach (Activity a in ActivitiesList)
            //{
                //System.Console.WriteLine(a.Name);
            //}
        //}

         //public List<Activity> ActivitiesList = new List<Activity>();

    }
}