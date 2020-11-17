# Activity Tracker Code Louisville C# Project
## September 2020 Code Louisville C#

## **Overview**

This project was created for the September 2020 C# Code Louisville course.
It is intended to demonstrate the principles taught in the course. 
This project is a C# console application for tracking user input activities. Upon running the application, a menu will display options to the user. The user can add activities (running, swimming, videogaming, etc.) and a few charachteristics about the activity, and return a summary of the activities logged. 

## **Features**

* Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program. 
* Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program. - Activities input by the user are stored in a list and subsequently to a json file for use in the summary methods. 
* Read data from an external file, such as text, JSON, CSV, etc and use that data in your application. - Activities input by the user are stored in a list and subsequently to a json file for use in the summary methods. 
* Use a LINQ query to retrieve information from a data structure (such as a list or array) or file. - The WeeklySummary method in the ActivityLog class uses LINQ to query activities that have been entered within the past week. 

## **Running the Project**
* To run this project, clone the repository locally. Run the application from the ActivityTracker folder (activitytracker/src/ActivityTracker).   
* No additional installs neccessary. 