﻿using Microsoft.EntityFrameworkCore;
using SmartHomeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeSystem.Context
{
    public class SmartHomeSystemDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySQL("server = localhost; database = bsmartdb; user = root; password = ");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }

        public DbSet<UserHome> UserHomes { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<NumberParameter> NumberParameters { get; set; }
        public DbSet<StringParameter> StringParameters { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
    }
}
