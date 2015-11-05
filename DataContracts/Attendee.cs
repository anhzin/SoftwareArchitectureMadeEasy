﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    [DataContract]
    public class Attendee : BaseTable
    {

        [DataMember]
        public string FirstName { get; set; }


        [DataMember]
        public string LastName { get; set; }


        [DataMember]
        public string Email { get; set; }


    }
}
