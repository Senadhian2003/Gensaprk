namespace Assignment1
{
    internal class Task1
    {   

        static float TakeNum(string data)
        {
            float num;
            Console.WriteLine($"Enter a {data}");
            while(!float.TryParse(Console.ReadLine(),out num)){
                Console.WriteLine($"Invalid {data} enter again");
            }
            return num;
        }

        static float add(float num1, float num2)
        {

            return num1 + num2;
        }

        static float multiply(float num1, float num2)
        {
            return num1 * num2;
        }

        static float divide(float num1, float num2)
        {
            float result;
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

        static float subtact(float num1, float num2)
        {
            return (num1 - num2);
        }

        static float modulo(float num1, float num2)
        {
            float result;
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
        
        static void PrintInfo(float result, string operation)
        {
            Console.WriteLine($"The {operation} operation of two numbers is {result}");
        }

        static void calculate()
        {
            printOption();
            float option = TakeNum("option");
            float num1 = TakeNum("number");
            float num2 = TakeNum("number");
            
            switch(option)
            {
                case 1:
                    PrintInfo(add(num1, num2), "Addition");
                    break;
                case 2:
                    PrintInfo(subtact(num1, num2), "Difference");
                    break;
                case 3:
                    PrintInfo(multiply(num1, num2), "Product");
                    break;
                case 4:
                    PrintInfo(divide(num1, num2), "Division");
                    break;
                case 5:
                    PrintInfo(modulo(num1, num2), "Modulo");
                    break;
                default:
                    Console.WriteLine("Enter the correct option");
                    calculate();
                    break;

            }
            

        }

        static void printOption() {

            Console.WriteLine("Select the operation to be performed");

            Console.WriteLine("1.Addition\n2.Subtraction\n3.Multiplication\n4.Division\n5.Remainder");
        
        
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
