using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Abstract;

namespace Top4HoneyChainsMicroservices.Repository.Concrete
{
    public class ApiaryDiseaseConcrete : IDatabaseBusiness<ApiaryDisease>
    {
        public void Add(ApiaryDisease entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApiaryDiseases.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(ApiaryDisease entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApiaryDiseases.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.ApiaryDiseases.Find(id);
                db.ApiaryDiseases.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<ApiaryDisease> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.ApiaryDiseases.ToList();
            }
        }

        public ApiaryDisease GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.ApiaryDiseases.Find(id);
            }
        }

        public void Update(ApiaryDisease entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApiaryDiseases.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
