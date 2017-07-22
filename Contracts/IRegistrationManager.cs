using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace Contracts
{
    public interface IRegistrationManager
    {
        ICollection<Registration> ProcessRegistration(UserContext userContext, ICollection<Attendee> attendees);
    }
}
