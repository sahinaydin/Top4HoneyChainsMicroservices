using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Entities.ViewModels;
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

		public BeekeeperViewModel GetBeekeeperById(Guid beekeperid)
		{
			using (var db = new Top4honeyChainsDbContext())
			{
                var result  = (from b in db.Beekeepers
							 join el in db.BeekeeperEducationLevels on b.EducationLevel equals el.LevelId
							 join pt in db.BeekeepingPurposeTypes on b.BeekeepingPurposeType equals pt.TypeId
							 join bt in db.BeekeepingTypes on b.BeekeepingType equals bt.TypeId
                             where b.BeekeeperId == beekeperid
                             select new BeekeeperViewModel
                             {
                                 BeekeeperId = b.BeekeeperId,
                                 ProfilePhoto = b.ProfilePhoto,
                                 FirstName = b.FirstName,
                                 LastName = b.LastName,
                                 IdentityNumber = b.IdentityNumber,
                                 BirthDate = b.BirthDate,
                                 ExperienceTime = b.ExperienceTime,
                                 EducationLevel = el.LevelId,
                                 EducationLevelTitle = el.LevelTitle,
                                 PhoneNumber = b.PhoneNumber,
                                 AssociationMembership = b.AssociationMembership,
                                 BusinessNumber = b.BusinessNumber,
                                 BeekeepingPurposeType = pt.TypeId,
                                 BeekeepingPurposeTypeTitle = pt.TypeTitle,
                                 BeekeepingType = bt.TypeId,
                                 BeekeepingTypeTitle = bt.TypeTitle
                             }).FirstOrDefault();
                return result;
			}
		}
	}
}
