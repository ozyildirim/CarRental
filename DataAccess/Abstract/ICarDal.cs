﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        Car GetById(int id);
        List<Car> GelAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

    }
}