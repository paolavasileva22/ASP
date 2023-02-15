using DogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Abstractions
{
    public interface IDogService
    {
        public bool Create(string name, int age, string breed, string picture);
        public bool UpdateDog(int dogId, string name, int age, string breed, string picture);
        public List<Dog> GetDogs();
        public Dog GetDogById(int dogId);
        public bool RemoveById(int dogId);
        public List<Dog> GetDogs(string searchStringBreed, string searchStringName);
    }
}
