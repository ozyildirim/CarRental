using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCar(Car car)
        {
            if(car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("The car has been added to DB.");
            }
            else
            {
                Console.WriteLine("Daily price must be higher than 0");
            }
        }

        public void DeleteCar(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("The car has been deleted from DB.");
        }

        public void UpdateCar(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("The car with ID " + car.CarId + "has been updated.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }
        
        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }

    // TODO: Add different methods that uses different filters : GetCarsByBrandId , GetCarsByColorId
}
