using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DataBaseCarContext>, IRentalDal
    {
        public void CarDeliver(int rentalId)
        {
            using (DataBaseCarContext context = new DataBaseCarContext())
            {
                var updatedRental = context.Rentals.FirstOrDefault(r => r.RentalId == rentalId);
                updatedRental.ReturnDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (DataBaseCarContext context = new DataBaseCarContext())
            {
                var result = from r in context.Rentals
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join u in context.Users
                             on r.RentalId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CompanyName = cu.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return result.ToList();
            }
        }
    }
}
