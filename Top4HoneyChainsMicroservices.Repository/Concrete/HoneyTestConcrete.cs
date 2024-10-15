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
    public class HoneyTestConcrete : IDatabaseBusiness<HoneyTest>
    {
        public void Add(HoneyTest entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTests.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(HoneyTest entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTests.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.HoneyTests.Find(id);
                db.HoneyTests.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<HoneyTest> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTests.ToList();
            }
        }

        public HoneyTest GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTests.Find(id);
            }
        }

        public void Update(HoneyTest entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTests.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
