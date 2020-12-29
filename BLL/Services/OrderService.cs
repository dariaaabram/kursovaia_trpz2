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
    public class OrderService : IOrderService
    {
        private IUnitOfWork _data;
        public OrderService(IUnitOfWork data)
        {
            _data = data;
        }

        public void Create(OrderDTO item)
        {
            var table = _data.Tables.Get(item.TableId);
            item.Price = 0;
            _data.Orders.Create(Mapper.Map<Order>(item));
            _data.Save();
        }

        public void Delete(int id)
        {
            var order = _data.Orders.Get(id);
            _data.Orders.Delete(id);
            _data.Save();
        }

        public void Dispose()
        {
            _data.Dispose();
        }

        public OrderDTO Get(int id)
        {
            return Mapper.Map<OrderDTO>(_data.Orders.Get(id));
        }

        public HashSet<OrderDTO> GetAll()
        {
            return Mapper.Map<HashSet<OrderDTO>>(_data.Orders.GetAll());
        }


        public void EditOrderDishesAmount(int orderId, int dishId, int amount)
        {
            if (amount == 0) throw new NegativeNumberException("Amount of dishes in order cannot be negative");
            var newOrder = _data.Orders.Get(orderId);
            var dish = _data.Dishes.Get(dishId);
            int difference = amount - newOrder.Dishes.Where(t => t.Id == dishId).Count();
            if(difference>0)
            {
                AddDishes(newOrder, dish, difference);
            }
            else if(difference<0)
            {
                DeleteDishes(newOrder, dish, -difference);
            }
            _data.Orders.Update(newOrder);
            _data.Dishes.Update(dish);
            _data.Save();
        }
        private void AddDishes(Order order, Dish dish, int amount)
        {
            for(int i=0; i<amount; i++)
            {
                order.Price = order.Price + dish.Price;
                order.Dishes.Add(dish);
                dish.Orders.Add(order);
            }
        }

        private void DeleteDishes(Order order, Dish dish, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                order.Price = order.Price - dish.Price;
                order.Dishes.Remove(dish);
                dish.Orders.Remove(order);
            }
        }

        public bool CheckTableExistance(int Id)
        {
            if (_data.Tables.GetAll().Select(t => t.Id).Contains(Id)) return true;
            return false;
        }

        public void EditOrderTable(int id, OrderDTO order)
        {
            if (!CheckTableExistance(order.TableId)) throw new NoAnswerException("No table with inputed Id");
            var newOrder = _data.Orders.Get(id);
            newOrder.TableId = order.TableId;
            _data.Orders.Update(newOrder);
            _data.Save();
        }

        public List<OrderDTO> GetByWord(string word)
        {
            var ordersWithIngredients= GetAll()
                .Where(o => o.Dishes
                    .Where(d => d.Ingredients
                        .Where(i=>i.Name.ToLower()
                            .Contains(word.ToLower()))
                        .Count() != 0)
                     .Count()!=0)
                .ToList();
            var ordersWithDishes = GetAll()
                .Where(o => o.Dishes
                    .Where(d => d.Name.ToLower()
                        .Contains(word.ToLower()))
                    .Count() != 0)
                 .ToList();

            return GetAll()
                .Where(t => t.Name
                    .Contains(word))
                .ToList()
                .Concat(ordersWithIngredients)
                .Concat(ordersWithDishes).ToList();
        }


    }
}
