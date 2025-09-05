using Newtonsoft.Json;

namespace Data;

public static class ResponseConverter
{
    public static async Task<List<T>> ToNeededResponse<TR, T>(HttpResponseMessage responseMessage)
    {
        responseMessage.EnsureSuccessStatusCode();
        var stringResponse = await responseMessage.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<TR>(stringResponse);
        
        var resultProperty = typeof(TR).GetProperty("Result");
        var resultValue = resultProperty?.GetValue(response);
        
        if (resultValue is List<T> resultList)
        {
            return resultList;
        }
    
        throw new InvalidOperationException($"Result property is not of type List<{typeof(T).Name}>");
    }
}