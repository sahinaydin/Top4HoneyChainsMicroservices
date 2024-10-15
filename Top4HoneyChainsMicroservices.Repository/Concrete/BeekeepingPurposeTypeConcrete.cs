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
    public class BeekeepingPurposeTypeConcrete : IDatabaseBusiness<BeekeepingPurposeType>
    {
        public void Add(BeekeepingPurposeType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.BeekeepingPurposeTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(BeekeepingPurposeType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.BeekeepingPurposeTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.BeekeepingPurposeTypes.Find(id);
                db.BeekeepingPurposeTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<BeekeepingPurposeType> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.BeekeepingPurposeTypes.ToList();
            }
        }

        public BeekeepingPurposeType GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.BeekeepingPurposeTypes.Find(id);
            }
        }

        public void Update(BeekeepingPurposeType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.BeekeepingPurposeTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
