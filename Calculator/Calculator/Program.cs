double a, b, result;
char operation;
bool askToContinue;

Console.Write("Enter the first number: ");
while (!double.TryParse(Console.ReadLine(), out a))
{
    Console.WriteLine("Error! Enter a number!");
}

Console.Write("Choose an operation (+, -, *, /): ");
while (!char.TryParse(Console.ReadLine(), out operation))
{
    Console.Write("Unsupported operation. Please use +, -, *, or / : ");
}

Console.Write("Enter the second number: ");
while (!double.TryParse(Console.ReadLine(), out b))
{
    Console.WriteLine("Error! Enter a number!");
}

switch (operation)
{
    case '+':
        result = Summing(a, b);
        break;
    case '-':
        result = Subtraction(a, b);
        break;
    case '*':
        result = Multiplication(a, b);
        break;
    case '/':
        result = Division(a, b);
        break;
    default: throw new InvalidOperationException("Unknown operation");
}

Console.WriteLine($"Result {result}");

double Summing(double a, double b)
{
    return a + b;
}

double Subtraction(double a, double b)
{
    return (a - b);
}

double Multiplication(double a, double b)
{
    return a * b;
}

double Division(double a, double b)
{
    if (b != 0)
        return a / b;
    throw new DivideByZeroException();
}