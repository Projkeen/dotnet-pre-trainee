
namespace Employee_Management_System
{
    public class Designer : Employee
    {
        public string DesignTool {  get; set; }

        public Designer(int id, string name, int salary, string  designTool) : base(id, name, salary)
        {
            DesignTool = designTool;
        }
        public override void Work()
        {
            Console.WriteLine("Designer Kate is working in Figma.");
        }
    }
}
