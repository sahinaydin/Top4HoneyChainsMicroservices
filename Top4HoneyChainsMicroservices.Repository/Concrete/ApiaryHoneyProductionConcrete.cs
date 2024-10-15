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
    public class ApiaryHoneyProductionConcrete : IDatabaseBusiness<ApiaryHoneyProduction>
    {
        public void Add(ApiaryHoneyProduction entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApiaryHoneyProductions.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(ApiaryHoneyProduction entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApiaryHoneyProductions.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.ApiaryHoneyProductions.Find(id);
                db.ApiaryHoneyProductions.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<ApiaryHoneyProduction> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.ApiaryHoneyProductions.ToList();
            }
        }

        public ApiaryHoneyProduction GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.ApiaryHoneyProductions.Find(id);
            }
        }

        public void Update(ApiaryHoneyProduction entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApiaryHoneyProductions.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
