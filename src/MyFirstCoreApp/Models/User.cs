using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFirstCoreApp.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Имя должно быть не более 50 символов")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Фамилия должно быть не более 50 символов")]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public ICollection<Rewarding> Rewardings { get; set; }
    }
}
