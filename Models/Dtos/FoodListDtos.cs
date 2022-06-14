namespace Core6.Models.Dtos
{
    public class FoodListDtos
    {
        public long ID { get; set; }
        public string TITLE { get; set; }
        public int PRICE { get; set; }
        public string? DESCRIPTIONS { get; set; }
        public long RES_ID { get; set; }
        public string RES_TITLE { get; set; }
    }
}