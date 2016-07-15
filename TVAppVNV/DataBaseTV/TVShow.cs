using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class TVShow
    {
        public TVShow()
        {

        }
        // set Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // set show name
        [MinLength(2, ErrorMessage = "Too short name")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        // date of a show broadcasting
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime Date { get; set; }

        // set show name
        [MaxLength(255)]
        [DefaultValue(null)]
        public string Description { get; set; }

        // false if a show does not have age limitations
        [DefaultValue(false)]
        public bool AgeLimit { get; set; }

        // set ID from Channel table
        //[Required]
        //public virtual Channel Channel { get; set; }
    }
}