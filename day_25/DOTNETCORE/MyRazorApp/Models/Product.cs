using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRazorApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("categ")] 
        public int categId { get; set; }
        public Category categ { get; set; }
    }
}
