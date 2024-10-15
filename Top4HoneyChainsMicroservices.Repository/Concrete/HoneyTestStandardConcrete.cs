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
    public class HoneyTestStandardConcrete : IDatabaseBusiness<HoneyTestStandard>
    {
        public void Add(HoneyTestStandard entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestStandards.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(HoneyTestStandard entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestStandards.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.HoneyTestStandards.Find(id);
                db.HoneyTestStandards.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<HoneyTestStandard> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTestStandards.ToList();
            }
        }

        public HoneyTestStandard GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTestStandards.Find(id);
            }
        }

        public void Update(HoneyTestStandard entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestStandards.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
