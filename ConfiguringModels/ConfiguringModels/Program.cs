using ConfiguringModels;
using System.Text.Json;

class Program
{
    private static JsonSerializerOptions json = new JsonSerializerOptions()
    {
        WriteIndented = true,
    };

    static async Task Main()
    {
        var path = Path.Combine(Environment.CurrentDirectory, "js.txt");
        var users = new List<User>
        {
            new User{Name = "Damir", Surname = "Nabiullin", Gender = "Male", Work = new Company{Name = "Google" } },
            new User{Name = "Kamilla", Surname = "Muhamadieva", Gender = "Female"},
            new User{Name = "Shamil", Surname = "Nabiullin", Gender = "Male"},
        }.ToArray();
        await AddPeoples(users);
        await SinhronizeObject(path, users); 
    }

    public static async Task AddPeoples(User[] users)
    {
        await Task.Run(async () =>
        {
            using (var app = new ApplicationContext())
            {
                foreach (var user in users)
                    await app.AddAsync<User>(user);

                await app.SaveChangesAsync();
            }
        });
    }

    public static async Task SinhronizeObject(string path, User[] users)
    {
        await Task.Run(async () =>
        {
            using (var js = new FileStream(path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<User[]>(js, users,json);
            }
        });
    }

}