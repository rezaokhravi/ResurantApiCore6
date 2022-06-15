using System.ComponentModel.DataAnnotations;

namespace ResurantApiCore6.Models.Dtos
{
    public class ResturantsInsertModel
    {
        [Required]
        public string TITLE { get; set; }
        public string? PHONE { get; set; }
        public string? MOBILE { get; set; }
        public string? ADDRESS { get; set; }
        public string? DESCRIPTIONS { get; set; }
    }

    public class ResturantsUpdateModel
    {
        [Required]
        public long ID { get; set; }
        [Required]
        public string TITLE { get; set; }
        public string? PHONE { get; set; }
        public string? MOBILE { get; set; }
        public string? ADDRESS { get; set; }
        public string? DESCRIPTIONS { get; set; }
    }
}