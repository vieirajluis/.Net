
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesReport.Models.Entity
{
    
    /// <summary>
    /// Entity Class Sales.
    /// These Properties/Fields will be created in the database.
    /// </summary>
    public class Sales
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DealNumber { get; set; }

        [MaxLength(100)]
        public string DealershipName { get; set; }

        [MaxLength(60)]
        public string CustomerName { get; set; }

        [MaxLength(200)]
        public string Vehicle { get; set; }

       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [MaxLength(200)]
        public string SoldMost { get; set; } 

    }

    
}