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
    public class BeekeepingTypeConcrete : IDatabaseBusiness<BeekeepingType>
    {
        public void Add(BeekeepingType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.BeekeepingTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(BeekeepingType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.BeekeepingTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.BeekeepingTypes.Find(id);
                db.BeekeepingTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<BeekeepingType> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.BeekeepingTypes.ToList();
            }
        }

        public BeekeepingType GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.BeekeepingTypes.Find(id);
            }
        }

        public void Update(BeekeepingType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.BeekeepingTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
