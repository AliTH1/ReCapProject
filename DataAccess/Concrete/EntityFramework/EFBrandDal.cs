using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EFBrandDal : IEntityRepository<Brand>
	{
		IBrandDal _brandDal;

		public EFBrandDal(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public void Add(Brand entity)
		{
			using (ReCapContext context = new ReCapContext())
			{
				EntityEntry addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Added;
				context.SaveChanges();
			}
		}

		public void Update(Brand entity)
		{
			using (ReCapContext context = new ReCapContext())
			{
				EntityEntry updatedEntity = context.Entry(entity);
				updatedEntity.State = EntityState.Modified;
				context.SaveChanges();
			}
		}

		public void Delete(Brand entity)
		{
			using (ReCapContext context = new ReCapContext())
			{
				EntityEntry deletedEntity = context.Entry(entity);
				deletedEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public Brand Get(Expression<Func<Brand, bool>> filter)
		{
			using (ReCapContext context = new ReCapContext())
			{
				return context.Set<Brand>().SingleOrDefault(filter);
			}
			
		}

		public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
		{
			using (ReCapContext context = new ReCapContext())
			{
				return filter == null
					? context.Set<Brand>().ToList()
					: context.Set<Brand>().Where(filter).ToList();
			}
		}
	}
}
