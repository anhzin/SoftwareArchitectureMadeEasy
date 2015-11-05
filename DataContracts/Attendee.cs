﻿using System;
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
        public string FirstName { get; set; }


        [DataMember]
        public string LastName { get; set; }


        [DataMember]
        public string Email { get; set; }


    }
}
