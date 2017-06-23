using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace SouthSea.Models
{
    public class Merchandise
    {

        public int ID { get; set; }
        [Required]
        [Display(Name ="Item Name")]
        public string ItemName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        [DataType(DataType.DateTime)]
        public int Date { get; set; }
        [Display(Name = "Gem Stone Type")]
        //public ICollection<GemStone> GemStones { get; set; }
        public GemStone GemStones { get; set; }

        public DateTime TheDate
        {
            get { return TheDate; }
            set { TheDate = DateTime.Now; }
        }
                
        public int Length { get; set; }
        public int Weight { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

    }
}
