using DogApp.Data;
using DogApp.Domain;
using DogApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Controllers
{
    public class DogsController : Controller
    {
        private readonly ApplicationDbContext context;

        public DogsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dogFromDb = new Dog
                {
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Picture,
                };

                context.Dogs.Add(dogFromDb);
                context.SaveChanges();

                return this.RedirectToAction("Success");
            }
            return this.View();
        }

        public IActionResult Success()
        {
            return this.View();
        }

        public IActionResult All(string searchStringBreed, string searchStringName)
        {
            List<DogAllViewModel> dogs = context.Dogs
                 .Select(dogFromDb => new DogAllViewModel
                 {
                     Id = dogFromDb.Id,
                     Name = dogFromDb.Name,
                     Age = dogFromDb.Age,
                     Breed = dogFromDb.Breed,
                     Picture = dogFromDb.Picture,
                 }
                 ).ToList();
            if (!String.IsNullOrEmpty(searchStringBreed)&& !String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(d => d.Breed.Contains(searchStringBreed) && d.Name.Contains(searchStringName)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringBreed))
                {
                dogs = dogs.Where(d => d.Breed.Contains(searchStringBreed)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(d => d.Breed.Contains(searchStringName)).ToList();
            }
            return View(dogs);
        }
        public IActionResult Sort()
        {
            List<DogAllViewModel> dogs = context.Dogs
                 .Select(dogFromDb => new DogAllViewModel
                 {
                     Id = dogFromDb.Id,
                     Name = dogFromDb.Name,
                     Age = dogFromDb.Age,
                     Breed = dogFromDb.Breed,
                     Picture = dogFromDb.Picture,
                 }
                 ).OrderBy(x=>x.Name).ToList();
            return View(dogs);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogEditViewModel dog = new DogEditViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }

        [HttpPost]
        public IActionResult Edit(DogEditViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dog = new Dog
                {
                    Id = bindingModel.Id,
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Picture
                };
                context.Dogs.Update(dog);
                context.SaveChanges();
                return this.RedirectToAction("All");
            }
            return View(bindingModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogDeleteViewModel dog = new DogDeleteViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            context.Dogs.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Dogs");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Dog item = context.Dogs.Find(id);
            {
                if (item == null)
                {
                    return NotFound();
                }
                DogDetailsViewModel dog = new DogDetailsViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Breed = item.Breed,
                    Picture = item.Picture
                };
                return View(dog);
            }
        }
    }
}
