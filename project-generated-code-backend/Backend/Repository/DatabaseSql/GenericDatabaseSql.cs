﻿using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class GenericDatabaseSql<T> : IGenericRepository<T> where T : Entity
    {
        private const string CONNECTION_STRING =
            "User ID =postgres;Password=root;Server=localhost;Port=5432;Database=healthcare-system-db;Integrated Security=true;Pooling=true;";
        // private const string CONNECTION_STRING =
        // "server=localhost;port=3306;database=newdb;user=root;password=root";

        protected readonly HealthCareSystemDbContext DbContext;

        protected GenericDatabaseSql()
        {
            var options = new DbContextOptionsBuilder<HealthCareSystemDbContext>()
                .UseNpgsql(CONNECTION_STRING)
                // .UseMySql(CONNECTION_STRING)
                .Options;
            DbContext = new HealthCareSystemDbContext(options);
        }

        protected GenericDatabaseSql(HealthCareSystemDbContext context)
        {
            DbContext = context;
        }

        public virtual List<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Save(T newEntity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Update(T updateEntity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete(string id)
        {
            throw new System.NotImplementedException();
        }
        public virtual T GetById(string id)
        {
            throw new System.NotImplementedException();
        }
        public virtual T GetBySerialNumber(string serialNumber)
        {
            return GetAll().Where(t => t.SerialNumber.Equals(serialNumber)).ToList()[0];
        }

        public virtual T Instantiate(string objectStringFormat)
        {
            throw new System.NotImplementedException();
        }
    }
}