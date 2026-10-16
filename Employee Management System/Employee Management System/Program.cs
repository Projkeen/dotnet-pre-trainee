using Employee_Management_System;

Employee dev = new Developer(1, "Alexey", 2400, "C#");
Employee dev2 = new Developer(2, "Richard", 2700, "JS");
Employee designer = new Designer(3, "Anna", 1700, "Figma");
Employee manager = new Manager(4, "Kate", 3000, 4);

//call work method
dev.Work();
dev2.Work();
designer.Work();
manager.Work();


Console.WriteLine("__________________________________");
// call PrintInfo method
dev.PrintInfo();
dev2.PrintInfo();
designer.PrintInfo();
manager.PrintInfo();
Console.WriteLine("__________________________________");

//check wrong data in fields
manager.SetName("");
manager.SetSalary(-15);
manager.PrintInfo();

Console.WriteLine("__________________________________");

//Add collection
List<Employee> employees = new List<Employee>();
employees.Add(dev);
employees.Add(dev2);
employees.Add(designer);
employees.Add(manager);

foreach (Employee employee in employees)
{
    Console.WriteLine(employee.GetName());
}

foreach (Employee employee in employees)
{
    employee.PrintInfo();
}

foreach (Employee employee in employees)
{
    employee.Work();
}