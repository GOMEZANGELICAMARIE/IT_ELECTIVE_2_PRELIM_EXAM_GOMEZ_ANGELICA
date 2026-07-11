using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 10: GET Deserialize Multiple Meals
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?f=a
//
// This endpoint returns ALL meals starting with the letter "a".
//
// Your task:
// 1. Use the HttpClient to fetch meals starting with letter "a"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and get the "meals" array
// 4. Assert the array has more than 0 items
// 5. Loop through each meal and print its name (strMeal)
//
// Response format:
// {
//   "meals": [
//     { "idMeal": "52772", "strMeal": "Arrabiata", ... },
//     { "idMeal": "52781", "strMeal": "Ayam Percik", ... },
//     ...
//   ]
// }

public static class DeserializeMeals
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?f=a";

        // 1. Use the HttpClient to fetch meals starting with letter "a"
        HttpResponseMessage response = await client.GetAsync(url);

        // 2. Assert status code is 200 OK
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Assertion failed: Status code was {response.StatusCode}, expected 200 OK.");
        }

        // 3. Parse the JSON
        string responseString = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(responseString);
        JsonElement root = doc.RootElement;

        // 4. Get the "meals" array
        if (!root.TryGetProperty("meals", out JsonElement mealsArray) || mealsArray.ValueKind != JsonValueKind.Array)
        {
            throw new Exception("Assertion failed: Response JSON does not contain a 'meals' array.");
        }

        int count = mealsArray.GetArrayLength();

        // Assert the array has more than 0 items
        if (count == 0)
        {
            throw new Exception("Assertion failed: 'meals' array contains 0 items.");
        }

        // 5. Loop through each meal and print its name (strMeal)
        foreach (JsonElement meal in mealsArray.EnumerateArray())
        {
            if (meal.TryGetProperty("strMeal", out JsonElement strMealProp))
            {
                Console.WriteLine($"Meal Name: {strMealProp.GetString()}");
            }
        }
    }
}
