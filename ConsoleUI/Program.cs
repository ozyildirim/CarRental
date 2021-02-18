using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.inMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //brandManager.AddBrand(new Brand {BrandId = 14, BrandName = "KutiMARKASI" });
            //userManager.AddUser(new User { Id = 3, FirstName = "Salih Duhan", LastName = "Sayar", Email = "saliha@gmail.com", Password = "7573632" });
            customerManager.AddCustomer(new Customer { Id = 0, UserId = 1, CompanyName = "YILDIRIM A.Ş" });

            //new Rental { Id = 1, CarId = 2, CustomerId = 2, RentDate = new DateTime(2021, 02, 15), ReturnDate = new DateTime(2021, 02, 17) }

        }
    }
}
