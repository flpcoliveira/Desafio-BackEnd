using Microsoft.EntityFrameworkCore;
using MotoRentManager.Application.Common.Interfaces;
using MotoRentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoRentManager.Infra.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IUnitOfWork
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
