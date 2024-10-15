using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Abstract;

namespace Top4HoneyChainsMicroservices.Repository.Concrete
{
    public class HoneyDistributionTypeConcrete : IDatabaseBusiness<HoneyDistributionType>
    {
        public void Add(HoneyDistributionType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyDistributionTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(HoneyDistributionType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyDistributionTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.HoneyDistributionTypes.Find(id);
                db.HoneyDistributionTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<HoneyDistributionType> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyDistributionTypes.ToList();
            }
        }

        public HoneyDistributionType GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyDistributionTypes.Find(id);
            }
        }

        public void Update(HoneyDistributionType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyDistributionTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
