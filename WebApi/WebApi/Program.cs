
var users = new List<Person>()
{
    new Person(){Id = 1,Name = "Damir", Age = 19, Amount = 2000m},
    new Person(){Id = 2,Name = "Liza", Age = 19, Amount = 1000m},
    new Person(){Id = 3,Name = "Kamil", Age = 29, Amount = 3000m},
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/userHost", (HttpContext context) =>
{
    context.Request.Headers.TryGetValue("Host", out var hostHeader);

    return $"host is : {hostHeader}";
});

app.MapGet("/", () => users);

app.MapGet("/userGet{id:int}", (int id) =>
{
    var user = users.FirstOrDefault(x => x.Id == id);
    return user;
});

app.Run();


public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public decimal Amount { get; set; }
}