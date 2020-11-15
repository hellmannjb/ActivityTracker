using System;
using System.Collections.Generic;

namespace ActivityTracker
{
    public class MainMenu
    {

        const string path = "activity.json";

        ActivityLog activityLog = new ActivityLog();

        //Load activity objects in activity.json for use
        public MainMenu()
        {
            activityLog.LoadActivities(path);
        }

        //Create main menu and display options
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
            //Save activities to activity.json
            activityLog.SaveActivities(path);
        }
        
        //Called if user selects "1" from main menu. Creates new activity object, records user inputs and adds to ActivitiesList
        private void LogActivity()
        {
            Activity activity = new Activity();
            System.Console.WriteLine("Please input the name of the activity.");
            var input = Console.ReadLine();
            activity.Name = input;
            System.Console.WriteLine("How long (minutes) did you perform the activity?");
            activity.Duration = double.Parse(Console.ReadLine());
            System.Console.WriteLine("What was your percieved exertion (1-10)?");
            activity.PerceivedExertion = double.Parse(Console.ReadLine()); 
            activity.timeStamp = DateTime.Now;
            activityLog.Add(activity);
            activity.SummarizeEntry();
        }

        //Called if user selects "2" from main menu. User is presented more options. If user selects "1", activities list is summarized from the past week and displayed. If user selects "2", all activities from activities list are summarized.
        private void ListActivitySummary()
        {
            System.Console.WriteLine("Which activity summary would you like to see?");
            System.Console.WriteLine();
            System.Console.WriteLine("1. This Week's Activities");
            System.Console.WriteLine("2. All Time");
            System.Console.WriteLine("3. Exit");
            var summaryChoice = System.Console.ReadLine();

            switch(summaryChoice)
            {
                case "1":
                {
                    activityLog.WeeklySummary();
                    break;
                }

                case "2":
                {
                    activityLog.AllTimeSummary();
                    break;
                }

                case "3":
                {
                    break;
                }
            }
            
        }

        //Called if user selects "3". Method clears activities from ActivitiesList. User has to confirm.
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