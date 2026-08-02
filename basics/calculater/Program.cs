namespace calculater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator program!");
            Console.WriteLine("The statements are as follows:"); Console.WriteLine("1. Addition 2. Subtraction 3. Multiplication 4. Division 5. Power 6. Square Root");
        Start:
            Console.WriteLine("Please enter the number of your choice: enter number");
            var number_1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second number: enter number");
            var number_2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Choose the operation (+, -, *, /, ^, √):");
            char op = char.Parse(Console.ReadLine());

            switch (op)
            {
                case '+':
                    Console.WriteLine("The result is: " + (number_1 + number_2));
                    break;
                case '-':
                    Console.WriteLine("The result is: " + (number_1 - number_2));
                    break;
                case '*':
                    Console.WriteLine("The result is: " + (number_1 * number_2));
                    break;
                case '/':
                    if (number_2 != 0)
                    {
                        Console.WriteLine("The result is: " + (number_1 / number_2));
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                    }
                    break;
                case '^':
                    Console.WriteLine("The result is: " + Math.Pow(number_1, number_2));
                    break;
                case '√':
                    if (number_1 >= 0)
                    {
                        Console.WriteLine("The result is: " + Math.Sqrt(number_1));
                    }
                    else
                    {
                        Console.WriteLine("Error: Square root of a negative number is not allowed.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator. Please use one of the following: +, -, *, /, ^, √");
                    break;
            }
            Console.WriteLine("Do you want to perform another calculation? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                goto Start;
            }
            else
            {
                Console.WriteLine("Thank you for using the calculator program!");


            }
        }
    }
}
