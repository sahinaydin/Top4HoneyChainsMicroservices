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
    public class TreatmentMethodConcrete : IDatabaseBusiness<TreatmentMethod>
    {
        public void Add(TreatmentMethod entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.TreatmentMethods.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(TreatmentMethod entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.TreatmentMethods.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.TreatmentMethods.Find(id);
                db.TreatmentMethods.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<TreatmentMethod> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.TreatmentMethods.ToList();
            }
        }

        public TreatmentMethod GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.TreatmentMethods.Find(id);
            }
        }

        public void Update(TreatmentMethod entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.TreatmentMethods.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
