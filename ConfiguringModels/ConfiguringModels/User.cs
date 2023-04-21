using ConfiguringModels.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringModels
{
   //[EntityTypeConfiguration(typeof(UserConfiguration))]
    internal class User
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Id { get; set; }
        public string? Gender { get; set; }
        [Column("WorkUser")]
        public Company? Work { get; set; }
    }
}
