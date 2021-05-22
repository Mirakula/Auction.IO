using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.EntityFramework;
using Auction.IO.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Item> itemService = new GenericDataService<Item>(new AuctionDbContextFactory());

            //try
            //{
            //    itemService.Create(new Item
            //    {
            //        Name = "Test item",
            //        Price = 123.90f,
            //        Image = null,
            //        IsDeleted = false,
            //        IsSold = false
            //    }).Wait();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message.ToString());
            //}

            try
            {
                IEnumerable<Item> items = itemService.GetAll().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska: {0}", ex.Message.ToString());
                throw;
            }


            /*CRUD Operation test => ALL PASSED*/
            //Console.WriteLine(userService.Delete(1).Result);
            //Console.WriteLine(userService.Update(1, new User { Name = "Rama", Surname = "nanazD"}).Result);
            //Console.WriteLine(userService.GetAll().Result.Count());    

            //userService.Create(new User
            //{
            //    Name = "Amar",
            //    Surname = "Dzanan",
            //    Email = "amar.dzanan@edu.fit.ba",
            //    Password = "PassWord!",
            //    Street = "Radnicka 64.",
            //    City = "Sarajevo",
            //    Country = "Bosnia & Herzegovina",
            //    DateJoined = DateTime.Now
            //}).Wait();
        }
    }
}
