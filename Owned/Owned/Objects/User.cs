using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owned.Objects
{
    internal class User
    {
        public User(string name, string surname, int age, ProfileUser obj)
        {
            this.Name = name; this.Surname = surname; this.Age = Age; Portfolio = obj;
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        private ProfileUser? Portfolio { get; set; }

        public override string ToString()
        => $"Name: {Name} Surname: {Surname} Age: {Age} Seria: {Portfolio?.Seira}";
    }
}
