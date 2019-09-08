using Shopee.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Shopee.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [Required]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual PostTag PostTag { get; set; }
        public virtual ProductTag ProductTag { get; set; }
    }
}
