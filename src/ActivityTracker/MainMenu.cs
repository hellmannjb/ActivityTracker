using System;
using System.Collections.Generic;

namespace ActivityTracker
{
    public class MainMenu
    {

        const string path = "activity.json";

        ActivityLog activityLog = new ActivityLog();

        public MainMenu()
        {
            activityLog.LoadActivities(path);
        }
        internal void DisplayMenu()
        {

            var quitMenu = false;
            while (!quitMenu)
            {
                System.Console.WriteLine();
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
            
            activityLog.SaveActivities(path);
        }
        
        private void LogActivity()
        {
            Activity activity = new Activity();
            System.Console.WriteLine("Please input the name of the activity.");
            var input = Console.ReadLine();
            activity.Name = input;
            System.Console.WriteLine("How long (minutes) did you perform the activity?");
            activity.Duration = int.Parse(Console.ReadLine());
            System.Console.WriteLine("What was your percieved exertion (1-10)?");
            activity.PerceivedExertion = double.Parse(Console.ReadLine());
            activityLog.Add(activity);
            activity.SummarizeEntry();
        }

        private void ListActivitySummary()
        {
            activityLog.Summary();
        }

        private void ClearActivityLog()
        {
            System.Console.WriteLine("Are you sure you want to clear activity logs?");
            System.Console.WriteLine();
            System.Console.WriteLine("1. Yes");
            System.Console.WriteLine("2. No");
            var doubleCheckResult = System.Console.ReadLine();

            switch(doubleCheckResult)
                {
                    case "1":
                    {
                        activityLog.DeleteActivityLog();
                        break;
                    }

                    case "2":
                    {
                        break;
                    }
                }
            
        }

    }
}