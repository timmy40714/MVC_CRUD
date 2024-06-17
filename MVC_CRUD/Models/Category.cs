using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "必填項目")]
        [Display(Name = "類別名稱")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "必填項目")]
        [DisplayName("排序")]
        [Range(1,100 ,ErrorMessage ="超出範圍(1~10)")]
        public int DisplayOrder { get; set; }
    }
}
