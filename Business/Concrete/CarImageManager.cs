using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelperService _fileHelperService;

        public CarImageManager(ICarImageDal carImageDal, IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var imageCountResult = IsWithinImageLimit(carImage.CarId);
            var totalImageCountResult = IsWithinTotalImageLimit();

            if (!imageCountResult)
            {

                if (!totalImageCountResult)
                {

                    carImage.ImagePath = _fileHelperService.Upload(file, PathConstants.CarImagesPath);
                    carImage.ImageDate = DateTime.Now;

                    _carImageDal.Add(carImage);

                    return new SuccessResult(Messages.ImageAdded);
                }

                return new ErrorResult(Messages.CarImageLimitReached);
            }

            return new ErrorResult(Messages.ImageLimitExceeded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelperService.Delete(PathConstants.CarImagesPath + carImage.ImagePath);

            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id), Messages.ImagesListedById);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelperService.Update(file, PathConstants.CarImagesPath + carImage.ImagePath,
                PathConstants.CarImagesPath);

            carImage.ImageDate = DateTime.Now;

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.ImageUpdated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckImageExists(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(id).Data);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id), Messages.ImagesListedByCarId);
        }
        private bool IsWithinImageLimit(int carId)
        {
            var imageCount = _carImageDal.GetAll(i => i.CarId == carId).Count;

            if (imageCount >= 5)
            {
                return true;
            }

            return false;
        }

        private bool IsWithinTotalImageLimit()
        {
            var totalImageCount = _carImageDal.GetAll().Count;

            if (totalImageCount >= 16)
            {
                return true;
            }

            return false;
        }

        private IResult CheckImageExists(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;

            if (result > 0)
            {
                return new ErrorResult(Messages.ImageAlreadyHave);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage { CarId = carId, ImageDate = DateTime.Now, ImagePath = "DefaultImage.jpg" });

            return new SuccessDataResult<List<CarImage>>(carImages);
        }
    }
}
