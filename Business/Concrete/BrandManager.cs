using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void AddBrand(Brand brand)
        {
            if(brand.BrandName.Length > 0)
            {
                _brandDal.Add(brand);
                Console.WriteLine("The brand has been added.");
            }
            else
            {
                Console.WriteLine("Lenght of brand name must be more than 2");
            }
        }

        public void DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("The brand has been deleted.");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("The brand has been updated.");
        }
    }
}
