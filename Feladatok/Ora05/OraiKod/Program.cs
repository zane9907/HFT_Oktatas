namespace Ora05
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarDbContext ctx = new CarDbContext();
            var cars = ctx.Cars.ToList();
            var people = ctx.People.ToList();

            ;
        }
    }
}