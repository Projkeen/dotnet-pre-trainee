using Employee_Management_System;

Employee firstDeveloper = new Developer(1, "", 2400, "C#");
Employee secondDeveloper = new Developer(2, "Richard", -2700, "JS");
Employee designer = new Designer(3, "Anna", 1700, "Figma");
Employee manager = new Manager(4, "Kate", 3000, 4);

List<Employee> employees = new List<Employee>();
{
    employees.Add(firstDeveloper);
    employees.Add(secondDeveloper);
    employees.Add(designer);
    employees.Add(manager);
}

ConsoleMenu consoleMenu = new ConsoleMenu(employees);
consoleMenu.ShowMenu();
consoleMenu.ShowAllEmployees();
consoleMenu.MakeAllEmployeesWork();
consoleMenu.ShowReports();
consoleMenu.ChangeSalary();

//call work method
//firstDeveloper.Work();
//secondDeveloper.Work();
//designer.Work();
//manager.Work();




//check wrong data in fields
//manager.SetName("");
//manager.SetSalary(-15);
//manager.PrintInfo();

//Console.WriteLine("__________________________________");

//Add collection
//List<Employee> employees = new List<Employee>();

//employees.Add(firstDeveloper);
//employees.Add(secondDeveloper);
//employees.Add(designer);
//employees.Add(manager);

//employees.Add(dev);
//employees.Add(dev2);
//employees.Add(designer);
//employees.Add(manager);

foreach (Employee employee in employees)
{
    Console.WriteLine(employee.GetName());
}

foreach (Employee employee in employees)
{
    Console.WriteLine(employee.PrintInfo());
}

foreach (Employee employee in employees)
{
    employee.Work();
}
Console.WriteLine("________________________________________________________");

// call PrintInfo method
Console.WriteLine(firstDeveloper.PrintInfo());
Console.WriteLine(secondDeveloper.PrintInfo());
Console.WriteLine(designer.PrintInfo());
Console.WriteLine(manager.PrintInfo());
Console.WriteLine("__________________________________");

