﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        // we can set validator for that function.
        [ValidationAspect(typeof(BrandValidator))]
        public IResult AddBrand(Brand brand)
        {
            if(brand.BrandName.Length > 0)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
            else
            {
                return new ErrorResult(Messages.InvalidBrandName);
            }
        }

        public IResult DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
        }

        public IResult UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
