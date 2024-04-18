namespace ConsoleApp
{

    
    internal class Program
    {
        void UnderstandingJaggedArray()
        {
            string[][] posts = new string[4][];
            for (int i = 0; i < posts.Length; i++)
            {
                Console.WriteLine("Please enter the number of columns");
                int count = Convert.ToInt32(Console.ReadLine());
                posts[i] = new string[count];
                for (int j = 0; j < count; j++)
                {
                    Console.WriteLine($"Please enter the post {i + 1} value");
                    posts[i][j] = Console.ReadLine();
                }
            }
            Console.WriteLine("Posts");
            for (int i = 0; i < posts.Length; i++)
            {
                for (int j = 0; j < posts[i].Length; j++)
                    Console.Write(posts[i][j] + " ");
                Console.WriteLine("---------------------");
            }
        }


        static void Main(string[] args)
        {
            //Student student = new Student() { Name = "Ramu", Id = 101 };
            //student[0] = "C";
            //student[1] = "Java";
            //student[2] = "C#";
            //Console.WriteLine(student);
            new Program

        }
    }
}
