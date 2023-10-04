using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Color = Entities.Concrete.Color;

namespace DataAccess.Concrete.EntityFramework
{
	public class EFColorDal : IEntityRepository<Color>
	{
		public void Add(Color entity)
		{
			using (ReCapContext context = new ReCapContext())
			{
				EntityEntry addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Added;
				context.SaveChanges();
			}
		}

		public void Update(Color entity)
		{
			using (ReCapContext context = new ReCapContext())
			{
				EntityEntry updatedEntity = context.Entry(entity);
				updatedEntity.State = EntityState.Modified;
				context.SaveChanges();
			}
		}

		public void Delete(Color entity)
		{
			using (ReCapContext context = new ReCapContext())
			{
				EntityEntry deletedEntity = context.Entry(entity);
				deletedEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public Color Get(Expression<Func<Color, bool>> filter)
		{
			using (ReCapContext context = new ReCapContext())
			{
				return context.Set<Color>().SingleOrDefault(filter);
			}
		}

		public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
		{
			using (ReCapContext context = new ReCapContext())
			{
				return filter == null
					? context.Set<Color>().ToList()
					: context.Set<Color>().Where(filter).ToList();
			}
		}

	}
}
