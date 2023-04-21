using ConfiguringModels.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringModels
{
    [EntityTypeConfiguration(typeof(CompanyConfiguration))]
    internal class Company
    {
        public string? Name { get; set; }
        public int Id { get; set; }
    }
}
