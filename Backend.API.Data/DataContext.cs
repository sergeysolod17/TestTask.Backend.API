﻿using System;
using Microsoft.EntityFrameworkCore;
using Backend.API.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace Backend.API.Data
{
    public class DataContext: DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        

        public DataContext():base()
        {}

        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {            
        }

        public DataContext(string connectionString)
            :base((new DbContextOptionsBuilder<DataContext>()).UseSqlServer(connectionString).Options)
        {            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                                       
        }
    }
}