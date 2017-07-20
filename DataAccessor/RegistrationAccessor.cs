using System;
using Contracts;
using DataContracts;

namespace DataAccessor
{
    public class RegistrationAccessor : IRegistrationAccessor
    {
        public Registration AddRegistration(UserContext userContext, Registration registration)
        {
            Registration newRegistration = new Registration();
            using (GPDb db = new GPDb(userContext))
            {
                newRegistration = db.Registrations.Add(registration);
                db.SaveChanges();
            }

            return newRegistration;
        }
    }
}
