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
    public class HoneyTestStandardItemConcrete : IDatabaseBusiness<HoneyTestStandardItem>
    {
        public void Add(HoneyTestStandardItem entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestStandardItems.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(HoneyTestStandardItem entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestStandardItems.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.HoneyTestStandardItems.Find(id);
                db.HoneyTestStandardItems.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<HoneyTestStandardItem> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTestStandardItems.ToList();
            }
        }

        public HoneyTestStandardItem GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTestStandardItems.Find(id);
            }
        }

        public void Update(HoneyTestStandardItem entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestStandardItems.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
