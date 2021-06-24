using ContosoFood.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContosoFood.Services
{
    public static class FoodService
    {
        static List<Food> Foods { get; }
        static int nextId = 3;
        static FoodService()
        {
            Foods = new List<Food>
            {
                new Food { Id = 1, Name = "KFC", Price = 199 },
                new Food { Id = 2, Name = "MK", Price = 599 }
            };
        }

        public static List<Food> GetAll() => Foods;

        public static Food Get(int id) => Foods.FirstOrDefault(p => p.Id == id);

        public static void Add(Food food)
        {
            food.Id = nextId++;
            Foods.Add(food);
        }

        public static void Delete(int id)
        {
            var food = Get(id);
            if(food is null)
                return;

            Foods.Remove(food);
        }

        public static void Update(Food food)
        {
            var index = Foods.FindIndex(p => p.Id == food.Id);
            if(index == -1)
                return;

            Foods[index] = food;
        }
    }
}