using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class DishService:IDishService
    {
        private IUnitOfWork _data;
        public DishService(IUnitOfWork data)
        {
            _data = data;
        }

        public void Create(DishDTO item)
        {
            if (item.Price == 0 || item.Time == 0 || item.Weight == 0) throw new AbsentDataException("Parameters like time, weight or price cannot be 0");
            _data.Dishes.Create(Mapper.Map<Dish>(item));
            _data.Save();
        }

        public void Delete(int id)
        {
            var dish = _data.Dishes.Get(id);
            _data.Dishes.Delete(id);
            _data.Save();
        }

        public void Dispose()
        {
            _data.Dispose();
        }

        public DishDTO Get(int id)
        {
            return Mapper.Map<DishDTO>(_data.Dishes.Get(id));
        }

        public HashSet<DishDTO> GetAll()
        {
            return Mapper.Map<HashSet<DishDTO>>(_data.Dishes.GetAll());
        }


        public void EditDishPrice(int id, DishDTO dish)
        {
            if (dish.Price == 0) throw new AbsentDataException("Parameters like time, weight or price cannot be 0");
            var newDish = _data.Dishes.Get(id);
            newDish.Price = dish.Price;
             _data.Dishes.Update(newDish);
            _data.Save();
        }

        public void EditDishWeight(int id, DishDTO dish)
        {
            if (dish.Weight == 0) throw new AbsentDataException("Parameters like time, weight or price cannot be 0");
            var newDish = _data.Dishes.Get(id);
            newDish.Weight = dish.Price;
            _data.Dishes.Update(newDish);
            _data.Save();
        }

        public void EditDishName(int id, DishDTO dish)
        {
            if (dish.Name =="") throw new AbsentDataException("Name of dish cannot be empty");
            var newDish = _data.Dishes.Get(id);
            newDish.Name = dish.Name;
           _data.Dishes.Update(newDish);
            _data.Save();
        }
        public void EditDishTime(int id, DishDTO dish)
        {
            if (dish.Time == 0) throw new AbsentDataException("Parameters like time, weight or price cannot be 0");
            var newDish = _data.Dishes.Get(id);
            newDish.Time = dish.Time;
            _data.Dishes.Update(newDish);
            _data.Save();
        }

        public void AddDishIngredient(int dishId, int ingredientId)
        {
            var newDish = _data.Dishes.Get(dishId);
            var ingredient = _data.Ingredients.Get(ingredientId);
            newDish.Ingredients.Add(ingredient);
            ingredient.Dishes.Add(newDish);
            _data.Dishes.Update(newDish);
            _data.Ingredients.Update(ingredient);
            _data.Save();
        }

        public void DeleteDishIngredient(int dishId, int ingredientId)
        {
            var newDish = _data.Dishes.Get(dishId);
            var ingredient = _data.Ingredients.Get(ingredientId);
            if(!newDish.Ingredients.Contains(ingredient))
            {
                throw new NoAnswerException("Cannot delete ingredient from dish - no such ingredient");
            }
            newDish.Ingredients.Remove(ingredient);
            ingredient.Dishes.Remove(newDish);
            _data.Dishes.Update(newDish);
            _data.Ingredients.Update(ingredient);
            _data.Save();
        }
        public List<DishDTO> GetByWord(string word)
        {
            List<DishDTO> dishesWithIngredients = GetAll().Where(d => d.Ingredients.Where(i => i.Name.Contains(word)).Count() != 0).ToList();

            return GetAll().Where(t => t.Name.Contains(word)).ToList().Concat(dishesWithIngredients).ToList();
        }

    }
}
