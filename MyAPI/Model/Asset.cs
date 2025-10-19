using System.ComponentModel.DataAnnotations;

namespace MyAPI.Model
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        [Required]
        public string ItemName { get; set; }

    }
}
