using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddCarImage(CarImage carImage, IFormFile formFile);
        IResult DeleteCarImage(CarImage carImage);
        IResult UpdateCarImage(CarImage carImage, IFormFile formFile);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetImageById(int imageId);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);


    }
}
