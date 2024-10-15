using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Abstract;

namespace Top4HoneyChainsMicroservices.Repository.Concrete
{
    public class DiseaseConcrete : IDatabaseBusiness<Disease>
    {
        public void Add(Disease entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.Diseases.Attach(entity);
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(Disease entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.Diseases.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                var entity = db.Diseases.Find(id);
                db.Diseases.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Disease> GetAll()
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.Diseases.ToList();
            }
        }

        public Disease GetById(int id)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                return db.Diseases.Find(id);
            }
        }

        public void Update(Disease entity)
        {
            using (var db = new Top4honeyChainsDbContext())
            {
                db.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
