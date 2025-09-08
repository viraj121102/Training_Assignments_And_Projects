//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace MVCExample.Models
//{
//    //[Table("AppUsers")] // this is optional and if we give table annotaion then while migration it set this name of the table.
//    public class User
//    {
//        [Key]
//        public int Id { get; set; }

//        [Required(ErrorMessage ="Name is required")]
//        [StringLength(100, ErrorMessage ="Name can not exceed 50 characters")]
//        [Display(Name = "Full Name")]
//        public string Name { get; set; }

//        [EmailAddress(ErrorMessage ="Invalid email Format")]
//        public string Email { get; set; }

//        [DataType(DataType.Password)]
//        public string Password { get; set; }

//        [Range(0,100, ErrorMessage = "Age should be 0 to 100")]
//        public int Age { get; set; }

//        [Required]
//        [MaxLength(400)]
//        public string description { get; set; }

//        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
//        public DateTime TimeStamp { get; set; }

//    }
//}
