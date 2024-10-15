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
    public class HoneyTypeConcrete : IDatabaseBusiness<HoneyType>
    {
        public void Add(HoneyType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(HoneyType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.HoneyTypes.Find(id);
                db.HoneyTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<HoneyType> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTypes.ToList();
            }
        }

        public HoneyType GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.HoneyTypes.Find(id);
            }
        }

        public void Update(HoneyType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.HoneyTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
