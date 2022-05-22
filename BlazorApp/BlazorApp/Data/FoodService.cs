using System.Collections.Generic;

namespace BlazorApp.Data
{
    public class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
    public interface IFoodService
    {
        IEnumerable<Food> GetFoods();
    }
    public class FoodService : IFoodService
    {

        public IEnumerable<Food> GetFoods()
        {
            List<Food> foods = new List<Food>()
            {
                new Food() { Name ="Name_01", Price = 6000},
                new Food() { Name ="Name_02", Price = 7000},
                new Food() { Name ="Name_03", Price = 8000},
                new Food() { Name ="Name_04", Price = 9000},
            };
            return foods;
        }
    }

    public class FastFoodService : IFoodService
    {

        public IEnumerable<Food> GetFoods()
        {
            List<Food> foods = new List<Food>()
            {
                new Food() { Name ="FastFood_01", Price = 600},
                new Food() { Name ="FastFood_02", Price = 700},
                new Food() { Name ="FastFood_03", Price = 800},
            };
            return foods;
        }
    }

    public class PaymentService
    {
        IFoodService _service;

        public PaymentService(IFoodService service)
        {
            _service = service;
        }
    }

    
}
