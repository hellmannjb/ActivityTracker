using System;
using System.Collections.Generic;

namespace ActivityTracker
{
    public class Activity
    {

        public void SummarizeEntry()
        {
            System.Console.WriteLine($"Your activity, {Name} has been logged.");
        }
        public string Name {get; set;}
        public double Duration {get; set;}
        public int PerceivedExertion {get; set;}
        

    }
}