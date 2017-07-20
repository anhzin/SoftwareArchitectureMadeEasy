using System;
using System.Linq;
using Contracts;
using DataContracts;
using Common;

namespace DataAccessor
{
    public class RegistrationAccessor : IRegistrationAccessor
    {
        public Registration AddRegistration(UserContext userContext, Registration registration)
        {
            Registration newRegistration = new Registration();
            using (GPDb db = new GPDb(userContext))
            {
                Attendee newAttendee = new Attendee();
                newAttendee.CopyValuesFrom(registration.Attendee, false);

                newAttendee.UpdateAuditFieldValues(userContext, true);

                db.Attendees.Add(newAttendee);

               
                newRegistration.CopyValuesFrom(registration,false);
                newRegistration.UpdateAuditFieldValues(userContext, true);
                newRegistration.Attendee = newAttendee;

                db.Registrations.Add(newRegistration);

                db.SaveChanges();
            }

            return newRegistration;
        }
    }
}
