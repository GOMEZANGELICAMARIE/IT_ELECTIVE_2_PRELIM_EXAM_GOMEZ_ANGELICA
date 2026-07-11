using System.Collections.Generic;

namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 7: Inheritance - Base/Derived Classes
// RecipeBase is the base class for all recipe types.
// Your task in MealRecipe and QuickRecipe:
// - Complete the inherited fields by using proper access modifiers
// - Use 'protected' for fields that derived classes need access to

public class RecipeBase
{
    public string Title { get; set; }
    public int PrepTimeMinutes { get; set; }
    public string Difficulty { get; set; }

    protected List<string> steps;

    public RecipeBase()
    {
        Title = "";
        PrepTimeMinutes = 0;
        Difficulty = "Easy";
        steps = new List<string>();
    }

    public RecipeBase(string title, int prepTime, string difficulty)
    {
        Title = title;
        PrepTimeMinutes = prepTime;
        Difficulty = difficulty;
        steps = new List<string>();
    }

    public virtual string GetRecipeInfo()
    {
        return $"Recipe: {Title} | Prep: {PrepTimeMinutes} min | Difficulty: {Difficulty}";
    }

    public virtual void AddStep(string step)
    {
        steps.Add(step);
    }

    public List<string> GetSteps()
    {
        return new List<string>(steps);
    }
}
