using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        string saveFileName = "goals.txt";
        User user = new User(saveFileName);

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("1. Display Goals");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Score");
            Console.WriteLine("4. Add Goal");
            Console.WriteLine("5. Save Goals and Score");
            Console.WriteLine("6. Load Goals and Score");
            Console.WriteLine("7. Quit");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    user.DisplayGoals();
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "2":
                    user.DisplayGoals();
                    Console.Write("Enter the goal number to record event: ");
                    string goalInput = Console.ReadLine();
                    int goalIndex;
                    if (int.TryParse(goalInput, out goalIndex))
                    {
                        user.RecordEvent(goalIndex - 1);
                    }
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "3":
                    user.DisplayScore();
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "4":
                    Console.WriteLine("Select the goal type:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");

                    Console.Write("Enter your choice: ");
                    string goalTypeInput = Console.ReadLine();
                    if (int.TryParse(goalTypeInput, out int goalType))
                    {
                        Console.Write("Enter the goal description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter the goal points: ");
                        string pointsInput = Console.ReadLine();
                        int points;
                        if (int.TryParse(pointsInput, out points))
                        {
                            Goal goal;
                            switch (goalType)
                            {
                                case 1:
                                    goal = new SimpleGoal(description, points);
                                    break;
                                case 2:
                                    goal = new EternalGoal(description, points);
                                    break;
                                case 3:
                                    Console.Write("Enter the target count: ");
                                    string targetCountInput = Console.ReadLine();
                                    int targetCount;
                                    if (int.TryParse(targetCountInput, out targetCount))
                                    {
                                        Console.Write("Enter the bonus points: ");
                                        string bonusPointsInput = Console.ReadLine();
                                        int bonusPoints;
                                        if (int.TryParse(bonusPointsInput, out bonusPoints))
                                        {
                                            goal = new ChecklistGoal(description, points, targetCount, bonusPoints);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid bonus points input. Goal creation failed.");
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid target count input. Goal creation failed.");
                                        continue;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid goal type input. Goal creation failed.");
                                    continue;
                            }

                            user.AddGoal(goal);
                            Console.WriteLine("Goal added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid points input. Goal creation failed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal type input. Goal creation failed.");
                    }
                    break;
                case "5":
                    user.SaveGoalsAndScore();
                    break;
                case "6":
                    user.LoadGoalsAndScore();
                    break;
                case "7":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine();
        }
    }
}