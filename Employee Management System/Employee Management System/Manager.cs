namespace Employee_Management_System
{
    public class Manager : Employee
    {
        public int TeamSize { get; set; }

        public Manager(int id, string name, int salary, int teamSize) : base(id, name, salary)
        {
            TeamSize = teamSize;
        }
        public override void Work()
        {
            Console.WriteLine("Manager John is managing a team of 5 people.");
        }
    }


}
