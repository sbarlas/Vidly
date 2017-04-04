using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name="Date of Birth")]
        public Nullable<DateTime> DateOfBirth { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int Age
        {
            get
            {
                if (DateOfBirth != null)
                {
                    var today = DateTime.Today;
                    var birthdate = (DateTime)DateOfBirth;
                    var a = (today.Year * 100 + today.Month) * 100 + today.Day;
                    var b = (birthdate.Year * 100 + birthdate.Month) * 100 + birthdate.Day;

                    return (a - b) / 10000;
                }

                return -1;
            }

        }

        public bool IsSubscribedToNewsletter { get; set; }
        public bool IsActive { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }

}