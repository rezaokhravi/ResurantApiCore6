using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core6.Models.Entites {

    [Table ("FOODS")]
    public class Foods {
        [Key]
        [Column (Order = 1)]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [MaxLength (200)]
        [Column (Order = 3)]
        public string TITLE { get; set; }

        [Column (Order = 4)]
        public int PRICE { get; set; }=0;

        [MaxLength (500)]
        [Column (Order = 5)]
        public string? DESCRIPTIONS { get; set; }

        [Column (Order = 2)]
        public long RES_ID { get; set; }
        [ForeignKey("RES_ID")]
        public virtual Resturants Resturant { get; set; }

    }
}