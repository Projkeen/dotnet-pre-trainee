namespace Employee_Management_System
{
    public abstract class Employee
    {
        protected int Id { get; set; }
        protected string Name { get; private set; }
        protected decimal Salary { get; private set; }
               
        public event EventHandler? SalaryChanged;

        public Employee(int id, string name, decimal salary)
        {
            Id = id;
            Name = SetName(name);
            Salary = SetSalary(salary);            
            //Name = name;
            //Salary = salary;
        }

        public string GetName()
        {
            return Name;
        }
        public string SetName(string name)
        {
            if (name.Count() == 0 || string.IsNullOrWhiteSpace(name))
            {
                Name = "<Name must not be empty>";
                return Name;
            }
            Name = name;
            return Name;
        }

        public decimal GetSalary()
        {
            return Salary;
        }

        public decimal SetSalary(decimal salary)
        {
            if (salary < 0)
            {
                //Salary = "Salary must not be negative.";
                Salary = 0;
                return Salary;
            }
            if (Salary == salary)
            {
                return Salary;
            }
            Salary = salary;
            ChangeSalary(salary);
            return Salary;
            
        }

        public abstract void Work();

        public void ChangeSalary(decimal salary)
        {            
            SalaryChanged?.Invoke(this, EventArgs.Empty);
        }

        public virtual string PrintInfo()
        {
            return $"Id: <{Id}>: Name: {Name}, salary: {Salary}, ";
        }

        public int GetId()
        {
            return Id;
        }
    }
}
