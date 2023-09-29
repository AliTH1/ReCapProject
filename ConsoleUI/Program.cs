using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new InMemoryCarDal());
Car car = new Car();
car.Id = 1;
car.Description = "Ali";

carManager.Add(car);


foreach (var item in carManager.GetAll())
{
    Console.WriteLine(item.Description);
}