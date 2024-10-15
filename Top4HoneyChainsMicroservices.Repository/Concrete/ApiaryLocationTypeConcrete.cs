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
    public class ApiaryLocationTypeConcrete : IDatabaseBusiness<ApiaryLocationType>
    {
        public void Add(ApiaryLocationType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApiaryLocationTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(ApiaryLocationType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApiaryLocationTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.ApiaryLocationTypes.Find(id);
                db.ApiaryLocationTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<ApiaryLocationType> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.ApiaryLocationTypes.ToList();
            }
        }

        public ApiaryLocationType GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.ApiaryLocationTypes.Find(id);
            }
        }

        public void Update(ApiaryLocationType entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.ApiaryLocationTypes.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
