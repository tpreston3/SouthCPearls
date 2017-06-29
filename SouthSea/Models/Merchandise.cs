using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Image { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        [Display(Name = "Gem Stone Type")]
        public GemStone GemStones { get; set; }

        [NotMapped]
        [DataType(DataType.DateTime)]
        public DateTime TheDate
        {
            //get { return TheDate; }
            set { TheDate = DateTime.Now; }
        }
        [Display(Name = "Length in inches")]
        public float Length { get; set; }

        [Display(Name = "Weight in grams")]
        public float Weight { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

    }
}
