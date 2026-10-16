
namespace Employee_Management_System
{
    public class ConsoleMenu
    {
        private List<Employee> _employees;
        public ConsoleMenu(List<Employee> employees)
        {
            _employees = employees;
        }

        public void ShowMenu()
        {
            Console.WriteLine("_____________________________________________________________________");
            Console.WriteLine("Employee management system");
            Console.WriteLine("Press <1> to show all employees");
            Console.WriteLine("Press <2> to make all employees work");
            Console.WriteLine("Press <3> to change an employee salary");
            Console.WriteLine("Press <4> to generate a report");
            Console.WriteLine("Press <5> to Exit");
        }

        public void ShowAllEmployees()
        {
            foreach (Employee employee in _employees)
            {
                Console.WriteLine(employee.PrintInfo());
            }
        }

        public void MakeAllEmployeesWork()
        {
            foreach (Employee employee in _employees)
            {
                employee.Work();
            }
        }

        public void ChangeSalary()
        {
            Console.Write("Enter Employee Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id. Please enter a number.");
                return;
            }
            Employee? employee = _employees.FirstOrDefault(x => x.GetId() == id);
            if (employee == null)
            {
                Console.WriteLine($"Employee with Id {id} was not found.");
                return;
            }
            Console.WriteLine($"Enter new salary for {employee.GetName()}");
            if(!decimal.TryParse(Console.ReadLine(), out decimal salary))
            {
                Console.WriteLine("Invalid input. Please enter a number ");
                return;
            }            
            
            employee.SetSalary(salary);          
            
        }

        public IEnumerable<IReportable> ShowReports()
        {
            List<IReportable> reports = new List<IReportable>();
            foreach (Employee employee in _employees)
            {
                if (employee is IReportable reportable)
                {
                    reports.Add(reportable);
                }
            }
            foreach (IReportable report in reports)
            {
                Console.WriteLine(report.GenerateReport());
            }
            return reports;
        }
    }
}
