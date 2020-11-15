using System;

namespace ActivityTracker
{ 
    //Activity is the object that users log
    public class Activity
    {
        //When user logs activity, it is confirmed with the following method
        public void SummarizeEntry()
        {
            System.Console.WriteLine($"Your activity, {Name} has been logged.");
        }

        //Activity fields
        public string Name {get; set;}
        public double Duration {get; set;}
        public double PerceivedExertion {get; set;}
        public DateTime timeStamp {get; set;}
        

    }
}