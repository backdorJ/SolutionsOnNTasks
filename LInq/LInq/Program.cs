using LInq;
using LInq.LinqObj71;
using LInq.Objects;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        LinqObj93();
    }
    public static void LinqObj93() 
    {
        var listA = new List<(int codePotr, string street, int birthday)>()
        {
            (1,"Lomonosovo", 2004),
            (2, "Pushkina", 2001),
            (3,"Orlovo", 1999),
        };

        var listB = new List<(string category,string country, int arcticul)>()
        {
            ("Games", "Russia", 20),
            ("Products", "USA", 10),
            ("Flowers", "Tokyo", 50),
        };

        var listC = new List<(string nameShop, int codePotr, double discount)>()
        {
            ("Magnit", 1, 10),
            ("M-Video", 2, 20),
            ("FlowerShop", 3, 50),
        };

        var listE = new List<(int codePotr, int arcticul, string nameShop)>()
        {
            (1,20, "Magnit"),
            (2,10,"M-Video"),
            (3, 50, "FlowerShop"),
        };

        var data = from b in listB
                   join e in listE on b.arcticul equals e.arcticul
                   join a in listA on e.codePotr equals a.codePotr
                   join c in listC on a.codePotr equals c.codePotr
                   group new { c.discount, b.country, a.street } by new { b.country, a.street }
                   into g
                   select new
                   {
                       Country = g.Key.country,
                       Street = g.Key.street,
                       MaxSkidka = g.Max(x => x.discount)
                   };
        foreach (var dat in data.OrderBy(x => x.Street).ThenBy(x => x.Country))
        {
            Console.WriteLine($"Страна проживания {dat.Country} | Улица: {dat.Street} | Скидка: {dat.MaxSkidka}");
        }
    } // [+]
    public static void LinqObj82() 
    {
        var listB = new List<(string category, string country, int arcticul)>()
        {
            ("Product", "Russia", 1234),
            ("Games", "USA",       234),
            ("Flowers", "Japan",    14),
        };

        var listD = new List<(int cost, int arcticul, string nameShop)>()
        {
            (1000, 1234, "Magazine-1"),
            (5000, 234, "Magazine-2"),
            (10000, 14, "Magazine-3"),
        };

        var listE = new List<(int arcticul, int code, string nameShop)>()
        {
            (1234, 1, "Magazine-1"),
            (234, 2, "Magazine-2"),
            (234, 2, "Magazine-3"),
            (234, 3, "Magazine-4"),
            (14, 3, "Magazine-3"),
        };

        var employee = from b in listB
                       join d in listD on b.arcticul equals d.arcticul
                       join e in listE on d.arcticul equals e.arcticul
                       select new
                       {
                           Category = b.category,
                           ConsumerCode = e.code,
                           Price = d.cost
                       };
        var data = from empl in employee
                   group empl by empl.ConsumerCode into g
                   select new
                   {
                       ConsumerCode = g.Key,
                       CategoryCount = g.Select(x => x.Category).Distinct().Count(),
                       MaxPrice = g.Max(x => x.Price)
                   };

        var oredredData = from dat in data
                          orderby dat.ConsumerCode descending, dat.MaxPrice
                          select dat;

        foreach (var item in oredredData)
        {
            Console.WriteLine($"CustomersCode: {item.ConsumerCode} CategoryCount: {item.CategoryCount}" +
                $" MaxPrice: {item.MaxPrice}");
        }
    } // [+]
    public static void LinqObj71()
    {
        var list = new List<(int codePotr, int year, string address)>
        {
            (1, 2004, "Address-1"),
            (2, 2002, "Address-2"),
            (3, 2001, "Address-3"),
            (4, 2003, "Address-4"),
            (5, 1998, "Address-5"),
        };

        var list2 = new List<(int codePotr, double discount, string nameShop)>
        {
            (1, 10, "Shop-1"),
            (1, 50, "Shop-2"),
            (2, 20, "Shop-2"),
            (3, 60, "Shop-3"),
            (3, 40, "Shop-1"),
            (4,  5, "Shop-4"),
        };

        var result = from a in list2
                     join c in list on a.codePotr equals c.codePotr
                     group a by a.nameShop into g
                     orderby g.Key ascending
                     let minCode = g.Select(x => x.codePotr).Min()
                     select new
                     {
                         Year = list.Where(x => x.codePotr == minCode).Select(x => x.year).First(),
                         Group = g.Key,
                         CodePotrebitelya = g.Where(x => x.codePotr == minCode)
                         .Select(x => new { Code = x.codePotr, Discount = x.discount }),
                     };

        foreach (var item in result)
        {
            Console.WriteLine($"ShopName: {item.Group} People Year: {item.Year}");
            foreach (var people in item.CodePotrebitelya)
            {
                Console.WriteLine($"Code: {people.Code} Discount: {people.Discount}");
            }
            Console.WriteLine();
        }
    } // [+]
    public static void LinqObj60()
    {
        var list = new List<EGE>
        {
            new EGE{Surname = "Кирова", Initsial = "kas", NumberSchool = 1, PointExam = "90 90 90"},
            new EGE { Surname = "Набиуллин", Initsial = "qweq", NumberSchool = 2, PointExam = "60 60 60" },
            new EGE { Surname = "Лаврентьева", Initsial = "kasdas", NumberSchool = 2, PointExam = "90 90 10" },
            new EGE { Surname = "Шопоголиков", Initsial = "sadass", NumberSchool = 3, PointExam = "10 10 10" },
            new EGE { Surname = "Дудкин", Initsial = "saass", NumberSchool = 3, PointExam = "50 5 10" },
            new EGE { Surname = "Хрянтев    ", Initsial = "ssssas", NumberSchool = 3, PointExam = "90 90 10" },
            new EGE { Surname = "Kukova", Initsial = "ksadasd", NumberSchool = 1, PointExam = "90 20 10" }
        };

        var user = from us in list
                   group us by us.NumberSchool into eGroup
                   let sumMath = eGroup.Select(x => x.PointExam.Split(' ')).Select(x => int.Parse(x[0])).Sum(x => x)
                   let sumRuss = eGroup.Select(x => x.PointExam.Split(' ')).Select(x => int.Parse(x[1])).Sum(x => x)
                   let sumInfo = eGroup.Select(x => x.PointExam.Split(' ')).Select(x => int.Parse(x[2])).Sum(x => x)
                   orderby eGroup.Key descending
                   select new
                   {
                       AvgMath = sumMath / eGroup.Count(),
                       AvgRuss = sumRuss / eGroup.Count(),
                       AvgInfo = sumInfo / eGroup.Count(),
                       SchoolNumber = eGroup.Key
                   };
        foreach (var item in user)
            Console.WriteLine($"School number: {item.SchoolNumber} | AvgMath: {item.AvgMath} " +
                $"| AvgRuss: {item.AvgRuss} | AvgInfo: {item.AvgInfo}");
    } // [+]
    public static void LinqObj52()
    {
        var list = new List<EGE>
        {
            new EGE{Surname = "Кирова", Initsial = "kas", NumberSchool = 1, PointExam = "90 90 90"},
            new EGE { Surname = "Набиуллин", Initsial = "qweq", NumberSchool = 2, PointExam = "60 60 60" },
            new EGE { Surname = "Лаврентьева", Initsial = "kasdas", NumberSchool = 2, PointExam = "90 90 10" },
            new EGE { Surname = "Шопоголиков", Initsial = "sadass", NumberSchool = 3, PointExam = "10 10 10" },
            new EGE { Surname = "Дудкин", Initsial = "saass", NumberSchool = 3, PointExam = "50 5 10" },
            new EGE { Surname = "Хрянтев    ", Initsial = "ssssas", NumberSchool = 3, PointExam = "90 90 10" },
            new EGE { Surname = "Kukova", Initsial = "ksadasd", NumberSchool = 1, PointExam = "90 20 10" }
        };

        var users = from user in list
                    group user by user.NumberSchool into eGroup
                    let minSumPoint = eGroup.Min(x => x.PointExam)
                    let minPoint = eGroup
                    .Where(x => x.PointExam == minSumPoint)
                    .Select(x => x.PointExam.Split(' '))
                    .SelectMany(x => x)
                    .Select(x => int.Parse(x))
                    .Sum()
                    select new
                    {
                        NumberSchool = eGroup.Key,
                        Insial = eGroup
                        .Where(x => x.PointExam == minSumPoint)
                        .Select(x => new { x.Surname, x.Initsial })
                        .OrderBy(x => x.Surname).ThenBy(x => x.Initsial),
                        SumPoint = minPoint
                    };

        foreach (var user in users)
        {
            Console.WriteLine($"Number School: {user.NumberSchool}, MinPoint: {user.SumPoint}");
            foreach (var item in user.Insial)
            {
                Console.WriteLine($"Surname: {item.Surname.PadRight(20)} Initsial: {item.Initsial}");
            }
            Console.WriteLine();
        }

    } // [+]
    public static void LinqObj49()
    {
        var list = new List<EGE>
        {
            new EGE{Surname = "Кирова", Initsial = "kas", NumberSchool = 1, PointExam = "90 90 90"},
            new EGE { Surname = "Набиуллин", Initsial = "qweq", NumberSchool = 2, PointExam = "60 60 60" },
            new EGE { Surname = "Лаврентьева", Initsial = "kasdas", NumberSchool = 2, PointExam = "90 90 10" },
            new EGE { Surname = "Шопоголиков", Initsial = "sadass", NumberSchool = 3, PointExam = "10 10 10" },
            new EGE { Surname = "Дудкин", Initsial = "saass", NumberSchool = 3, PointExam = "50 5 10" },
            new EGE { Surname = "Хрянтев    ", Initsial = "ssssas", NumberSchool = 3, PointExam = "90 90 10" },
            new EGE { Surname = "Kukova", Initsial = "ksadasd", NumberSchool = 1, PointExam = "90 20 10" }
        };

        #region
        var point = from user in list
                    group user by user.NumberSchool into eGroup
                    let minBall = eGroup.Min(x => x.PointExam)
                    let sumBall = eGroup.Where(x => x.PointExam == minBall)
                    .Select(x => x.PointExam.Split(' '))
                    .SelectMany(x => x).Select(x => int.Parse(x)).Sum(x => x)
                    orderby eGroup.Key
                    select new
                    {
                        IdSchool = eGroup.Key,
                        Ball = eGroup
                        .Where(x => x.PointExam == minBall)
                        .Select(x => new { x.Surname, x.PointExam, x.Initsial }),
                        Sum = sumBall
                    };
        #endregion

        foreach (var empl in point)
        {
            Console.WriteLine($"IdSchool: {empl.IdSchool} MinSumPoints: {empl.Sum}");
            foreach (var info in empl.Ball)
            {
                Console.WriteLine($"Surname: {info.Surname}" +
                    $" Point On three Exam: {info.PointExam} Initsial Person: {info.Initsial}");
            }
        }


    } // [+]
    public static void LinqObj38()
    {
        var list = new List<AZS>
        {
            new AZS{CostOneLitr = 46,MurkbBenzo = 92, Company = "Tatneft", Street = "Pushkino" },
            new AZS{CostOneLitr = 40,MurkbBenzo = 92, Company = "Tatneft", Street = "Kozlovo" },
            new AZS{CostOneLitr = 60,MurkbBenzo = 95, Company = "Lukoil", Street = "Kolotushkino" },
            new AZS{CostOneLitr = 90,MurkbBenzo = 98, Company = "Lukoil", Street = "Vaskino" },
            new AZS{CostOneLitr = 30,MurkbBenzo = 95, Company = "Lukoil", Street = "Joj" },
        };

        var benzo = from benz in list
                    group benz by benz.MurkbBenzo into eGroup
                    let stashion = eGroup.Where(x => x.MurkbBenzo > 0).Count()
                    orderby stashion ascending, eGroup.Key
                    select new
                    {
                        Number = eGroup.Key,
                        Count = stashion
                    };
        foreach (var item in benzo)
        {
            Console.WriteLine($"Mark: {item.Number} | Count: {item.Count}");
        }

    } // [+]
    public static void LinqObj27()
    {
        var list = new List<Debtor>
        {
            new Debtor{Surname = "Kozlov", NumberRoom = 1, Arrears = 10.25},
            new Debtor{Surname = "Nabiullin", NumberRoom = 2, Arrears = 0.90},
            new Debtor{Surname = "Ivanov", NumberRoom = 3, Arrears = 11.25},
            new Debtor{Surname = "Typaev", NumberRoom = 1, Arrears = 15.25},
            new Debtor{Surname = "Иванов", NumberRoom = 112, Arrears = 150.25},
            new Debtor{Surname = "Маринов", NumberRoom = 102, Arrears = 150.25},
            new Debtor{Surname = "Картинов", NumberRoom = 30, Arrears = 150.25},
            new Debtor{Surname = "Умиротверениев", NumberRoom = 40, Arrears = 150.25},
            new Debtor{Surname = "Хз", NumberRoom = 20, Arrears = 150.25},

        };

        // (x.Item2 - 1) / 4 + 1

        var users = from user in list
                    let ground = ((user.NumberRoom - 1) / 4 + 1) % 9
                    group user by ground into eGroup
                    let ground = eGroup.Key
                    select new
                    {
                        Count = eGroup.Count(x => x.Arrears > 0),
                        Ground = ground,
                        Cost = eGroup.Where(x => x.Arrears > 0).Sum(x => x.Arrears)
                    };
        var peoples = users.OrderByDescending(x => x.Count).ThenBy(x => x.Ground);
        foreach (var item in peoples)
        {
            Console.WriteLine($"Кол-во должников: {item.Count} | Этаж: {item.Ground} | Задолжность: {item.Cost:F2}");
        }
    } // [+]
    public static void LinqObj16()
    {
        var list = new List<Abitura>
        {
            new Abitura{Year = 2000, Surname = "Nabiullin", NumberSchool = 1},
            new Abitura{Year = 2001, Surname = "Kozlow", NumberSchool = 12},
            new Abitura{Year = 2000, Surname = "Typaev", NumberSchool = 11},
            new Abitura{Year = 2001, Surname = "Ivanov", NumberSchool = 10},
            new Abitura{Year = 2000, Surname = "Petrow", NumberSchool = 112},
        };

        var collection = from user in list
                         group user by user.Year into eGroup
                         let countAbiutura = eGroup.Count()
                         let info = eGroup.First()
                         orderby countAbiutura descending, eGroup.Key ascending
                         select new { Year = eGroup.Key, Count = countAbiutura };

        foreach (var item in collection)
        {
            Console.WriteLine($"Count Abituries: {item.Count} | Year: {item.Year}");
        }
    } // [+]
    public static void LinqObj8(int k)
    {
        var list = new List<Client>()
        {
            new Client { Code = 1, HourWork = 20, Month = 2, Year = 2004 },
            new Client { Code = 1, HourWork = 20, Month = 1, Year = 2007 },
            new Client { Code = 2, HourWork = 10, Month = 4, Year = 2005 },
            new Client { Code = 2, HourWork = 20, Month = 3, Year = 2005 },
            new Client { Code = 3, HourWork = 0, Month = 5, Year = 2002 },
            new Client{ Code = 4}
        };

        var collection = from user in list
                         where user.Code == k
                         group user by user.Year into eGroup
                         select new
                         {
                             Year = eGroup.Key,
                             Month = eGroup.Where(x => x.HourWork > 0).OrderBy(x => x.HourWork)
                             .ThenBy(x => x.Year).ThenBy(x => x.Month).FirstOrDefault()
                         };
        var result = collection.FirstOrDefault();
        foreach (var item in collection)
        {
            Console.WriteLine($"Hour: {item.Month.HourWork} Year: {item.Year} Month: {item.Month.Month}");
        }

    }
    public static void LinqObj7(int k)
    {
        var list = new List<Client>()
        {
            new Client { Code = 1, HourWork = 20, Month = 2, Year = 2004 },
            new Client { Code = 1, HourWork = 20, Month = 1, Year = 2007 },
            new Client { Code = 2, HourWork = 10, Month = 4, Year = 2005 },
            new Client { Code = 2, HourWork = 20, Month = 3, Year = 2005 },
            new Client { Code = 3, HourWork = 0, Month = 5, Year = 2002 },
            new Client{ Code = 4}
        };

        var code = from user in list
                   group user by user.Code into eGroup
                   let hour = eGroup.Max(x => x.HourWork)
                   let tempMonth = eGroup.Min(x => x.Month)
                   let month = eGroup.FirstOrDefault(x => x.HourWork == hour && x.Month == tempMonth)
                   orderby month.Year descending
                   select new
                   {
                       Code = eGroup.Key,
                       Hour = hour,
                       Month = month.Month,
                       Year = month.Year,
                   };
        var result = code.Where(x => x.Code == k);
        foreach (var cod in result)
        {
            if (cod == null
                || cod.Month == 0) Console.WriteLine("Сведения о данном пользователе отсутсвуют");
            else Console.WriteLine($"Code: {cod.Code} | MaxHour: {cod.Hour} | Month: {cod.Month}" +
                    $" | Year: {cod.Year}");
        }
    }
    public static void LinqObj6()
    {
        var list = new List<Client>()
        {
            new Client { Code = 1, HourWork = 10, Month = 1, Year = 2004 },
            new Client { Code = 1, HourWork = 20, Month = 1, Year = 2004 },
            new Client { Code = 2, HourWork = 10, Month = 4, Year = 2005 },
            new Client { Code = 2, HourWork = 20, Month = 4, Year = 2005 },
            new Client { Code = 3, HourWork = 0, Month = 5, Year = 2002 },
        };

        var groupMonyth = from month in list
                          group month by month.Month into eGroup
                          let hours = eGroup.Sum(x => x.HourWork)
                          orderby hours descending, eGroup.Key
                          select new
                          {
                              Month = eGroup.Key,
                              Hour = hours
                          };

        foreach (var month in groupMonyth)
        {
            if (month.Hour == 0) Console.WriteLine($"Month: {month.Month} | Hour: {0}");
            else Console.WriteLine($"Month: {month.Month} | Hour: {month.Hour}");
        }
    }
    public static void LinqObj5()
    {
        var list = new List<Client>()
        {
            new Client { Code = 1, HourWork = 10, Month = 1, Year = 2004 },
            new Client { Code = 1, HourWork = 20, Month = 3, Year = 2004 },
            new Client { Code = 2, HourWork = 10, Month = 4, Year = 2005 },
            new Client { Code = 2, HourWork = 20, Month = 4, Year = 2005 },
            new Client { Code = 3, HourWork = 1, Month = 5, Year = 2002 },
        };
        var monthsGroup = from user in list
                          group user by user.Code into eGroup
                          let sumMonth = eGroup.Count()
                          orderby sumMonth, eGroup.Key
                          select new
                          {
                              sumMonths = sumMonth,
                              Code = eGroup.Key,
                          };
        foreach (var user in monthsGroup)
            Console.WriteLine($"Code: {user.Code} Month: {user.sumMonths}");
    } // [+]
    public static void LinqObj4()
    {
        var list = new List<Client>()
        {
            new Client { Code = 1, HourWork = 10, Month = 1, Year = 2004 },
            new Client { Code = 1, HourWork = 20, Month = 3, Year = 2004 },
            new Client { Code = 2, HourWork = 10, Month = 4, Year = 2005 },
            new Client { Code = 2, HourWork = 20, Month = 4, Year = 2005 },
            new Client { Code = 3, HourWork = 1, Month = 5, Year = 2002 },
        };

        var year = from item in list
                   group item by item.Code into eGroup
                   let time = eGroup.Sum(x => x.HourWork)
                   orderby time descending, eGroup.Key ascending
                   select new
                   {
                       Time = time,
                       COde = eGroup.Key,
                   };
        foreach (var item in year)
        {
            Console.WriteLine("{0}, {1}", item.COde, item.Time);
        }
    }
    public static void LinqObj3()
    {
        var list = new List<Client>()
        {
            new Client { Code = 1, HourWork = 10, Month = 1, Year = 2004 },
            new Client { Code = 2, HourWork = 20, Month = 3, Year = 2004 },
            new Client { Code = 3, HourWork = 10, Month = 4, Year = 2005 },
            new Client { Code = 4, HourWork = 20, Month = 4, Year = 2005 },
            new Client { Code = 5, HourWork = 1, Month = 5, Year = 2002 },
        };

        var year = from item in list
                   group item by item.Year into yearGroup
                   let time = yearGroup.Sum(x => x.HourWork)
                   orderby time ascending, yearGroup.Key
                   select new
                   {
                       Year = yearGroup.Key,
                       Time = time
                   };
        var first = year.Max(x => x.Time);
        var result = year.Where(x => x.Time == first).Min(x => x.Year);
        Console.WriteLine(result);
    }
    public static void LinqObj2()
    {
        var list = new List<Client>()
        {
            new Client { Code = 1, HourWork = 10, Month = 1, Year = 2004 },
            new Client { Code = 2, HourWork = 20, Month = 3, Year = 2005 },
            new Client { Code = 3, HourWork = 9, Month = 4, Year = 2006 },
            new Client { Code = 4, HourWork = 30, Month = 4, Year = 2007 },
            new Client { Code = 5, HourWork = 30 , Month = 5, Year = 2009 },
        };

        var maxElement = list.Max(x => x.HourWork);
        var element = list.LastOrDefault(x => x.HourWork == maxElement);
        Console.WriteLine($"Hour: {element?.HourWork} Code: {element?.Code} Month: {element?.Month}" +
            $" Year: {element?.Year}");
    }
    public static void LinqObj1()
    {
        var list = new List<Client>
        {
            new Client{Code = 1, HourWork = 10, Month = 1, Year = 2004},
            new Client{Code = 2, HourWork = 20, Month = 3, Year = 2005},
            new Client{Code = 3, HourWork = 9, Month = 4, Year = 2006},
            new Client{Code = 4, HourWork = 30, Month = 4, Year = 2007},
            new Client{Code = 5, HourWork = 9, Month = 5, Year = 2009},
        };

        var minFirstElement = list.Min(x => x.HourWork);
        var client = list.LastOrDefault(x => x.HourWork == minFirstElement);
        Console.WriteLine($"{client.Code} {client.HourWork} {client.Month}");
    }
}