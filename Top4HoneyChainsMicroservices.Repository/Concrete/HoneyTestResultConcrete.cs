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
    public class HoneyTestResultConcrete : IDatabaseBusiness<HoneyTestResult>
    {
        public void Add(HoneyTestResult entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestResults.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(HoneyTestResult entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestResults.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.HoneyTestResults.Find(id);
                db.HoneyTestResults.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<HoneyTestResult> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTestResults.ToList();
            }
        }

        public HoneyTestResult GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTestResults.Find(id);
            }
        }

        public void Update(HoneyTestResult entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTestResults.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
