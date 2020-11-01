using System;
using System.Collections.Generic;

namespace ActivityTracker
{
    class Program
    {
        static void Main(string[] args)        
        {

            ActivityLog activityLog = new ActivityLog();
            MainMenu mainMenu = new MainMenu();
            mainMenu.DisplayMenu();
            //activityLog.Add(activity);
        }
    }
}
