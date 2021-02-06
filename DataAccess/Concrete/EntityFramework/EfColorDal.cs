using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RecapDBContext context = new RecapDBContext()) {
                var addedColor = context.Entry(entity);
                addedColor.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RecapDBContext context = new RecapDBContext()) {
                var deletedColor = context.Entry(entity);
                deletedColor.State = EntityState.Deleted;
                context.SaveChanges();
                }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (RecapDBContext context = new RecapDBContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
            
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using(RecapDBContext context = new RecapDBContext())
            {
                return filter == null
                ? context.Set<Color>().ToList()
                : context.Set<Color>().Where(filter).ToList();
            }
            
        }

        public void Update(Color entity)
        {
            using (RecapDBContext context = new RecapDBContext())
            {
                var updatedColor = context.Entry(entity);
                updatedColor.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
