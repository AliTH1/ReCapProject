﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarService
	{
		List<Car> GetAll();
		Car GetById(int carId);
		List<Car> GetCarsByBrandId(int brandId);
		List<Car> GetCarsByColorId(int colorId);
		void Add(Car car);
		void Update(Car car);
		void Delete(Car car);
	}
}
