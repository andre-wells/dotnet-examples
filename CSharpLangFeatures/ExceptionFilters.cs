using System.Net;
using System.Net.Http;

/// <summary>
/// When handling Exeptions, Exception Filters helps to determine 
/// if the Catch clause should be applied to the thrown error. 
/// It's not too different from Pattern Matching.
/// </summary>
class ExceptionFilterDemo
{
    static async Task<string> MakeRequestAsync()
    {
        // just for demo
        var client = new HttpClient();
        try
        {
            return await client.GetStringAsync("http://localhost:5000");
        }
        catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.Moved)
        {
            return "Site Moved.";
        }
        catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.NotModified)
        {
            return "Return cached value instead.";
        }
    }
    
}