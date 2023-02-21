using System.ComponentModel.DataAnnotations;

namespace ProjectAPI.Models
{
    public class CAR
    {
        [Key]
        public int CAR_ID { get; set; }
        [Required]
        public int CAR_CATEGORY_ID { get; set; }
        [Required]
        public string PLATE_NUMBER { get; set; }
        [Required]
        public string CAR_NAME { get; set; }
        [Required]
        public decimal PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        public int DELETED { get; set; }
        public int VERSION { get; set; }
    }
}
