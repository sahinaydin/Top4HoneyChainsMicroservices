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
    public class ApirayTreatmentMethodConcrete : IDatabaseBusiness<ApirayTreatmentMethod>
    {
        public void Add(ApirayTreatmentMethod entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApirayTreatmentMethods.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(ApirayTreatmentMethod entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApirayTreatmentMethods.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.ApirayTreatmentMethods.Find(id);
                db.ApirayTreatmentMethods.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<ApirayTreatmentMethod> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.ApirayTreatmentMethods.ToList();
            }
        }

        public ApirayTreatmentMethod GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.ApirayTreatmentMethods.Find(id);
            }
        }

        public void Update(ApirayTreatmentMethod entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApirayTreatmentMethods.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
