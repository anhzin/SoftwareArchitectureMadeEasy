using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DataContracts;
using UnityResolver;


namespace RegistrationEngine
{
    public class RegistrationEngine : IRegistrationEngine       
    {
        public ICollection<Attendee> ProcessAttendees(UserContext userContext, ICollection<Attendee> attendees)
        {           
            List<Attendee> registrationAttendees = new List<Attendee>();

            foreach (Attendee attendee in attendees)
            {
                Attendee CheckedAttendee = new Attendee();
                CheckedAttendee =  UnityCache.ResolveDefault<IRegistrationAccessor>().FindAttendee(userContext, attendee);

                registrationAttendees.Add(CheckedAttendee);
            }

            return registrationAttendees;

        }
      
    }
}
