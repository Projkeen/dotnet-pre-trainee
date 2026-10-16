namespace Employee_Management_System
{
    public class Manager : Employee, IReportable
    {
        public int TeamSize { get; set; }

        public Manager(int id, string name, decimal salary, int teamSize) : base(id, name, salary)
        {
            TeamSize = teamSize;
        }
        public override void Work()
        {
            Console.WriteLine($"Manager {Name} is managing a team of {TeamSize} people.");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Team size: {TeamSize} people. [Manager] ");
        }

        public string GenerateReport()
        {
            return $"Manager report: Manager {Name} create a new tasks for {TeamSize} people";
        }
    }


}
