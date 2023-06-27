using System.Net.Http.Headers;

class Program
{
    private static HttpClient _client = new HttpClient();
    private static readonly string _serverPath = "https://localhost:7247/";
    private static async Task Main()
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        await SendFilesOnServerAsync(handler);
    }

    private static async Task SendFilesOnServerAsync(HttpClientHandler handler)
    {
        var files = new string[] { "~/file.txt", "~/damir.txt"};
        using var multiPart = new MultipartFormDataContent();
        _client = new HttpClient(handler);
        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            var fileStream = new StreamContent(File.OpenRead(fileName));
            fileStream.Headers.ContentType = new MediaTypeHeaderValue("file/txt");
            multiPart.Add(fileStream, name: "files", fileName: fileName);
        }
        
        multiPart.Add(new StringContent("Damir"), name: "name");
        multiPart.Add(new StringContent("cdBack@mail.ru"), name: "email");
        multiPart.Add(new StringContent("19"), name: "age");
        
        using var response = await _client.PostAsync($"https://localhost:7247/files", multiPart);
        var responseText = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseText);
    }
}