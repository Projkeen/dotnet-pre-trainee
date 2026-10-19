namespace Employee_Management_System
{
    public class Designer : Employee
    {
        public string DesignTool {  get; set; }

        public Designer(int id, string name, decimal salary, string  designTool) : base(id, name, salary)
        {
            DesignTool = designTool;
        }
        public override void Work() => Console.WriteLine($"Designer {Name} is working in {DesignTool}.");        

        public override string PrintInfo() => base.PrintInfo() + $"Tool: {DesignTool}. [Designer] ";        
    }
}
