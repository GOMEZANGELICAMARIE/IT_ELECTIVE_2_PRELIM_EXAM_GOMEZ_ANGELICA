using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks; 

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 4: GET List Categories
// TheMealDB API: https://themealdb.com/api/json/v1/1/categories.php
//
// Your task:
// 1. Use the HttpClient to fetch all meal categories
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "categories" array has more than 0 items
//
// Response format: { "categories": [{ "strCategory": "Beef", ... }, ...] }

public static class GetCategories
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/categories.php";

        HttpResponseMessage response = await client.GetAsync(url);

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Assertion failed: Status code was {response.StatusCode}, expected 200 OK.");
        }
        string responseString = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(responseString);
        JsonElement root = doc.RootElement;

        if (!root.TryGetProperty("categories", out JsonElement categoriesArray) || categoriesArray.ValueKind != JsonValueKind.Array)
        {
            throw new Exception("Assertion failed: Response JSON does not contain a valid 'categories' array.");
        }

        if (categoriesArray.GetArrayLength() == 0)
        {
            throw new Exception("Assertion failed: The 'categories' array contains 0 items.");
        }
    }
}