﻿using System;
using System.Collections.Generic;
using System.Text;
using HRMapp.Models;
using System.Linq;

namespace HRMapp.DAL
{
    public class MemoryTaskContext : ITaskContext
    {
        private static List<ProductionTask> list = new List<ProductionTask>();

        public MemoryTaskContext()
        {
            if (list.Count() == 0) AddRandomItems();
        }

        public int Add(ProductionTask value)
        {
            list.Add(value);
            return value.Id;
        }

        public bool Delete(ProductionTask value)
        {
            list.Remove(value);
            return true;
        }

        public IEnumerable<ProductionTask> GetAll()
        {
            return list;
        }

        public ProductionTask GetById(int id)
        {
            return list.Single(task => task.Id == id);
        }

        public bool Update(ProductionTask value)
        {
            var item = list.Single(task => task.Id == value.Id);
            item = value;
            return true;
        }

        private void AddRandomItems()
        {
            list.Add(new ProductionTask(0, "Connector solderen 1", "Het solderen van een 4-polige connector"));
            list.Add(new ProductionTask(1, "Connector solderen 2", "Het solderen van een 8-polige connector"));
            list.Add(new ProductionTask(2, "Connector solderen 3", "Het solderen van een 16-polige connector"));
            list.Add(new ProductionTask(3, "Connector solderen 4", "Het solderen van een 32-polige connector"));
            list.Add(new ProductionTask(4, "Connector solderen 5", "Het solderen van een 64-polige connector"));
        }
    }
}
