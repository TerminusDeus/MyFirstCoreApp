using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstCoreApp.Models
{
    public class Rewarding
    {
        // TO-DO: DELETE
        [NotMapped]
        public int RewardingID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AwardID { get; set; }

        public Award Award { get; set; }
        public User User { get; set; }
    }
}
