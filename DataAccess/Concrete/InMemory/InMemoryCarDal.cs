using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;

		public InMemoryCarDal()
		{
			_cars = new List<Car>();
		}

		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
			_cars.Remove(carToDelete);
		}
		public void Update(Car car)
		{
			Car updateCar = _cars.SingleOrDefault(c => c.Id == car.Id);

			updateCar.DailyPrice = car.DailyPrice;
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public Car GetById(Car car)
		{
			return _cars.SingleOrDefault(c => c.Id == car.Id);
		}
	}
}
