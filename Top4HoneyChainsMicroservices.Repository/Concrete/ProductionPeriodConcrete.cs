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
    public class ProductionPeriodConcrete : IDatabaseBusiness<ProductionPeriod>
    {
        public void Add(ProductionPeriod entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ProductionPeriods.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(ProductionPeriod entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ProductionPeriods.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.ProductionPeriods.Find(id);
                db.ProductionPeriods.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<ProductionPeriod> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.ProductionPeriods.ToList();
            }
        }

        public ProductionPeriod GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.ProductionPeriods.Find(id);
            }
        }

        public void Update(ProductionPeriod entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ProductionPeriods.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
