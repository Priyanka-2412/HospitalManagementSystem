create database HospitalManagementSystem;

--Patient table
create table Patient (
PatientId int primary key,
FirstName varchar(50),
LastName varchar(50),
DateOfBirth date,
Gender varchar(15),
ContactNumber varchar(15),
PatientAddress varchar(100)
)

--Doctors table
create table Doctor (
DoctorId int primary key,
FirstName varchar(50),
LastName varchar(50),
Specialization varchar(100),
ContactNumber varchar(15)
)

--Appointment table
create table Appointment(
AppointmentId int identity(1,1) primary key, 
PatientId int,
DoctorId int,
AppointmentDate date,
Descriptions varchar(250),
Foreign key(PatientId) References Patient(PatientId),
Foreign key(DoctorId) References Doctor(DoctorId)
)

--inserting values 

insert into Patient(PatientId, FirstName, LastName, DateOfBirth, Gender, ContactNumber, PatientAddress)
values (1, 'Karthik', 'Kumar', '1988-04-12', 'Male', '9001000001', 'Coimbatore, Tamilnadu'),
(2, 'Ananya', 'Singh', '1991-09-21', 'Female', '9001000002', 'Pune, Maharashtra'),
(3, 'Rohit', 'Sharma', '1985-01-03', 'Male', '9001000003', 'Nagpur, Maharashtra'),
(4, 'Divya', 'Shri', '1993-12-19', 'Female', '9001000004', 'Chennai, Tamilnadu'),
(5, 'Amit', 'Khan', '1999-06-07', 'Male', '9001000005', 'Delhi, NCR'),
(6, 'Sumi', 'Balan', '1987-11-15', 'Female', '9001000006', 'Kochin, Kerala'),
(7, 'Rohan', 'Krishna', '1990-02-26', 'Male', '9001000007', 'Hyderabad, Andhra'),
(8, 'Neha', 'James', '1984-07-29', 'Female', '9001000008', 'Trivandrum, Kerala'),
(9, 'Aditya', 'Kumar', '1994-03-10', 'Male', '9001000009', 'Srinagar, Kashmir'),
(10, 'Pooja', 'Singh', '1986-05-22', 'Female', '9001000010', 'Jaipur, Rajasthan')


insert into Doctor (DoctorId, FirstName, LastName, Specialization, ContactNumber)
values (101, 'Dr. Amir', 'Nagul', 'Gastroenterologist', '9022011201'),
(102, 'Dr. Meera', 'William', 'Pediatrician', '9022011202'),
(103, 'Dr. Raghav', 'Kumar', 'Physician', '9022011203'),
(104, 'Dr. Sneha', 'Sundaram', 'General', '9022011204'),
(105, 'Dr. Nikhil', 'Ravi', 'Otolaryngologist', '9022011205'),
(106, 'Dr. Anika', 'Sundar', 'Dental Surgeon', '9022011206'),
(107, 'Dr. Tarun', 'Reddy', 'Cardiologist', '9022011207'),
(108, 'Dr. Kavya', 'Shree', 'Nephrologist', '9022011208'),
(109, 'Dr. Deepak', 'Ragu', 'Gynecologist', '9022011209'),
(110, 'Dr. Isha', 'Mahesh', 'Dermatologist', '9022011210')


insert into Appointment (PatientId, DoctorId, AppointmentDate, Descriptions)
values (1, 101, '2025-05-01', 'Digestive health screening'),
(2, 102, '2025-05-02', 'Child regular checkup'),
(3, 103, '2025-05-03', 'Annual physical exam'),
(4, 104, '2025-05-04', 'General checkup'),
(5, 105, '2025-05-05', 'Sinus evaluation'),
(6, 106, '2025-05-06', 'Dental cavity check'),
(7, 107, '2025-05-07', 'Heart checkup'),
(8, 108, '2025-05-08', 'Kidney Diagnosis'),
(9, 109, '2025-05-09', 'Prenatal checkup'),
(10, 110, '2025-05-10', 'Skin rash analysis')


select * from Patient
select * from Doctor
select * from Appointment