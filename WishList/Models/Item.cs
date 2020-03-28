using System.ComponentModel.DataAnnotations;

namespace WishList.Models
{
    public class Item
    {
        [Required, MaxLength(50)]
        public string Description { get; set; }

        public int Id { get; set; }
    }
}
