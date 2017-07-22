using System;
using System.Linq;
using Contracts;
using DataContracts;
using Common;
using System.Collections.Generic;

namespace DataAccessor
{

    public class RegistrationAccessor : IRegistrationAccessor
    {


        public Attendee FindAttendee(UserContext userContext, Attendee attendee)
        {
            Attendee returnAttendee = new Attendee();
            Registration newRegistration = new Registration();
            using (GPDb db = new GPDb(userContext))
            {
                returnAttendee = db.Attendees.Where(x => x.Email == attendee.Email).FirstOrDefault();

            }
            if(returnAttendee==null)
            {
                returnAttendee = attendee;
            }
            return returnAttendee;
        }

        ICollection<Registration> IRegistrationAccessor.AddRegistration(UserContext userContext, ICollection<Attendee> attendees)
        {
            List<Registration> returnRegistrations = new List<Registration>();
            using (GPDb db = new GPDb(userContext))
            {
                
                foreach (Attendee attendee in attendees)
                {
                    Registration newRegistration = new Registration { Attendee = new Attendee() };
                    newRegistration.Attendee.CopyValuesFrom(attendee, false);                
                    newRegistration.Attendee.UpdateAuditFieldValues(userContext, true);
                    newRegistration.UpdateAuditFieldValues(userContext, true);
                    db.Registrations.Add(newRegistration);
                    db.SaveChanges();
                    returnRegistrations.Add(newRegistration);

                }

            }

            return returnRegistrations;
        }
    }
}
