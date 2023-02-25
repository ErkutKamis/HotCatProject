using HC.Domain.Concrete;
using HC.Domain.Enums;
using HC.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Infrastructure.SeedData
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { ID = Guid.Parse("1DD2e49b-9c8d-4d44-a508-eb12a50c28d8"), ProductName = "Maki Sushi", Description = "Maki sushi is a sushi roll with the seaweed.", UnitPrice = 10.99m, UnitInStock = 250, Status = Status.Active , CategoryID = Guid.Parse("1C42e49b-9c8d-4d44-a508-eb12a50c28d8") },

                new Product { ID = Guid.NewGuid(), ProductName = "Maki Hoso", Description = "Boiling vegetables, serving with special hot sauce", UnitPrice = 8.99m, UnitInStock = 300, Status = Status.Active , CategoryID = Guid.Parse("1C42e49b-9c8d-4d44-a508-eb12a50c28d8") },

                new Product { ID = Guid.NewGuid(), ProductName = "California Roll", Description = "A sushi roll filled with crab meat, avocado, and cucumber.", UnitPrice = 12.99m, UnitInStock = 200, Status = Status.Active , CategoryID = Guid.Parse("2C42e49b-9c8d-4d44-a508-eb12a50c28d8") },

                new Product { ID = Guid.NewGuid(), ProductName = "Nigiri Sushi", Description = "Thin slices of raw fish served over a small ball of sushi rice.", UnitPrice = 15.99m, UnitInStock = 150, Status = Status.Active,  CategoryID = Guid.Parse("2C42e49b-9c8d-4d44-a508-eb12a50c28d8") },

                new Product { ID = Guid.NewGuid(), ProductName = "Ramen Noodle Soup", Description = "Japanese wheat noodle soup with a variety of toppings, such as sliced pork, dried seaweed, and green onions.", UnitPrice = 11.99m, UnitInStock = 250, Status = Status.Active , CategoryID = Guid.Parse("3C42e49b-9c8d-4d44-a508-eb12a50c28d8") },

                new Product { ID = Guid.NewGuid(), ProductName = "Udon Noodle Soup", Description = "Japanese wheat noodle soup with a variety of toppings, such as tempura, seafood, and eggs.", UnitPrice = 13.99m, UnitInStock = 200, Status = Status.Active , CategoryID = Guid.Parse("3C42e49b-9c8d-4d44-a508-eb12a50c28d8") },

                new Product { ID = Guid.NewGuid(), ProductName = "Tempura", Description = "Deep-fried seafood and vegetables, served with a special dipping sauce.", UnitPrice = 14.99m, UnitInStock = 175, Status = Status.Active , CategoryID = Guid.Parse("3C42e49b-9c8d-4d44-a508-eb12a50c28d8") }
                );
        }
    }
}
