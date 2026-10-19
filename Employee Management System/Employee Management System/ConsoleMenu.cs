using System.Threading.Channels;

namespace Employee_Management_System
{
    public class ConsoleMenu
    {
        private List<Employee> _employees;
        public ConsoleMenu(List<Employee> employees) => _employees = employees;        

        public void ShowMenu()
        {
            Console.WriteLine("__________________________________________________________________________________");
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
            Console.Write($"Enter new salary for {employee.GetName()}: ");            
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

        public void SubToSalaryChanging(Employee employee)
        {            
            employee.SalaryChanged += (sender, e) =>
            {
                Console.WriteLine($"Salary for {employee.GetName()} has been changed to {employee.GetSalary()}");
            };
        }

        public void Start()
        {
            while (true)
            {
                ShowMenu();
                Console.Write("Select: ");                
                string? input = Console.ReadLine();
                Console.WriteLine("__________________________________________________________________________________");               
                switch (input)
                {
                    case "1":
                        ShowAllEmployees();
                        break;
                    case "2":
                        MakeAllEmployeesWork();
                            break;
                    case "3":
                        ChangeSalary();
                        break;
                    case "4":
                        ShowReports(); break;
                    case "5":
                        Console.WriteLine("Exit");
                        return;
                    default:
                        Console.WriteLine("Unknown operation, please select from 1 to 5");
                        break;
                }
            }
        }
    }
}
