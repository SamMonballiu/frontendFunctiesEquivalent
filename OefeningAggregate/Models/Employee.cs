namespace OefeningAggregate.Models
{
    public class Employee
    {
        public Employee(string name, int salary, bool freelancer)
        {
            Name = name;
            Freelancer = freelancer;
            Salary = salary;
        }

        public string Name { get; set; }
        public bool Freelancer { get; set; }
        public int Salary { get; set; }
    }
}
