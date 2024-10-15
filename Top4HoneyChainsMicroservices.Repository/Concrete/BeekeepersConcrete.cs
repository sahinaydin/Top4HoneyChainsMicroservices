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
    public class BeekeepersConcrete : IDatabaseBusiness<Beekeeper>
    {
        public void Add(Beekeeper entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.Beekeepers.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(Beekeeper entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.Beekeepers.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void DeleteByGuidId(Guid id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.Beekeepers.Find(id);
                db.Beekeepers.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.Beekeepers.Find(id);
                db.Beekeepers.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Beekeeper> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.Beekeepers.ToList();
            }
        }

        public Beekeeper GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.Beekeepers.Find(id);
            }
        }

        public Beekeeper GetByIdentityNumber(string identitynumber)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.Beekeepers.Where(b => b.IdentityNumber == identitynumber).FirstOrDefault();
            }
        }

        public void Update(Beekeeper entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.Beekeepers.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


    }
}
