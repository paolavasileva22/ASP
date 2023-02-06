using DogApp.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DogApp.Models;

namespace DogApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogApp.Models.DogEditViewModel> DogEditViewModel { get; set; }
        public DbSet<DogApp.Models.DogDeleteViewModel> DogDeleteViewModel { get; set; }
        public DbSet<DogApp.Models.DogDetailsViewModel> DogDetailsViewModel { get; set; }
        public DbSet<DogApp.Models.DogAllViewModel> DogAllViewModel { get; set; }
    }
}
