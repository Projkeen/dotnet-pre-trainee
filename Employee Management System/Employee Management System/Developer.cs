namespace Employee_Management_System
{
    public class Developer : Employee, IReportable
    {
        public string ProgrammingLanguage {  get; set; }

        public Developer(int id, string name, decimal salary, string language ) : base(id, name, salary )
        {
            ProgrammingLanguage = language;
        }

        public override void Work()
        {
            Console.WriteLine($"Developer {Name} is writing {ProgrammingLanguage} code.");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Programming language: {ProgrammingLanguage}. [Developer] ");
        }

        public string GenerateReport()
        {
            return $"Developer report: Developer {Name} create a new feature using {ProgrammingLanguage}";
        }
    }
}
