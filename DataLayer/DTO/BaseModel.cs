using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTO
{
    public class BaseModel
    {
        [Key]
        public int ID { get; set; }
    }
}
