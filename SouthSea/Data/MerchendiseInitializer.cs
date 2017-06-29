using SouthSea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthSea.Data
{
    public static class MerchendiseInitializer
    {

        public static void Initialize(SouthSeaContext context)
        {
            context.Database.EnsureCreated();

            //if (!context.Merchandise.Any())
            //{

            //    // if the there is an ID in the context (DB) return and don't procced with Init method
            //    return ;
            //}

            var merchandise = new Merchandise[]{
                new  Merchandise
                {
                   ItemName = "Jade Necklace",
                   Description = "Necklace",
                   Type = "Jade",
                   Image = "C:\\Users\\Thaddeus\\Documents\\" +
                   "Visual Studio 2017\\Projects\\SouthSea\\SouthSea\\wwwroot\\" +
                   "images\\Merchandise\\TestItemIMG.jpg",
                   Date = DateTime.Now,
                   //GemStones = new Models.GemStone {ID=1, TypeStone="Carnilian Stone"},
                   Length = 1,
                   Weight= 1,
                   Price = 45.00m


                }
            };
            foreach (var m in merchandise)
            {
                context.Merchandise.Add(m);
            }

            context.SaveChanges();

            }

        }

          

    }

