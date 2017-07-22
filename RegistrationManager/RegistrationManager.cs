using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DataContracts;
using UnityResolver;

namespace RegistrationManager
{
    public class RegistrationManager : IRegistrationManager
    {


        ICollection<Registration> IRegistrationManager.ProcessRegistration(UserContext userContext, ICollection<Attendee> attendees)
        {

            ICollection<Attendee> CheckedAttendees = UnityCache.ResolveDefault<IRegistrationEngine>().ProcessAttendees(userContext, attendees);

            return UnityCache.ResolveDefault<IRegistrationAccessor>().AddRegistration(userContext, CheckedAttendees);


        }
    }
}
