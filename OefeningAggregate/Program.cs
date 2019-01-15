using OefeningAggregate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningAggregate
{
    class Program
    {
        //analoog met https://github.com/SamMonballiu/frontendexercises/blob/master/basis/enterprise.js

        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            employees = new List<Employee>()
            {
                new Employee("Marcel", 3000, true),
                new Employee("Sandra", 3100, false),
                new Employee("Thomas", 2800, false),
                new Employee("Alexander", 3502, false),
                new Employee("Els", 3050, true),
                new Employee("Igor", 2600, true),
                new Employee("Anne", 2600,true)
            };

            Console.WriteLine("Best paid freelancer: " + GetBestPaidFreelancer().Name);

            Console.WriteLine("\nEarning more than 3K: ");
            foreach (var name in EarnsMoreThan3k())
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nAverage salary: " + AverageSalaryNonFreelancer());

            Console.WriteLine("\nLongest name: " +  GetLongestName());

            Console.WriteLine("\nSorted names:");
            employees.OrderBy(x => x.Name).ToList().ForEach(x => Console.WriteLine(x.Name));

            Console.ReadKey();
        }

        public static Employee GetBestPaidFreelancer()
        {
            // JS: const freelancers = employees.filter(x => x.freelancer);
            var freelancers = employees.Where(x => x.Freelancer);

            // JS:
            //const bestPaidFreelancer = freelancers.reduce(function(prev, current) {
            //    return (prev.salary > current.salary) ? prev : current
            // });

            // literal equivalent of JS:
            // return freelancers.Aggregate(new Func<Employee, Employee, Employee>((prev, current) => (prev.Salary > current.Salary) ? prev : current));

            return freelancers.Aggregate((x, y) => (x.Salary > y.Salary) ? x : y);
        }

        public static IEnumerable<string> EarnsMoreThan3k()
        {
            // JS: return employees.filter(x => x.salary > 3000).map(x => x.name)
            return employees.Where(x => x.Salary > 3000).Select(y => y.Name);
        }

        public static double AverageSalaryNonFreelancer()
        {
            //var internen = employees.Where(x => !x.Freelancer);
            //var totalSalaris = internen.Sum(x => x.Salary);
            ////return totalSalaris / internen.Count();
            ///
            return employees.Where(x => !x.Freelancer)
                            .Average(x => x.Salary);
        }

        public static string GetLongestName() => employees.OrderByDescending(x => x.Name.Length).FirstOrDefault().Name;


    }
}
