using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Exception;
using HospitalManagementSystem.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Dao
{
    public class HospitalServiceImpl : IHospitalService
    {
        private readonly string _connectionString = DBConnectionUtil.GetConnectionString();

        public Appointment GetAppointmentById(int appointmentId)
        {
            Appointment appointment = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Appointment WHERE AppointmentId = @AppointmentId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    appointment = new Appointment(
                        (int)reader["AppointmentId"],
                        (int)reader["PatientId"],
                        (int)reader["DoctorId"],
                        (DateTime)reader["AppointmentDate"],
                        reader["Descriptions"].ToString()
                    );
                }
            }

            return appointment;
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Appointment WHERE PatientId = @PatientId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientId", patientId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    appointments.Add(new Appointment(
                        (int)reader["AppointmentId"],
                        (int)reader["PatientId"],
                        (int)reader["DoctorId"],
                        (DateTime)reader["AppointmentDate"],
                        reader["Descriptions"].ToString()
                    ));
                }

                if (appointments.Count == 0)
                    throw new PatientNumberNotFoundException($"No appointments found for Patient ID: {patientId}");
            }

            return appointments;
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Appointment WHERE DoctorId = @DoctorId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    appointments.Add(new Appointment(
                        (int)reader["AppointmentId"],
                        (int)reader["PatientId"],
                        (int)reader["DoctorId"],
                        (DateTime)reader["AppointmentDate"],
                        reader["Descriptions"].ToString()
                    ));
                }
            }

            return appointments;
        }

        public bool ScheduleAppointment(Appointment appointment)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Appointment (PatientId, DoctorId, AppointmentDate, Descriptions) VALUES (@PatientId, @DoctorId, @Date, @Desc)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@Date", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@Desc", appointment.Descriptions);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Appointment SET PatientId = @PatientId, DoctorId = @DoctorId, AppointmentDate = @Date, Descriptions = @Desc WHERE AppointmentId = @AppointmentId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@Date", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@Desc", appointment.Descriptions);
                cmd.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CancelAppointment(int appointmentId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Appointment WHERE AppointmentId = @AppointmentId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}