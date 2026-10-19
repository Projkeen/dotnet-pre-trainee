using Employee_Management_System;

Employee firstDeveloper = new Developer(1, "Alexey", 2800, "C#");
Employee secondDeveloper = new Developer(2, "Richard", 2700, "JS");
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
foreach (Employee employee in employees)
{
    consoleMenu.SubToSalaryChanging(employee);
}

consoleMenu.Start();

