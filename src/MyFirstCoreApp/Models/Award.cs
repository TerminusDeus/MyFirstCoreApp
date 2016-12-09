using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstCoreApp.Models
{
    public class Award
    {
        public int ID { get; set; }
        [Description("Title samp desc")]
        [Column( Order = 2)]
        [Required]
        [MaxLength(50, ErrorMessage = "Название должно быть не более 50 символов")]
        public string Title { get; set; }
        [Column(Order = 3)]
        [MaxLength(250, ErrorMessage = "Описание должно быть не более 250 символов")]
        public string Description { get; set; }
        public ICollection<Rewarding> Rewardings { get; set; }
    }
}
