using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Descriptions { get; set; }

        // Default constructor
        public Appointment() { }

        // Parameterized constructor
        public Appointment(int appointmentId, int patientId, int doctorId, DateTime appointmentDate, string descriptions)
        {
            AppointmentId = appointmentId;
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = appointmentDate;
            Descriptions = descriptions;
        }

        public override string ToString()
        {
            return $"AppointmentId: {AppointmentId}, PatientId: {PatientId}, DoctorId: {DoctorId}, Date: {AppointmentDate.ToShortDateString()}, Description: {Descriptions}";
        }
    }
}
