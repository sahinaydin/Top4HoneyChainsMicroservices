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
    public class HoneyTestItemConcrete : IDatabaseBusiness<HoneyTestItem>
    {
        public void Add(HoneyTestItem entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestItems.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(HoneyTestItem entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestItems.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.HoneyTestItems.Find(id);
                db.HoneyTestItems.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<HoneyTestItem> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTestItems.ToList();
            }
        }

        public HoneyTestItem GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTestItems.Find(id);
            }
        }

        public void Update(HoneyTestItem entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestItems.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
