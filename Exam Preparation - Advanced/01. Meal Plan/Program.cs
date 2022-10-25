using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> menu = new Dictionary<string, int>()
            {
                ["salad"] = 350,
                ["soup"] = 490,
                ["pasta"] = 680,
                ["steak"] = 790,
            };

            string[] mealsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> meals = new Queue<string>(mealsInput);

            int[] caloriesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> calories = new Stack<int>(caloriesInput);

            int totalMeals = 0;

            while (meals.Any() && calories.Any() && calories.Peek() > 0)
            {
                int dailyCalories = calories.Pop();
                string meal = meals.Dequeue();
                totalMeals++;
                int currentMealCalories = menu[meal];
                dailyCalories -= currentMealCalories;

                while (dailyCalories <= 0)
                {
                    if (!calories.Any()) break;
                    dailyCalories += calories.Pop();
                }
                calories.Push(dailyCalories);
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {totalMeals} meals.");

                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {totalMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
