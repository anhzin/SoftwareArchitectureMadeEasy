using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataContracts
{
    [DataContract]
    public class Attendee : BaseTable
    {

        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }


        [DataMember]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [DataMember]
        [Display(Name = "Email Address")]
        public string Email { get; set; }


    }
}
