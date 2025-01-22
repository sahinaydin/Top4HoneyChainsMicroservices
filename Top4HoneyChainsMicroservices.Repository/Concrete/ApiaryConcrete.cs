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
    public class ApiaryConcrete : IDatabaseBusiness<Apiary>
    {
        public void Add(Apiary entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.Apiaries.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(Apiary entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.Apiaries.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.Apiaries.Find(id);
                db.Apiaries.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Apiary> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.Apiaries.ToList();
            }
        }

        public Apiary GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.Apiaries.Find(id);
            }
        }

        public void Update(Apiary entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.Apiaries.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Apiary> GetApiaryByBeekeeperId(Guid beekeeperId)
		{
			using (var db = new Top4honeyChainsDbContext())
			{
				return db.Apiaries.Where(x => x.BeekeeperId == beekeeperId).ToList();
			}
		}

    }
}
