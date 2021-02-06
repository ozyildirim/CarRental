using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.inMemory
{
    public class inMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public inMemoryCarDal()
        {
            _cars = new List<Car>
               {
                   new Car{CarId = 1,BrandId = 1, ColorId = 2,DailyPrice = 150, ModelYear = 2015, Description = "Fastest car in 2015."},
                   new Car{CarId = 2,BrandId = 2, ColorId = 1,DailyPrice = 300, ModelYear = 2016, Description = "The car that all colors fit."},
                   new Car{CarId = 3,BrandId = 2, ColorId = 5,DailyPrice = 400, ModelYear = 2017, Description = "Fastest car in 2018."},
                   new Car{CarId = 4,BrandId = 3, ColorId = 3,DailyPrice = 500, ModelYear = 2021, Description = "Elegant."},
                   new Car{CarId = 5,BrandId = 5, ColorId = 2,DailyPrice = 300, ModelYear = 2018, Description = "Inevitable."},
               };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;

            carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GelAll()
        {
            return _cars;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.Single(c => c.CarId == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
