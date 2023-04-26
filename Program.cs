// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace RecipeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize variables
            int numIngredients;
            List<Ingredient> ingredients = new List<Ingredient>();
            int numSteps;
            List<string> steps = new List<string>();

            // Main loop to display menu
            while (true)
            {
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");

                // Get user input and perform action based on choice
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // Get number of ingredients and iterate to get details
                        Console.Write("Enter number of ingredients: ");
                        numIngredients = int.Parse(Console.ReadLine());
                        for (int i = 0; i < numIngredients; i++)
                        {
                            Console.Write("Enter ingredient name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter quantity: ");
                            double quantity = double.Parse(Console.ReadLine());
                            Console.Write("Enter unit of measurement: ");
                            string unit = Console.ReadLine();
                            ingredients.Add(new Ingredient(name, quantity, unit));
                        }

                        // Get number of steps and iterate to get details
                        Console.Write("Enter number of steps: ");
                        numSteps = int.Parse(Console.ReadLine());
                        for (int i = 0; i < numSteps; i++)
                        {
                            Console.Write($"Enter step {i + 1}: ");
                            steps.Add(Console.ReadLine());
                        }

                        Console.WriteLine("Recipe details saved.");
                        break;
                    case "2":
                        // Display recipe
                        Console.WriteLine("Ingredients:");
                        foreach (Ingredient ingredient in ingredients)
                        {
                            Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
                        }
                        Console.WriteLine("Steps:");
                        for (int i = 0; i < steps.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {steps[i]}");
                        }
                        break;
                    case "3":
                        // Scale recipe
                        Console.Write("Enter scale factor (0.5, 2, or 3): ");
                        double factor = double.Parse(Console.ReadLine());
                        foreach (Ingredient ingredient in ingredients)
                        {
                            ingredient.Quantity *= factor;
                        }
                        Console.WriteLine($"Recipe scaled by a factor of {factor}.");
                        break;
                    case "4":
                        // Reset quantities
                        foreach (Ingredient ingredient in ingredients)
                        {
                            ingredient.ResetQuantity();
                        }
                        Console.WriteLine("Quantities reset to original values.");
                        break;
                    case "5":
                        // Clear all data
                        ingredients.Clear();
                        steps.Clear();
                        Console.WriteLine("All data cleared.");
                        break;
                    case "6":
                        // Exit program
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        // Invalid input
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                Console.WriteLine(); //  blank line for readability
            }
        }
    }

    // Ingredient class to store name, quantity, and unit of measurement
    class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; set; }
        public string Unit { get; }

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        public void ResetQuantity()
        {
            // Set quantity back to 1.0 (original value)
            Quantity = 1.0;
        }
    }
}
