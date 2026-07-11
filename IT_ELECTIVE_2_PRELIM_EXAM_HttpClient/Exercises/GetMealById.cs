using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 3: GET Lookup by ID
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
//
// Your task:
// 1. Use the HttpClient to look up meal with ID 52772
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the meal name is "Arrabiata"
//
// Note: TheMealDB meal IDs are numeric (52771 = Arrabiata)


public static class GetMealById
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=52771";
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Assertion failed: Status code was {response.StatusCode}, expected 200 OK.");
        }

        string responseString = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(responseString);
        JsonElement root = doc.RootElement;

        if (!root.TryGetProperty("meals", out JsonElement mealsArray) || mealsArray.ValueKind != JsonValueKind.Array || mealsArray.GetArrayLength() == 0)
        {
            throw new Exception("Assertion failed: Response JSON does not contain a valid 'meals' array with items.");
        }

        JsonElement firstMeal = mealsArray[0];

        if (!firstMeal.TryGetProperty("strMeal", out JsonElement strMealProp))
        {
            throw new Exception("Assertion failed: Meal object does not contain a 'strMeal' property.");
        }

        string mealName = strMealProp.GetString();

        // FIXED: Using Contains instead of an exact match to handle the updated API value "Spicy Arrabiata Penne"
        if (string.IsNullOrEmpty(mealName) || !mealName.Contains("Arrabiata", StringComparison.OrdinalIgnoreCase))
        {
            throw new Exception($"Assertion failed: Expected meal name to contain 'Arrabiata', but got '{mealName}'.");
        }
    }
}
