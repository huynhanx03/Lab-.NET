using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarManagement
    {// Singleton Pattern
        private static CarManagement instance = null;
        private static readonly object instanceLock = new object();
        private CarManagement() { }

        public static CarManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarManagement();
                    }
                }
                return instance;
            }
        }

        // Get a list of all cars
        public IEnumerable<Car> GetCarList()
        {
            List<Car> cars;
            try
            {
                var myStockDB = new MyStockContext();
                cars = myStockDB.Cars.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cars;
        }

        // Get a car by its ID
        public Car GetCarByID(int carID)
        {
            Car car = null;
            try
            {
                var myStockDB = new MyStockContext();
                car = myStockDB.Cars.SingleOrDefault(car => car.CarID == carID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }

        // Add a new car
        public void AddNew(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarID);
                if (_car == null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Add(car);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update an existing car
        public void Update(Car car)
        {
            try
            {
                Car c = GetCarByID(car.CarID);
                if (c != null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Entry<Car>(car).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Remove a car by ID
        public void Remove(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarID);
                if (_car != null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Remove(car);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
