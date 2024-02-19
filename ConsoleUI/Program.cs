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
            CarTest();

            //ColorTest();

            //BrandTest();
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Delete(new Car { });

            //Car car1 = new Car() { Id = 6, CarName = "Pagani", BrandId = 7, ColorId = 4, ModelYear = 2021, DailyPrice = 140, Descriptions = "Pagani Zonda 2021 White" };
            //carManager.Add(car1);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " / " + car.DailyPrice + " / " + car.Descriptions);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }
    }
}
