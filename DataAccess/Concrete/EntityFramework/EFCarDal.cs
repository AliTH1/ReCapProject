﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EFCarDal : IEntityRepository<Car>
	{
		public void Add(Car entity)
		{
			using (ReCapContext context = new ReCapContext())
			{
				EntityEntry addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Added;
				context.SaveChanges();
			}
		}
		public void Update(Car entity)
		{
			using (ReCapContext context = new ReCapContext())
			{
				EntityEntry updatedEntity = context.Entry(entity);
				updatedEntity.State = EntityState.Modified;
				context.SaveChanges();
			}
		}

		public void Delete(Car entity)
		{
			using (ReCapContext context = new ReCapContext())
			{
				EntityEntry deletedEntity = context.Entry(entity);
				deletedEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			using (ReCapContext context = new ReCapContext())
			{
				return context.Set<Car>().SingleOrDefault(filter);
			}
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			using (ReCapContext context = new ReCapContext())
			{
				return filter == null
					? context.Set<Car>().ToList()
					: context.Set<Car>().Where(filter).ToList();
			}
		}

	}
}
