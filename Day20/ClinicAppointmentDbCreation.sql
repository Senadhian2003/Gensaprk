create Database ClinicManagement;



use ClinicManagement

create table Doctors(
	Id  int identity(1,1) constraint pk_Doctors primary key,
	Name varchar(20),
	DateOfBirth DateTime,
	Age int,
	Qualification varchar(25),
	Specialization varchar(25)
)

create table Patients(
	Id  int identity(1,1) constraint pk_Patients primary key,
	Name varchar(20),
	DateOfBirth DateTime,
	Age int,
	Disease varchar(25),
	
)

create table Appointments(
	Id  int identity(1,1) constraint pk_Appointment primary key,
	DoctorId int not null constraint fk_Appointment_Doctor foreign key references Doctors(Id) ,
	PatientId int not null constraint fk_Appointment_Patient foreign key references Patients(Id) ,
	Title varchar(30),
	Description varchar(70),
	DateOfAppointment DateTime,
	Status varchar(20),
)







