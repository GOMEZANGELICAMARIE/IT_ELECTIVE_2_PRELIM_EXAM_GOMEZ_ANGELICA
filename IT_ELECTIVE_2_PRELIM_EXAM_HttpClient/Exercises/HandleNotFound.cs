using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 9: GET Handle 404 Not Found
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
//
// Your task:
// 1. Use the HttpClient to look up a meal with an ID that doesn't exist (ID 999999)
// 2. Assert the HTTP status code is 200 OK (TheMealDB always returns 200)
// 3. Parse the JSON and assert that the "meals" field is null
//    (meaning no meal was found for that ID)
//
// This teaches: APIs can return 200 OK but still indicate "not found"
// in the response body via null data.

public static class HandleNotFound
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=999999";

        // 1. Use the HttpClient to look up a meal with an ID that doesn't exist (ID 999999)
        HttpResponseMessage response = await client.GetAsync(url);

        // 2. Assert the HTTP status code is 200 OK
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Assertion failed: Status code was {response.StatusCode}, expected 200 OK.");
        }

        // 3. Parse the response JSON
        string responseString = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(responseString);
        JsonElement root = doc.RootElement;

        // Assert that the "meals" field exists and is explicitly null
        if (!root.TryGetProperty("meals", out JsonElement mealsProp) || mealsProp.ValueKind != JsonValueKind.Null)
        {
            throw new Exception("Assertion failed: The 'meals' field is not null.");
        }
    }
}
