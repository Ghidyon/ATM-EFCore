using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ATM_DAL.Model
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(4)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [MinLength(4)]
        [Required]
        public string Pin { get; set; }

        public int AccountBalance { get; set; }

        public int AccountNumber { get; set; }

        public DateTime DateCreated { get; set; }
    }
}