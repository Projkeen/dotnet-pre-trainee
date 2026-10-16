namespace Employee_Management_System
{
    public class Developer : Employee
    {
        public string ProgrammingLanguage {  get; set; }

        public Developer(int id, string name, int salary, string language ) : base(id, name, salary )
        {
            ProgrammingLanguage = language;
        }

        public override void Work()
        {
            Console.WriteLine("Developer Anna is writing C# code.");
        }
    }
}
