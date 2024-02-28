using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            
                return new ErrorResult(Messages.CarNameInvalid);
        }
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.Get(c => c.BrandId == brandId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<List<Car>>(Messages.Invalid);
            }

            return new SuccessDataResult<List<Car>>(_carDal.Get(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.Get(c=>c.ColorId== colorId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<List<Car>>(Messages.Invalid);
            }

            return new SuccessDataResult<List<Car>>(_carDal.Get(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(filter));
        }

        public IDataResult<List<Car>> GetById(int carId)
        {
            var result = _carDal.Get(c => c.CarId == carId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<List<Car>>(Messages.Invalid);
            }

            return new SuccessDataResult<List<Car>>(_carDal.Get(c => c.CarId == carId));
        }
    }
}
