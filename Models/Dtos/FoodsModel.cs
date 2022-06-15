using System.ComponentModel.DataAnnotations;

namespace ResurantApiCore6.Models.Dtos
{
    public class FoodsInsertModel
    {
        [Required]
        public string TITLE { get; set; }
        public int PRICE { get; set; } = 0;
        public string? DESCRIPTIONS { get; set; }
        [Required]
        public long RES_ID { get; set; }
    }

     public class FoodsUpdateModel
    {
         [Required]
        public long ID { get; set; }
        [Required]
        public string TITLE { get; set; }
        public int PRICE { get; set; } = 0;
        public string? DESCRIPTIONS { get; set; }
        [Required]
        public long RES_ID { get; set; }
    }
}