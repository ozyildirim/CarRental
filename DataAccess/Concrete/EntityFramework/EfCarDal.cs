using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapDBContext context = new RecapDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join x in context.Colors
                             on c.ColorId equals x.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.Description,
                                 ColorName = x.ColorName,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
                             
            }
        }
    }
}
