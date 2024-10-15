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
    public class BeekeeperEducationLevelConcrete : IDatabaseBusiness<BeekeeperEducationLevel>
    {
        public void Add(BeekeeperEducationLevel entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.BeekeeperEducationLevels.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(BeekeeperEducationLevel entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.BeekeeperEducationLevels.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.BeekeeperEducationLevels.Find(id);
                db.BeekeeperEducationLevels.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<BeekeeperEducationLevel> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.BeekeeperEducationLevels.ToList();
            }
        }

        public BeekeeperEducationLevel GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.BeekeeperEducationLevels.Find(id);
            }
        }

        public void Update(BeekeeperEducationLevel entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.BeekeeperEducationLevels.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
