using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileSystems;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult AddCarImage(CarImage carImage, IFormFile formFile)
        {
            carImage.ImagePath = FileHelper.Add(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }



        public IResult DeleteCarImage(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IResult UpdateCarImage(CarImage carImage, IFormFile formFile)
        {
            var carImageToUpdate = _carImageDal.Get(c => c.ImageId == carImage.ImageId);
            carImage.CarId = carImageToUpdate.CarId;
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.CarId == carImage.ImageId).ImagePath, formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            AddDefaultCarImage(result, carId);
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId));

        }

        public IDataResult<CarImage> GetImageById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == imageId));
        }



        private string CreateNewPath(IFormFile formFile)
        {
            var fileInfo = new FileInfo(formFile.FileName);
            var newPath =
                $@"{Environment.CurrentDirectory}\Public\Images\CarImage\Upload\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";

            return newPath;
        }

        private void AddDefaultCarImage(List<CarImage> result, int carId)
        {
            if (!result.Any())
            {
                var defaultCarImage = new CarImage
                {
                    CarId = carId,
                    ImagePath = $@"{Environment.CurrentDirectory}\Public\Images\CarImage\default-img.png",
                    Date = DateTime.Now
                };
                result.Add(defaultCarImage);
            }
        }


    }
}
