using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 2: GET Search by Name
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?s={name}
//
// Your task:
// 1. Use the HttpClient to search for meals with name "Arrabiata"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "meals" array has at least 1 result
//
// Hint: Use System.Text.Json.JsonDocument.Parse() to parse JSON
// Hint: The response format is { "meals": [...] } — meals can be null if no results

public static class SearchMealByName
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?s=Arrabiata";

        HttpResponseMessage response = await client.GetAsync(url);
       
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Assertion failed: Status code was {response.StatusCode}, expected 200 OK.");
        }

        string responseString = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(responseString);
        JsonElement root = doc.RootElement;

        if (!root.TryGetProperty("meals", out JsonElement mealsArray) || mealsArray.ValueKind != JsonValueKind.Array)
        {
            throw new Exception("Assertion failed: Response JSON does not contain a valid 'meals' array.");
        }

        if (mealsArray.GetArrayLength() < 1)
        {
            throw new Exception("Assertion failed: The 'meals' array does not have at least 1 item.");
        }
    }
}
