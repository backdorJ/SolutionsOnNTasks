using Owned.ApplicationContext;
using Owned.Objects;

class Program
{
    static void Main()
    {
        using (var app = new ApplicationContext())
        {
            var user = new User("Damir", "Nabiullin", 20, new ProfileUser { Number = 11, Seira = 22 });
            app.Users.Add(user);
            app.SaveChanges();

            var users = app.Users.ToList();
            foreach (var item in users)
                Console.WriteLine(item.ToString());
        }
    }
}