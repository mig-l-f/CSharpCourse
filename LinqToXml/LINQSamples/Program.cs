using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LINQSamples.Model;
using System.Xml.Linq;

namespace LINQSamples
{
    class Program
    {
        static XElement root = null;

        static void Main(string[] args)
        {
            root = XElement.Load("../../Data/Lists.xml");

            //MethodBasedSelect();

            //MethodBasedAggregateFunctions();
            ////MethodBasedProjectionV1();
            DistinctCodeLab();
            Console.WriteLine(" ");
            XmlDistinctCodeLab();

            Console.Read();
        }

        #region Method Based Queries


        static void MethodBasedSelect()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod());
            // or
            // Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

            int[] myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Lamda expression as argument to Where()
            // read as "i goes to (i%2)==0", i.e. i is
            // a boolean.
            // The name of the value doesn't matter.
            var evenNumbers = myArray.Where(i => i % 2 == 0);
                              
            foreach (int i in evenNumbers)
            {
                Console.WriteLine(i);
            }
        }

        static void MethodBasedAggregateFunctions()
        {
            int[] myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int count = myArray.Where(i => i % 2 == 0).Count();
            Console.WriteLine("Count() returns: {0}", count);

            double average = myArray.Where(i => i % 2 == 0).Average();
            Console.WriteLine("Average() returns: {0}", average);

            int sum = myArray.Where(i => i % 2 == 0).Sum();
            Console.WriteLine("Sum() returns: {0}", sum);

            int first = myArray.Where(i => i % 2 == 0).First();
            Console.WriteLine("First() returns: {0}", first);

            int last = myArray.Where(i => i % 2 == 0).Last();
            Console.WriteLine("Last() returns: {0}", last);

            int min = myArray.Where(i => i % 2 == 0).Min();
            Console.WriteLine("Min returns: {0}", min);

            int max = myArray.Where(i => i % 2 == 0).Max();
            Console.WriteLine("Max() returns: {0}", max);
        }

        static void MethodBasedRetrieveEvenNumberGT5V1()
        {
            int[] myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = myArray.Where(i => i % 2 == 0 && i > 5);
                              
            foreach (int i in evenNumbers)
            {
                Console.WriteLine(i);
            }
        }

        static void MethodBasedRetrieveEvenNumberGT5V2()
        {
            int[] myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = myArray.Where(i => i % 2 == 0).Where(i => i > 5);
                              
            foreach (int i in evenNumbers)
            {
                Console.WriteLine(i);
            }
        }

        static void MethodBasedRetrieveEvenNumberGT5V3()
        {
            int[] myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = myArray.Where(i => IsEvenAndGT5(i));
                              
            foreach (int i in evenNumbers)
            {
                Console.WriteLine(i);
            }
        }

        static void MethodBasedOrderEvenNumbers()
        {
            int[] myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = myArray.Where(i => i % 2 == 0).OrderByDescending(i => i);
                              
            foreach (int i in evenNumbers)
            {
                Console.WriteLine(i);
            }
        }

        //static void MethodBasedOrderByStateThenCity()
        //{
        //    var hometowns = new List<Hometown>() 
        //    {
        //        new Hometown() { City = "Philadelphia", State = "PA" },
        //        new Hometown() { City = "Ewing", State = "NJ" },
        //        new Hometown() { City = "Havertown", State = "PA" },
        //        new Hometown() { City = "Fort Washington", State = "PA" },                
        //        new Hometown() { City = "Trenton", State = "NJ" }
        //    };

        //    var orderedHometowns = hometowns.OrderBy(h => h.State).ThenBy(h => h.City);

        //    foreach (Hometown hometown in orderedHometowns)
        //    {
        //        Console.WriteLine(hometown.City + ", " + hometown.State);
        //    }

        //}

        static void XmlMethodBasedOrderByStateThenCity()
        {
            IEnumerable<XElement> orderedHometows =
                from element in root.Element("Hometowns").Elements("Hometown")
                let city = (string)element.Element("City")
                let state = (string)element.Element("State")
                orderby state, city
                select element;            

            foreach (XElement el in orderedHometows)
                Console.WriteLine(el.Element("City").Value + ", " + el.Element("State").Value);
        }

        //static void MethodBasedProjectionV1()
        //{
        //    var people = new List<Person>()
        //    {
        //        new Person() { FirstName = "John", LastName = "Smith", Address1 = "First St", City = "Havertown", State = "PA", Zip = "19084" },
        //        new Person() { FirstName = "Jane", LastName = "Doe", Address1 = "Second St", City = "Ewing", State = "NJ", Zip = "08560" },
        //        new Person() { FirstName = "Jack", LastName = "Jones", Address1 = "Third St", City = "Ft Washington", State = "PA", Zip = "19034" }
        //    };

        //    var lastNames = people.Select(p => p.LastName);
                            
        //    foreach (string lastName in lastNames)
        //    {
        //        Console.WriteLine(lastName);
        //    }
        //}

        static void XmlMethodBasedProjectionV1()
        {
            var lastNames =
                from element in root.Element("People").Elements("Person")
                let lastName = (string)element.Element("LastName")
                select lastName;

            foreach (string lastName in lastNames)
            {
                Console.WriteLine(lastName);
            }

        }

        //static void MethodBasedProjectionV2()
        //{
        //    var people = new List<Person>()
        //    {
        //        new Person() 
        //        { 
        //            FirstName = "John", 
        //            LastName = "Smith", 
        //            Address1 = "First St", 
        //            City = "Havertown", 
        //            State = "PA", 
        //            Zip = "19084" 
        //        },
        //        new Person() 
        //        { 
        //            FirstName = "Jane", 
        //            LastName = "Doe", 
        //            Address1 = "Second St", 
        //            City = "Ewing", 
        //            State = "NJ", 
        //            Zip = "08560" 
        //        },
        //        new Person() 
        //        { 
        //            FirstName = "Jack", 
        //            LastName = "Jones", 
        //            Address1 = "Third St", 
        //            City = "Ft Washington", 
        //            State = "PA", 
        //            Zip = "19034" 
        //        }
        //    };

        //    var names = people.Select(p => new { p.FirstName, p.LastName });

        //    foreach (var name in names)
        //    {
        //        Console.WriteLine(name.FirstName + ", " + name.LastName);
        //    }
        //}

        static void XmlMethodBasedProjectionV2()
        {
            var names = 
                from element in root.Element("People").Elements("Person")
                let firstName = (string)element.Element("FirstName")
                let lastName = (string)element.Element("LastName")
                orderby lastName ascending
                select new
                {
                   FirstName = firstName, 
                   LastName = lastName
                };

            foreach (var name in names)
            {
                Console.WriteLine(name.FirstName + ", " + name.LastName);
            }
        }

        //static void MethodBasedProjectionV3()
        //{
        //    var people = new List<Person>()
        //    {
        //        new Person() { FirstName = "John", LastName = "Smith", Address1 = "First St", City = "Havertown", State = "PA", Zip = "19084" },
        //        new Person() { FirstName = "Jane", LastName = "Doe", Address1 = "Second St", City = "Ewing", State = "NJ", Zip = "08560" },
        //        new Person() { FirstName = "Jack", LastName = "Jones", Address1 = "Third St", City = "Ft Washington", State = "PA", Zip = "19034" }
        //    };

        //    var names = people.Select(p => new { First = p.FirstName, Last = p.LastName });

        //    foreach (var name in names)
        //    {
        //        Console.WriteLine(name.First + ", " + name.Last);
        //    }
        //}

        static void XmlMethodBasedProjectionV3()
        {
            var names =
                from p in root.Element("People").Elements("Person")
                select new
                {
                    First = (string)p.Element("FirstName"),
                    Last = (string)p.Element("LastName")
                };
            foreach (var name in names)
            {
                Console.WriteLine(name.First + ", " + name.Last);
            }
        }

        //static void MethodBasedProjectionV4()
        //{
        //    var employees = new List<Employee>()
        //    {
        //        new Employee() 
        //        { 
        //            FirstName = "John", 
        //            LastName = "Smith", 
        //            StateId = 1 
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jane", 
        //            LastName = "Doe", 
        //            StateId = 2 
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "John", 
        //            LastName = "Smith", 
        //            StateId = 1 
        //        }
        //    };

        //    List<State> states = new List<State>()
        //    {
        //        new State()
        //        {
        //            StateId = 1,
        //            StateName = "PA"
        //        },
        //        new State()
        //        {
        //            StateId = 2,
        //            StateName = "NJ"
        //        }
        //    };

        //    var employeeByState = employees.SelectMany(e => states.Where(s => e.StateId == s.StateId).Select(s => new { e.LastName, s.StateName }));

        //    foreach (var employee in employeeByState)
        //    {
        //        Console.WriteLine(employee.LastName + ", " + employee.StateName);
        //    }
        //}

        static void XmlMethodBasedProjectionV4()
        {
            var employeeByState =
                from e in root.Element("Employees").Elements("Employee")
                from s in root.Element("States").Elements("State")
                where (int)e.Element("StateId") == (int)s.Element("StateId")
                select new
                {
                    LastName = (string)e.Element("LastName"),
                    StateName = (string)s.Element("StateName")
                };

            foreach (var employee in employeeByState)
            {
                Console.WriteLine(employee.LastName + ", " + employee.StateName);
            }
        }

        //static void MethodBasedJoin()
        //{
        //    var employees = new List<Employee>()
        //    {
        //        new Employee() 
        //        { 
        //            FirstName = "John", 
        //            LastName = "Smith", 
        //            StateId = 1 
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jane", 
        //            LastName = "Doe", 
        //            StateId = 2 
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "John", 
        //            LastName = "Smith", 
        //            StateId = 1 
        //        }
        //    };

        //    var states = new List<State>()
        //    {
        //        new State()
        //        {
        //            StateId = 1,
        //            StateName = "PA"
        //        },
        //        new State()
        //        {
        //            StateId = 2,
        //            StateName = "NJ"
        //        }
        //    };

        //    var employeeByState = employees.Join(states, 
        //                                         e => e.StateId, 
        //                                         s => s.StateId, 
        //                                         (e, s) => new { e.LastName, s.StateName });

        //    foreach (var employee in employeeByState)
        //    {
        //        Console.WriteLine(employee.LastName + ", " + employee.StateName);
        //    }
        //}

        static void XmlMethodBasedJoin()
        {
            var employeeByState =
                from e in root.Element("Employees").Elements("Employee")
                join s in root.Element("States").Elements("State") on (int)e.Element("StateId") equals (int)s.Element("StateId")
                select new {
                    LastName = (string)e.Element("LastName"),
                    StateName = (string)s.Element("StateName")
                };
            foreach (var employee in employeeByState)
            {
                Console.WriteLine(employee.LastName + ", " + employee.StateName);
            }
        }

        //static void MethodBasedOuterJoin()
        //{
        //    var employees = new List<Employee>()
        //    {
        //        new Employee() 
        //        { 
        //            FirstName = "John", 
        //            LastName = "Smith", 
        //            StateId = 1 
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jane", 
        //            LastName = "Doe", 
        //            StateId = 2 
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jack", 
        //            LastName = "Jones", 
        //            StateId = 1 
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Sue", 
        //            LastName = "Smith", 
        //            StateId = 3 
        //        }
        //    };

        //    var states = new List<State>()
        //    {
        //        new State()
        //        {
        //            StateId = 1,
        //            StateName = "PA"
        //        },
        //        new State()
        //        {
        //            StateId = 2,
        //            StateName = "NJ"
        //        }
        //    };

        //    var employeeByState = employees.GroupJoin(states,
        //                                                e => e.StateId,
        //                                                s => s.StateId,
        //                                                (e, employeeGroup) => employeeGroup.Select(s => new { LastName = e.LastName, StateName = s.StateName }).DefaultIfEmpty(new { LastName = e.LastName, StateName = "" })).SelectMany(e => e);

        //    foreach (var employee in employeeByState)
        //    {
        //        Console.WriteLine(employee.LastName + ", " + employee.StateName);
        //    }
        //}

        static void XmlMethodBasedOuterJoin()
        {
            var employeeByState =
                from e in root.Element("Employees").Elements("Employee")
                join s in root.Element("States").Elements("State") on (int)e.Element("StateId") equals (int)s.Element("StateId") into selected_states
                from subset_states in selected_states.DefaultIfEmpty()
                select new
                {
                    LastName = (string)e.Element("LastName"),
                    StateName = (subset_states == null ? String.Empty : (string)subset_states.Element("StateName"))
                };
            foreach (var employee in employeeByState)
            {
                Console.WriteLine(employee.LastName + ", " + employee.StateName);
            }
        }

        //static void MethodBasedCompositeKey()
        //{
        //    var employees = new List<Employee>()
        //    {
        //        new Employee() 
        //        { 
        //            FirstName = "John", 
        //            LastName = "Smith", 
        //            City = "Havertown",
        //            State = "PA"
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jane", 
        //            LastName = "Doe", 
        //            City = "Ewing",
        //            State = "NJ"
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jack", 
        //            LastName = "Jones", 
        //            City = "Fort Washington",
        //            State = "PA"
        //        }
        //    };

        //    var hometowns = new List<Hometown>()
        //    {
        //        new Hometown()
        //        {
        //            City = "Havertown",
        //            State = "PA",
        //            CityCode = "1234"
        //        },
        //        new Hometown()
        //        {
        //            City = "Ewing",
        //            State = "NJ",
        //            CityCode = "5678"
        //        },
        //        new Hometown()
        //        {
        //            City = "Fort Washington",
        //            State = "PA",
        //            CityCode = "9012"
        //        }
        //    };

        //    var employeeByState = employees.Join(hometowns,
        //                                            e => new { City = e.City, State = e.State },
        //                                            h => new { City = h.City, State = h.State },
        //                                            (e, h) => new { e.LastName, h.CityCode });

        //    foreach (var employee in employeeByState)
        //    {
        //        Console.WriteLine(employee.LastName + ", " + employee.CityCode);
        //    }
        //}

        static void XmlMethodBasedCompositeKey()
        {
            var employeeByState =
                from e in root.Element("Employees").Elements("Employee")
                join h in root.Element("Hometowns").Elements("Hometown") on new { City = (string)e.Element("City"), State = (string)e.Element("State") } equals new { City = (string)h.Element("City"), State = (string)h.Element("State") }
                select new
                {
                    LastName = (string)e.Element("LastName"),
                    CityCode = (int)h.Element("CityCode")
                };
                
             
            foreach (var employee in employeeByState)
            {
                Console.WriteLine(employee.LastName + ", " + employee.CityCode);
            }
        }

        //static void MethodBasedGroupV1()
        //{
        //    var employees = new List<Employee>()
        //    {
        //        new Employee() 
        //        { 
        //            FirstName = "John", 
        //            LastName = "Smith", 
        //            City = "Havertown",
        //            State = "PA"
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jane", 
        //            LastName = "Doe", 
        //            City = "Ewing",
        //            State = "NJ"
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jack", 
        //            LastName = "Jones", 
        //            City = "Fort Washington",
        //            State = "PA"
        //        }
        //    };

        //    var employeesByState = employees.GroupBy(e => e.State);
                                   
        //    foreach (var employeeGroup in employeesByState)
        //    {
        //        Console.WriteLine(employeeGroup.Key + ": " + employeeGroup.Count());

        //        foreach (var employee in employeeGroup)
        //        {
        //            Console.WriteLine(employee.LastName + ", " + employee.State);
        //        }
        //    }
        //}

        static void XmlMethodBasedGroupV1()
        {
            var employeesByState =
                from e in root.Element("Employees").Elements("Employee")
                group e by (string)e.Element("State") into employeeGroup
                select employeeGroup;

            foreach (var employeeGroup in employeesByState)
            {
                Console.WriteLine((string)employeeGroup.Key + ": " + employeeGroup.Count());

                foreach (var employee in employeeGroup)
                {
                    Console.WriteLine((string)employee.Element("LastName") + ", " + (string)employee.Element("State"));
                }
            }
        }

        //static void MethodBasedGroupV2()
        //{
        //    List<Employee> employees = new List<Employee>()
        //    {
        //        new Employee() 
        //        { 
        //            FirstName = "John", 
        //            LastName = "Smith", 
        //            City = "Havertown",
        //            State = "PA"
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jane", 
        //            LastName = "Doe", 
        //            City = "Ewing",
        //            State = "NJ"
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jack", 
        //            LastName = "Jones", 
        //            City = "Fort Washington",
        //            State = "PA"
        //        }
        //    };

        //    var employeesByState = employees.GroupBy(e => new { e.City, e.State });

        //    foreach (var employeeGroup in employeesByState)
        //    {
        //        Console.WriteLine(employeeGroup.Key + ": " + employeeGroup.Count());

        //        foreach (var employee in employeeGroup)
        //        {
        //            Console.WriteLine(employee.LastName + ", " + employee.State);
        //        }
        //    }
        //}

        static void XmlMethodBasedGroupV2()
        {

            var employeesByState =
                from e in root.Element("Employees").Elements("Employee")
                group e by new {City =  (string)e.Element("City"), State = (string)e.Element("State")} into employeeGroup
                select employeeGroup;

            foreach (var employeeGroup in employeesByState)
            {
                Console.WriteLine(employeeGroup.Key + ": " + employeeGroup.Count());

                foreach (var employee in employeeGroup)
                {
                    Console.WriteLine((string)employee.Element("LastName") + ", " + (string)employee.Element("State"));
                }
            }
        }

        //static void Skip()
        //{
        //    List<Employee> employees = new List<Employee>()
        //    {
        //        new Employee() 
        //        { 
        //            FirstName = "John", 
        //            LastName = "Smith"                    
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jane", 
        //            LastName = "Doe"                    
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jack", 
        //            LastName = "Jones"                    
        //        }
        //    };

        //    var newEmployees = employees.Skip(1);

        //    foreach (var employee in newEmployees)
        //    {
        //        Console.WriteLine(employee.LastName);
        //    }
        //}

        static void XmlSkip()
        {
            var newEmployees =
                (from e in root.Element("Employees").Elements("Employee")
                 select new { LastName = (string)e.Element("LastName") }).Skip(1);

            foreach (var employee in newEmployees)
            {
                Console.WriteLine(employee.LastName);
            }
        }

        //static void Take()
        //{
        //    List<Employee> employees = new List<Employee>()
        //    {
        //        new Employee() 
        //        { 
        //            FirstName = "John", 
        //            LastName = "Smith"                    
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jane", 
        //            LastName = "Doe"                    
        //        },
        //        new Employee() 
        //        { 
        //            FirstName = "Jack", 
        //            LastName = "Jones"                    
        //        }
        //    };

        //    var newEmployees = employees.Take(2);

        //    foreach (var employee in newEmployees)
        //    {
        //        Console.WriteLine(employee.LastName);
        //    }
        //}

        static void XmlTake()
        {
            var newEmployees =
                (from e in root.Element("Employees").Elements("Employee")
                 select new { LastName = (string)e.Element("LastName") }).Take(2);

            foreach (var employee in newEmployees)
            {
                Console.WriteLine(employee.LastName);
            }
        }

        
        //static void DistinctCodeLab()
        //{
        //    List<State> states = new List<State>()
        //    {
        //        new State(){ StateId = 1, StateName = "PA"},
        //        new State() { StateId = 2, StateName = "NJ"},
        //        new State() { StateId = 1, StateName = "PA" },
        //        new State() { StateId = 3, StateName = "NY"}
        //    };

        //    var distintStates = states.Distinct();

        //    foreach (State state in distintStates)
        //    {
        //        Console.WriteLine(state.StateName);
        //    }
        //}

        static void XmlDistinctCodeLab()
        {

            var distintStates =
                (from s in root.Element("States").Elements("State")
                 select new { StateName = (string)s.Element("StateName") }).Distinct();

            foreach (var state in distintStates)
            {
                Console.WriteLine(state.StateName);
            }
        }

        static void Distinct()
        {
            int[] myArray = new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3 };

            var distinctArray = myArray.Distinct();

            foreach (int i in distinctArray)
            {
                Console.WriteLine(i);
            }
        }


        static void Concat()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() 
                { 
                    FirstName = "John", 
                    LastName = "Smith"                    
                },
                new Employee() 
                { 
                    FirstName = "Jane", 
                    LastName = "Doe"                    
                },
                new Employee() 
                { 
                    FirstName = "Jack", 
                    LastName = "Jones"                    
                }
            };

            List<Employee> employees2 = new List<Employee>()
            {
                new Employee() 
                { 
                    FirstName = "Bill", 
                    LastName = "Peters"                    
                },
                new Employee() 
                { 
                    FirstName = "Bob", 
                    LastName = "Donalds"                    
                },
                new Employee() 
                { 
                    FirstName = "Chris", 
                    LastName = "Jacobs"                    
                }
            };

            var combinedEmployees = employees.Concat(employees2);

            foreach (var employee in combinedEmployees)
            {
                Console.WriteLine(employee.LastName);
            }            
        }

        static void ConcatV2()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() 
                { 
                    FirstName = "John", 
                    LastName = "Smith"                    
                },
                new Employee() 
                { 
                    FirstName = "Jane", 
                    LastName = "Doe"                    
                },
                new Employee() 
                { 
                    FirstName = "Jack", 
                    LastName = "Jones"                    
                }
            };

            List<Person> people = new List<Person>()
            {
                new Person() 
                { 
                    FirstName = "Bill", 
                    LastName = "Peters"                    
                },
                new Person() 
                { 
                    FirstName = "Bob", 
                    LastName = "Donalds"                    
                },
                new Person() 
                { 
                    FirstName = "Chris", 
                    LastName = "Jacobs"                    
                }
            };

            var combinedEmployees = employees.Select(e => new { Name = e.LastName }).Concat(people.Select(p => new { Name = p.LastName }));

            foreach (var employee in combinedEmployees)
            {
                Console.WriteLine(employee.Name);
            }            
        }
        
        static bool IsEvenAndGT5(int i)
        {
            return (i % 2 == 0 && i > 5);
        }

        #endregion Method Based Queries

    }             

}
