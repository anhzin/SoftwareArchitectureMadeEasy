using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataContracts
{
    [DataContract]
    public class Registration :BaseTable
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        public RegistrationType RegistrationType { get; set; }
        
       [DataMember]
       public int? AttendeeId { get; set; }
        
        [DataMember]
        [ForeignKey("AttendeeId")]
        public virtual Attendee Attendee { get; set; }
        
    }
}
