using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
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

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult CarDeliver(int rentalId)
        {
            var isrental = _rentalDal.Get(r => r.RentalId == rentalId);
            if (isrental != null)
            {
                _rentalDal.CarDeliver(rentalId);
                return new SuccessResult(Messages.CarDeliver);
            }

            return new ErrorResult(Messages.CarDeliverEmpty);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {

            var rentals = _rentalDal.GetAll();

            if (rentals.Any())
            {
                var availableRentals = rentals.Where(r => r.ReturnDate == null).ToList();

                if (availableRentals.Any())
                {
                    return new SuccessDataResult<List<Rental>>(availableRentals, Messages.RentalsListed);
                }
                else
                {
                    return new ErrorDataResult<List<Rental>>(Messages.NoAvailableRentals);
                }
            }
            else
            {
                return new ErrorDataResult<List<Rental>>(Messages.NoRentalsFound);
            }
        }

        public IDataResult<List<Rental>> GetRentalsByCarId(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<List<Rental>>(Messages.Invalid);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<List<Rental>> GetRentalsByCustomerId(int customerId)
        {
            var result = _rentalDal.GetAll(r => r.CustomerId == customerId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<List<Rental>>(Messages.Invalid);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == customerId));
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var result = _rentalDal.GetAll(r => r.RentalId == rentalId);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Rental>(Messages.Invalid);
            }

            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(filter));
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
