using DbDemoApp.Model;



namespace DbDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Area area = new Area();
            //area.Area1 = "POPO";
            //area.Zipcode = "44332";
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();
            //context.Areas.Add(area);
            //context.SaveChanges();


            //var areas = context.Areas.ToList();
            //foreach (var area in areas)
            //{
            //    Console.WriteLine(area.Area1 + " " + area.Zipcode);
            //}

            var areas = context.Areas.ToList();
            var area = areas.SingleOrDefault(a => a.Area1 == "FFFF");
            area.Area1 = "GGBoys";
            area.Zipcode = "00000";
            context.Areas.Update(area);
            context.SaveChanges();

            //area = areas.SingleOrDefault(a => a.Area1 == "POPO");
            //context.Areas.Remove(area);
            context.SaveChanges();
            foreach (var a in areas)
            {
                Console.WriteLine(a.Area1 + " " + a.Zipcode);
            }




        }
    }
}
