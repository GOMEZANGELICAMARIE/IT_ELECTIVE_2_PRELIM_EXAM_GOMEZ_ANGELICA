using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 1: GET Random Meal
// TheMealDB API: https://themealdb.com/api/json/v1/1/random.php
//
// Your task:
// 1. Use the HttpClient to send a GET request to the URL above
// 2. Read the response as a string
// 3. Assert that the status code is 200 OK
// 4. Assert that the response body is not null or empty
//
// Hint: Use await client.GetAsync(url) then check response.StatusCode
// Hint: Use await response.Content.ReadAsStringAsync() to get the body

public static class GetRandomMeal
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/random.php";

        // 1. Use the HttpClient to send a GET request to the URL above
        HttpResponseMessage response = await client.GetAsync(url);

        // 3. Assert that the status code is 200 OK
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Assertion failed: Status code was {response.StatusCode}, expected 200 OK.");
        }

        // 2. Read the response as a string
        string responseBody = await response.Content.ReadAsStringAsync();

        // 4. Assert that the response body is not null or empty
        if (string.IsNullOrEmpty(responseBody))
        {
            throw new Exception("Assertion failed: Response body is null or empty.");
        }
    }
}
