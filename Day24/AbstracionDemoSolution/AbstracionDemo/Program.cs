namespace AbstracionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Animal animal;

            Dog dog = new Dog();

            animal = dog;

            animal.MakeSound();

           
            

        }
    }
}
