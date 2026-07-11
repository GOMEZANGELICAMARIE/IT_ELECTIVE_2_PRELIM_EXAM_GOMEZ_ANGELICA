namespace IT_ELECTIVE_2_PRELIM_EXAM.Interfaces;

// EXERCISE 9: Interfaces
// IRecipeSearchable defines a contract for any class that can be searched.
// Your task:
// - Ensure MealRecipe (in Models/) implements this interface
// - The implementing class should use the recipe's Title as the search criterion
// - MatchesSearch should return true if the searchTerm is found in the Title (case-insensitive)

public interface IRecipeSearchable
{
    public string Title { get; set; }
    public string Ingredients { get; set; }
    public string Instructions { get; set; }

    public string SearchCriteria => Title;

    public bool MatchesSearch(string searchTerm)
    {
        return Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
    }
}
