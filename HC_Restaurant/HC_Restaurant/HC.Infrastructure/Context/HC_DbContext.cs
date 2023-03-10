using HC.Domain.Concrete;
using HC.Domain.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HC.Infrastructure.Mapping.Concrete;
using HC.Infrastructure.SeedData;

namespace HC.Infrastructure.Context
{
    public  class HC_DbContext : IdentityDbContext<AppUser>
    {
        public HC_DbContext(DbContextOptions options): base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new EmployeeMap());
            builder.ApplyConfiguration(new OrderDetailMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new DepartmentMap());
            builder.ApplyConfiguration(new AppUserMap());

            builder.ApplyConfiguration(new CategorySeed());
            builder.ApplyConfiguration(new ProductSeed());
            builder.ApplyConfiguration(new DepartmentSeed());
            builder.ApplyConfiguration(new EmployeeSeed());

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added ||
                       x.State == EntityState.Modified ||
                       x.State == EntityState.Deleted).ToList();
                     

            DateTime date = DateTime.Now;

            foreach (var item in modifiedEntities)
            {
                IBaseEntity entity = item.Entity as IBaseEntity;

                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = date;
                            entity.Status = Domain.Enums.Status.Active;
                            break;
                        case EntityState.Modified:
                            if (entity.Status == Domain.Enums.Status.Deleted)
                            {
                                entity.DeletedDate = date;
                                entity.Status = Domain.Enums.Status.Deleted;
                            }
                            else
                            {
                                entity.UpdatedDate = date;
                                entity.Status = Domain.Enums.Status.Updated;
                            }
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
