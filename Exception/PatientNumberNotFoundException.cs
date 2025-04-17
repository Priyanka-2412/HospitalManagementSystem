using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Exception
{
    class PatientNumberNotFoundException : ApplicationException
    {
        public PatientNumberNotFoundException()
            : base("Patient number not found in the database.") { }

        public PatientNumberNotFoundException(string message)
            : base(message) { }

        public PatientNumberNotFoundException(string message, ApplicationException innerException)
            : base(message, innerException) { }
    }
}

