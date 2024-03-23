﻿using Infrastructure.Entities.SubscribersEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<SubscribeEntity> Subscribers { get; set; }
}