using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.inMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new inMemoryCarDal());
            // TODO: change DAL as a entity framework

            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Car ID: " + car.CarId);
                Console.WriteLine("Brand ID: " + car.BrandId);
                Console.WriteLine("Color ID: " + car.ColorId);
                Console.WriteLine("Daily Price: " + car.DailyPrice);
                Console.WriteLine("Description: " + car.Description);
                Console.WriteLine("Model Year: " + car.ModelYear);
                Console.WriteLine("--------------------");
            }
        }
    }
}
