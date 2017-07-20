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
        Registration ProcessRegistration(UserContext userContext, Attendee attendee);
    }
}
