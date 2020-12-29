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
    public class IngredientService : IIngredientService
    {
        private IUnitOfWork _data;
        public IngredientService(IUnitOfWork data)
        {
            _data = data;
        }

        public void Create(IngredientDTO item)
        {
            _data.Ingredients.Create(Mapper.Map<Ingredient>(item));
            _data.Save();
        }

        public void Delete(int id)
        {
            try
            {
                var ingredient = _data.Ingredients.Get(id);
                if (ingredient.Dishes.Count != 0) return;
                _data.Ingredients.Delete(id);
                _data.Save();
            }
            catch (Exception ex)
            {
                throw new NoAnswerException(ex.Message);
                    
            }
        }

        public void Dispose()
        {
            _data.Dispose();
        }

        public IngredientDTO Get(int id)
        {
            try
            {
                return Mapper.Map<IngredientDTO>(_data.Ingredients.Get(id));
            }
            catch (Exception ex)
            {
                throw new NoAnswerException(ex.Message);

            }
        }

        public HashSet<IngredientDTO> GetAll()
        {
            return Mapper.Map<HashSet<IngredientDTO>>(_data.Ingredients.GetAll());
        }


        public void EditIngredient(int id, IngredientDTO ingredient)
        {
            if (ingredient.Name.Length<1)throw new AbsentDataException("Name of ingredient cannot be empty");
            try
            {
                var newIngredient = _data.Ingredients.Get(id);
                newIngredient.Name = ingredient.Name;
                _data.Ingredients.Update(newIngredient);
                _data.Save();
            }
            catch (Exception ex)
            {
                throw new NoAnswerException(ex.Message);

            }
        }

        public List<IngredientDTO> GetByWord(string word)
        {
            return GetAll().Where(t=>t.Name.ToLower().Contains(word.ToLower())).ToList();        
        }


    }
}
