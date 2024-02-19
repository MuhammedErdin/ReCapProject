using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car{Id=1,CarName="Porsche", BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=20000,Descriptions="Siyah renk Porsche"},
                new Car{Id=2,CarName="Porsche", BrandId=1,ColorId=2,ModelYear=2020,DailyPrice=20000,Descriptions="Beyaz renk Porsche"},
                new Car{Id=3,CarName="Lamborghini", BrandId=2,ColorId=2,ModelYear=2019,DailyPrice=25000,Descriptions="Beyaz renk Lamborghini"},
                new Car{Id=4,CarName="Lamborghini", BrandId=2,ColorId=1,ModelYear=2019,DailyPrice=25000,Descriptions="Siyah renk Lamborghini"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.CarName = car.CarName;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
        }
    }
}
