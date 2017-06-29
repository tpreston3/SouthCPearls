using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SouthSea.Models;

namespace SouthSea.Data
{
    public class GemStoneInitializer
    {

        public static void Initialize(SouthSeaContext context) { 
            //if (!context.GemStone.Equals(null))
            //{
            //    return;
            //}

            
                var gems = new GemStone[]

                {
            new GemStone
            {
                TypeStone="Carnilian Stone"
            },

            new GemStone
            {
                TypeStone = "Hematites with Coral"
            },
            new GemStone
            {
                TypeStone = "Blue Moon Stone"
            },

            new GemStone
            {
                TypeStone = "Amethyst Stone"
            },
            new GemStone
            {
                TypeStone = "Cherry Squarts"
            },

            new GemStone
            {
                TypeStone = "Hematites with Turkoys"

            },

            new GemStone
            {
                TypeStone = "Hematites with Pearl"

            },
            new GemStone
            {
                TypeStone = "Tiger Eye"

            },
            new GemStone
            {
                TypeStone = "Black Pearl"

            },
            new GemStone
            {
                TypeStone = "Turquios"

            },
            new GemStone
            {
                TypeStone = "Morano Stones"

            },
            new GemStone
            {
                TypeStone = "Rose Squarts"

            },
            new GemStone
            {
                TypeStone = "Sun Stones"

            },
            new GemStone
            {
                TypeStone = "Red Corals"

            },
            new GemStone
            {
                TypeStone = "Whole Light"

            },
            new GemStone
            {
                TypeStone = "Black & White Pearls"

            },
            new GemStone
            {
                TypeStone = "Puka Shell"

            },
            new GemStone
            {
                TypeStone = "Moon Stone"

            },
            new GemStone
            {
                TypeStone = "Jade"

            }

                };
            foreach (var g in gems)
            {
                context.GemStone.Add(g);

            }

            context.SaveChanges();

        }

        }
    }

