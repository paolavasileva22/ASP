using DogApp.Abstractions;
using DogApp.Data;
using DogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Services
{
    public class DogService : IDogService
    {
        public readonly ApplicationDbContext _context;

        public DogService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string name, int age, string breed, string picture)
        {
            throw new NotImplementedException();
        }

        public Dog GetDogById(int dogId)
        {
            throw new NotImplementedException();
        }

        public List<Dog> GetDogs()
        {
            throw new NotImplementedException();
        }

        public List<Dog> GetDogs(string searchStringBreed, string searchStringName)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int dogId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDog(int dogId, string name, int age, string breed, string picture)
        {
            throw new NotImplementedException();
        }
    }
}
