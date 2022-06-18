using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core6.Models.Entites
{
    [Table("RESTURANTS")]
    public class Resturants
    {

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [MaxLength(200)]
        [Column(Order = 2)]
        public string TITLE { get; set; }

        [MaxLength(7)]
        [Column(Order = 3)]
        public string? PHONE { get; set; }

        [MaxLength(11)]
        [Column(Order = 4)]
        public string? MOBILE { get; set; }

        [MaxLength(500)]
        [Column(Order = 5)]
        public string? ADDRESS { get; set; }

        [MaxLength(500)]
        [Column(Order = 6)]
        public string? DESCRIPTIONS { get; set; }
        public virtual ICollection<Foods> Foods { get; set; }
    }
}