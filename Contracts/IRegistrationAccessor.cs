using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace Contracts
{
    public interface IRegistrationAccessor
    {
        ICollection<Registration> AddRegistration(UserContext userContext, ICollection<Attendee> attendees);
        Attendee FindAttendee(UserContext userContext, Attendee attendee);
    }
}
