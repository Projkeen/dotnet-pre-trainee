namespace Employee_Management_System
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public int Salary { get; private set; }

        public Employee(int id, string name, int salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public void SetName(string name)
        {
            if (name == null)
            {
                Console.WriteLine("The name shouldn't be empty");
                return;
            }
            Name = name;
        }
        public void SetSalary(int salary)
        {
            if (salary < 0)
            {
                Console.WriteLine("The salary shouldn't be less than 0");
                return;
            }
            Salary = salary;
        }

        public abstract void Work();
    }
}
