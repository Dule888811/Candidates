using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace Candidates.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public long JMGB { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

        public string Note { get; set; }

        [Required]
        public bool employed { get; set; }

        public DateTime changes { get; set; }


    }
}