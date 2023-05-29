using System;
using System.Collections.Generic;
using System.Linq;

class Recipe
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }
    public List<string> quantity { get; set; }
    public List<string> Steps { get; set; }
    public List<string> Calories { get; set; }
    public string FoodGroup { get; set; }

    public Recipe(string name)
    {
        Name = name;
        quantity = new List<string>();
        Ingredients = new List<string>();
        Steps = new List<string>();
        Calories = new List<string>();
    }
    public class Ingredient
    {

        public string Name { get; set; }
        public string quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
    }



   



    public void AddIngredient(string ingredient)
    {
        Ingredients.Add(ingredient);
    }

    public void AddStep(string step)
    {
        Steps.Add(step);
    }

    public void DisplayRecipe()
    {
        Console.WriteLine("Recipe: " + Name);
        Console.WriteLine("Ingredients:") ;
        foreach (string ingredient in Ingredients)
        {
            Console.WriteLine("- " + ingredient);
        }

        Console.WriteLine("The Quantity that has been placed is: ");
        foreach (string Quantity in Ingredients)
        {
            Console.WriteLine("- " + quantity);
        }


        Console.WriteLine("Steps:");
        foreach (string step in Steps)
        {
            Console.WriteLine("- " + step);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Recipe> recipes = new List<Recipe>();

        while (true)
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Display all recipes");
            Console.WriteLine("3. Exit the Program");
            Console.WriteLine("4. Reset details");
           
            Console.WriteLine();
            Console.ResetColor();
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("Enter the recipe name:");
                string name = Console.ReadLine();
                Recipe recipe = new Recipe(name);

                // Add ingredients
                while (true)
                {
                    Console.WriteLine("Enter an ingredient (or type 'Finish' to end):");
                    string ingredient = Console.ReadLine();
                    if (ingredient == "Finish")
                    {
                        break;
                    }
                    recipe.AddIngredient(ingredient);
                }
                while (true) { 

                    Console.WriteLine("Enter the Quantity of the ingredient");
                    string quantity = Console.ReadLine();

                    recipe.AddIngredient(quantity);
                    break;
                 }
                
                // Add step of making the recipe
                while (true)
                {
                    Console.WriteLine("Enter a step (or type 'Finish' to end):");
                    string step = Console.ReadLine();
                    if (step == "Finish") // stop the current process to allow the next
                    {
                        break;
                    }
                    recipe.AddStep(step); // add steps function
                }

                recipes.Add(recipe);
            }
            else if (input == "2") 
            {
                // Display all recipes to user
                foreach (Recipe recipe in recipes.OrderBy(r => r.Name))
                {
                    Console.WriteLine(recipe.Name);
                }

                // Prompt the user to choose recipe to display
                Console.WriteLine("Enter the name of the recipe you want to display:");
                string recipeName = Console.ReadLine();
                Recipe selectedRecipe = recipes.Find(r => r.Name == recipeName);
                if (selectedRecipe != null)
                {
                    selectedRecipe.DisplayRecipe();
                }
                else 
                {
                    //Sends a error message to the user
                    Console.WriteLine("Invalid recipe! Try again!!.");
                }

               

            }
            else if (input == "3")
            {
                // Exit
                break;
            }
            
            if (input == "4") 
            {
             Console.WriteLine("You have chosen the reset option\n" +
                 "Do you want to clear the recipe?\n" +
                 "Press 1 to clear\n" +
                 "Press 2 to cancel");
                int clear = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Red;
                recipes.Clear();
                Console.WriteLine("You have cleared the recipe: Back to menu");
                Console.ResetColor();
            }

        }
    }

    private static void clearTheRecipe(Recipe recipe, List<Recipe> recipes)
    {
        recipes.Clear();
    }
}