using System.Net;
using System.Net.Http.Json;

class Program
{
    private static HttpClient _client = new HttpClient();
    private static string _localPath = "https://localhost:7250";

    private static async Task Main()
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        await UpdateUserInDatabase(new Person{Address = "Address", Age = 20, Id = 2}, handler);
    }

    private static async Task<bool>
        DeleteUserFromDatabase(int id, HttpClientHandler handler)
    {
        _client = new HttpClient(handler);
        using var response = await _client.DeleteAsync($"{_localPath}/users/{id}");
        var result = response.StatusCode;
        return result == HttpStatusCode.OK ? true : false;
    }
    
    private static async Task AddUser(Person person,HttpClientHandler handler)
    {
        _client = new HttpClient(handler);
        using var response = await _client.PostAsJsonAsync($"{_localPath}/users", person);
        Console.WriteLine($"StatusCode: {response.StatusCode}");
    }

    private static async Task<Person> GetUserFromDatabase
        (HttpClientHandler handler, int id)
    {
        _client = new HttpClient(handler);
        using var response = await _client.GetAsync($"{_localPath}/users/{id}");
        var user = await response.Content.ReadFromJsonAsync<Person>();
        return user ?? new Person(){Name = "Not founded"};
    }

    private static async Task UpdateUserInDatabase
        (Person user, HttpClientHandler handler)
    {
        _client = new HttpClient(handler);
        using var response = await _client.PutAsJsonAsync($"{_localPath}/users", user);
        Console.WriteLine($"Status operation: {response.StatusCode}");
    }
}

class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    
    public string? Address { get; set; }
}