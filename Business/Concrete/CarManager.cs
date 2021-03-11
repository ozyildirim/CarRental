using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;


        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        // we can set validator for that function.
        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {

            IResult result = BusinessRules.Run(CheckIfAnyCarHasSameName(car.CarName), CheckIfDailyPriceIsValid(car.DailyPrice));

            if (result != null)
            {
                return result;
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
        }

        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId), Messages.CarsListedByBrand);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId), Messages.CarsListedByColor);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsDetailsListed);
        }


        /*
         * The part below is for business rules, we can set special rules for methods.
         * We can use these logic methods via BusinessRules.Run method.
         * 
         */
        private IResult CheckIfAnyCarHasSameName(string carName)
        {
            var result = _carDal.Get(p => p.CarName == carName);
            if (result != null)
            {
                return new ErrorResult(Messages.ExistingCarName);
            }
            return new SuccessResult();
        }

        private IResult CheckIfDailyPriceIsValid(int dailyPrice)
        {
            if (dailyPrice > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.InvalidDailyPrice);
        }


    }

}
