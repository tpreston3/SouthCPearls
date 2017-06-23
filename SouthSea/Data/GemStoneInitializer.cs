using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthSea.Data
{
    public class GemStoneInitializer
    {

        public static void Initialize(Models.Merchandise context)
        {
            if (!context.GemStones.Equals(null))
            {
                return;
            }
            var gems = new Models.GemStone[]

            {
            new Models.GemStone
            {
                TypeStone="Carnilian Stone"
            },

            new Models.GemStone
            {
                TypeStone = "Hematites with Coral"
            },
            new Models.GemStone
            {
                TypeStone = "Blue Moon Stone"
            },

            new Models.GemStone
            {
                TypeStone = "Amethyst Stone"
            },
            new Models.GemStone
            {
                TypeStone = "Cherry Squarts"
            },

            new Models.GemStone
            {
                TypeStone = "Hematites with Turkoys"

            },

            new Models.GemStone
            {
                TypeStone = "Hematites with Pearl"

            },
            new Models.GemStone
            {
                TypeStone = "Tiger Eye"

            },
            new Models.GemStone
            {
                TypeStone = "Black Pearl"

            },
            new Models.GemStone
            {
                TypeStone = "Turquios"

            },
            new Models.GemStone
            {
                TypeStone = "Morano Stones"

            },
            new Models.GemStone
            {
                TypeStone = "Rose Squarts"

            },
            new Models.GemStone
            {
                TypeStone = "Sun Stones"

            },
            new Models.GemStone
            {
                TypeStone = "Red Corals"

            },
            new Models.GemStone
            {
                TypeStone = "Whole Light"

            },
            new Models.GemStone
            {
                TypeStone = "Black & White Pearls"

            },
            new Models.GemStone
            {
                TypeStone = "Puka Shell"

            },
            new Models.GemStone
            {
                TypeStone = "Moon Stone"

            },
            new Models.GemStone
            {
                TypeStone = "Jade"

            }

            };
        }

        }
    }

