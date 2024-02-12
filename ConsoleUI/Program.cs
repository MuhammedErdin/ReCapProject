using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car() { Id = 6, CarName = "Pagani", BrandId = 7, ColorId = 4, ModelYear = 2021, DailyPrice = 140, Descriptions = "Pagani Zonda 2021 White" };
            //carManager.Add(car1);
            carManager.Delete(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car Name: " + car.CarName + " Description: " + car.Descriptions);
            }

            //ColorManager colorManager = new ColorManager(new EfColorDal());

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}
        }
    }
}
