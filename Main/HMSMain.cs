using System;
using System.Collections.Generic;
using HospitalManagementSystem.Dao;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Exception;
using HospitalManagementSystem.Util;

namespace HospitalManagementSystem.Main
{
    public class HMSMain
    {
        static void Main(string[] args)
        {
            // Creating service layer object
            IHospitalService service = new HospitalServiceImpl();
            bool exit = false;

            while (!exit)
            {
                // Displaying menu options
                Console.WriteLine("\n==== Hospital Management System ====");
                Console.WriteLine("1. View Appointment by ID");
                Console.WriteLine("2. View Appointments for Patient");
                Console.WriteLine("3. View Appointments for Doctor");
                Console.WriteLine("4. Schedule Appointment");
                Console.WriteLine("5. Update Appointment");
                Console.WriteLine("6. Cancel Appointment");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                // Validating user input
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                try
                {
                    // Handling each menu option
                    switch (choice)
                    {
                        case 1:
                            // View appointment by appointment ID
                            Console.Write("Enter Appointment ID: ");
                            int id = int.Parse(Console.ReadLine());
                            var appointment = service.GetAppointmentById(id);
                            Console.WriteLine(appointment != null ? appointment.ToString() : "Appointment not found.");
                            break;

                        case 2:
                            // View all appointments for a patient by patient ID
                            Console.Write("Enter Patient ID: ");
                            int patientId = int.Parse(Console.ReadLine());
                            var patientAppointments = service.GetAppointmentsForPatient(patientId);
                            patientAppointments.ForEach(a => Console.WriteLine(a));
                            break;

                        case 3:
                            // View all appointments for a doctor by doctor ID
                            Console.Write("Enter Doctor ID: ");
                            int doctorId = int.Parse(Console.ReadLine());
                            var doctorAppointments = service.GetAppointmentsForDoctor(doctorId);
                            doctorAppointments.ForEach(a => Console.WriteLine(a));
                            break;

                        case 4:
                            // Schedule a new appointment
                            Console.Write("Enter Patient ID: ");
                            int pId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Doctor ID: ");
                            int dId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Appointment Date (yyyy-mm-dd): ");
                            DateTime date = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter Description: ");
                            string desc = Console.ReadLine();

                            var newApp = new Appointment(0, pId, dId, date, desc);
                            Console.WriteLine(service.ScheduleAppointment(newApp)
                                ? "Appointment scheduled."
                                : "Failed to schedule.");
                            break;

                        case 5:
                            // Update an existing appointment
                            Console.Write("Enter Appointment ID: ");
                            int appId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Patient ID: ");
                            int updatePId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Doctor ID: ");
                            int updateDId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Appointment Date (yyyy-mm-dd): ");
                            DateTime updateDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter Description: ");
                            string updateDesc = Console.ReadLine();

                            var updatedApp = new Appointment(appId, updatePId, updateDId, updateDate, updateDesc);
                            Console.WriteLine(service.UpdateAppointment(updatedApp)
                                ? "Appointment updated."
                                : "Update failed.");
                            break;

                        case 6:
                            // Cancel an appointment by ID
                            Console.Write("Enter Appointment ID: ");
                            int cancelId = int.Parse(Console.ReadLine());
                            Console.WriteLine(service.CancelAppointment(cancelId)
                                ? "Appointment cancelled."
                                : "Cancellation failed.");
                            break;

                        case 7:
                            // Exit the program
                            exit = true;
                            break;

                        default:
                            // Invalid option
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                // Catching custom exception for invalid patient ID
                catch (PatientNumberNotFoundException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                // Catching all other exceptions
                catch (ApplicationException ex)
                {
                    Console.WriteLine("Unexpected Error: " + ex.Message);
                }
            }

            Console.WriteLine("Exiting Hospital Management System...");
        }
    }
}