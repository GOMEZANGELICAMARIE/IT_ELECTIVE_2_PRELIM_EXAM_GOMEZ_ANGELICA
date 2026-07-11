using System.Net;
using Xunit;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 8: DELETE Remove Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts/{id}
//
// Your task:
// 1. Send a DELETE request to remove post with ID 1
// 2. Assert status code is 200 OK
//
// Hint: Use await client.DeleteAsync(url)

public static class DeleteReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        // Send DELETE request
        var response = await client.DeleteAsync(url);

        // Assert status code is 200 OK
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
