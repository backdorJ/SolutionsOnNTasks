using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owned.Objects
{
    [Owned]
    internal class ProfileUser
    {
        public int Seira { get; set; }
        public int Number { get; set; }
    }
}
