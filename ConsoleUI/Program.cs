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
            //CarGetAll();
            //CarTest();
            //ColorTest();
            //BrandTest();
            //ResultTest();
            //RentalTest();
            //CarDeliverTest();

            UserManager userManager = new UserManager(new EfUserDal());

            var result = userManager.GetAll();

            if (result.Success)
            {
                Console.WriteLine(result.Message);

                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.FirstName + " / " + user.LastName + " / " + user.Email);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void CarDeliverTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.CarDeliver(1);

            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetRentalDetails();

            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.RentalId + " / " + rental.FirstName + " / " + rental.LastName + " / " + rental.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.Descriptions);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ResultTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();


            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Delete(new Car { });

            //Car car1 = new Car() { Id = 6, CarName = "Pagani", BrandId = 7, ColorId = 4, ModelYear = 2021, DailyPrice = 140, Descriptions = "Pagani Zonda 2021 White" };
            //carManager.Add(car1);

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.DailyPrice + " / " + car.Descriptions);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            Console.WriteLine(result.Message);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();

            Console.WriteLine(result.Message);
        }
    }
}
