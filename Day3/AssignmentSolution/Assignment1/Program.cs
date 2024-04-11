namespace Assignment1
{
    internal class Program
    {   

        static int TakeNum(string data)
        {
            int num;
            Console.WriteLine($"Enter a {data}");
            while(!int.TryParse(Console.ReadLine(),out num)){
                Console.WriteLine($"Invalid {data} enter again");
            }
            return num;
        }

        static int add(int num1, int num2)
        {

            return num1 + num2;
        }

        static int multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        static int divide(int num1, int num2)
        {
            int result;
            try
            {
                result = num1 / num2;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot divide a number by zero");
                return 0;
                throw;
            }
            return result;
        }

        static int subtact(int num1, int num2)
        {
            return (num1 - num2);
        }

        static int modulo(int num1, int num2)
        {
            int result;
            try
            {
                result = num1 % num2;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot divide a number by zero");
                return 0;
                throw;
            }
            return result;
        }
        
        static void PrintInfo(int result, string operation)
        {
            Console.WriteLine($"The {operation} operation of two numbers is {result}");
        }

        static void calculate()
        {
            int option = TakeNum("option");
            int num1 = TakeNum("number");
            int num2 = TakeNum("number");
            
            switch(option)
            {
                case 0:
                    PrintInfo(add(num1, num2), "Addition");
                    break;
                case 1:
                    PrintInfo(subtact(num1, num2), "Difference");
                    break;
                case 2:
                    PrintInfo(multiply(num1, num2), "Product");
                    break;
                case 3:
                    PrintInfo(divide(num1, num2), "Division");
                    break;
                case 4:
                    PrintInfo(modulo(num1, num2), "Modulo");
                    break;
                default:
                    Console.WriteLine("Enter the correct option");
                    calculate();
                    break;

            }
            

        }

        static void Main(string[] args)
        {

            //int sum = 
            //int sub = subtact(num1, num2);
            //int prod = multiply(num1, num2);
            //int division = divide(num1, num2);
            //int remainder = modulo(num1, num2);
            //PrintInfo(sum, "Sum");
            //PrintInfo(sub, "Difference");
            //PrintInfo(prod, "Product");
            //PrintInfo(division, "Division");
            //PrintInfo(remainder, "Modulo");
            
            calculate();


        }
    }
}
