double a, b, result;
char operation;
bool askToContinue;

do
{
    Console.Write("Enter the first number: ");
    a = SetNumber();
    Console.Write("Choose an operation (+, -, * or / ): ");
    operation = SetOperation();
    Console.Write("Enter the second number: ");
    b = SetNumber();

    switch (operation)
    {
        case '+':
            result = Summing(a, b);
            Console.WriteLine($"Result: {result}");
            break;
        case '-':
            result = Subtraction(a, b);
            Console.WriteLine($"Result: {result}");
            break;
        case '*':
            result = Multiplication(a, b);
            Console.WriteLine($"Result: {result}");
            break;
        case '/':
            try
            {
                result = Division(a, b);
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error! Division by zero is not allowed.");
            }
            break;
        default: throw new InvalidOperationException("Unknown operation");
    }

} while (askToContinue = AskToContinue());

Console.WriteLine("The program was closed by the user");

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

double SetNumber()
{
    while (true)
    {
        if (double.TryParse(Console.ReadLine(), out double number))
        {
            return number;
        }
        else
        {
            Console.Write("Error! Enter a number!: ");
        }
    }
}

char SetOperation()
{
    while (true)
    {
        string? toChar = Console.ReadLine();
        if (toChar != null && toChar.Length == 1)
        {
            if (toChar == "+" || toChar == "-" || toChar == "*" || toChar == "/")
            {
                return operation = toChar[0];
            }
            Console.Write("Unsupported operation. Please use +, -, *, or /.: ");
        }
        else
        {
            Console.Write("Unsupported operation. Please use +, -, *, or /.: ");
        }
    }
}

bool AskToContinue()
{
    while (true)
    {
        Console.Write("Do you want to repeat calculation? (y/n): ");
        string? answer = Console.ReadLine();
        if (answer != null && answer.ToLower() == "y")
        {
            return true;
        }
        if (answer != null && answer.ToLower() == "n")
        {
            return false;
        }

        Console.WriteLine("Please enter 'y' or 'n': ");
    }
}



