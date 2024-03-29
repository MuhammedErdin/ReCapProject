﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(CarValidator))]
        [MaintenanceAspect(DayOfWeek.Sunday)]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [MaintenanceAspect(DayOfWeek.Sunday)]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        [MaintenanceAspect(DayOfWeek.Sunday)]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [MaintenanceAspect(DayOfWeek.Sunday)]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<List<Car>>(Messages.Invalid);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        [MaintenanceAspect(DayOfWeek.Sunday)]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<List<Car>>(Messages.Invalid);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        [ValidationAspect(typeof(CarValidator))]
        [MaintenanceAspect(DayOfWeek.Sunday)]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [MaintenanceAspect(DayOfWeek.Sunday)]
        public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(filter));
        }

        [MaintenanceAspect(DayOfWeek.Sunday)]
        public IDataResult<Car> GetById(int carId)
        {
            var result = _carDal.GetAll(c => c.CarId == carId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Car>(Messages.Invalid);
            }

            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }
    }
}
