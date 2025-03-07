using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositeryLayer.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }  // Ensure Id exists
        [Required]
        public string greet { get; set; }
       
    }
}
