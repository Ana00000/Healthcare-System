// File:    Appointment.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Appointment

using System;
using System.ComponentModel.DataAnnotations.Schema;
using MicroServiceAccount.Backend.Model;
using MicroServiceAccount.Backend.Model.Util;
using MicroServiceAppointment.Backend.Dto;
using MicroServiceAppointment.Backend.Model.Hospital;
using Newtonsoft.Json;

namespace MicroServiceAppointment.Backend.Model
{
    public class Appointment : Entity
    {
        [ForeignKey("Room")] public string RoomSerialNumber { get; set; }
        public Room Room { get; set; }
        [ForeignKey("Physician")] public string PhysicianSerialNumber { get; set; }
        public Physician Physician { get; set; }
        [ForeignKey("Patient")] public string PatientSerialNumber { get; set; }
        public Patient Patient { get; set; }
        public TimeInterval TimeInterval { get; set; }
        [ForeignKey("ProcedureType")] public string ProcedureTypeSerialnumber { get; set; }
        public ProcedureType ProcedureType { get; set; }
        public bool Urgency { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public string DateOfCanceling { get; set; }

        public bool IsSurveyDone { get; set; }
        
        public Appointment(Room room, Physician physician, Patient patient, TimeInterval timeInterval,
            ProcedureType procedureType, Boolean active, DateTime date) : base()
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
            Active = active;
            Date = date;
        }
        public Appointment(Room room, Physician physician, Patient patient, TimeInterval timeInterval,
            ProcedureType procedureType, Boolean active, DateTime date,Boolean isSurveyDone) : base()
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
            Active = active;
            Date = date;
            IsSurveyDone = isSurveyDone;
        }

        public Appointment(Room room, Physician physician, Patient patient, TimeInterval timeInterval,
            ProcedureType procedureType, DateTime date) : base()
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
            Date = date;
        }

        public Appointment() : base()
        {
        }

        [JsonConstructor]
        public Appointment(String serialNumber, Room room, Physician physician, Patient patient,
            TimeInterval timeInterval, ProcedureType procedureType) : base(serialNumber)
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
        }

        public Appointment(String serialNumber, Room room, Physician physician, Patient patient,
            TimeInterval timeInterval, bool active, ProcedureType procedureType) : base(serialNumber)
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
            Active = active;
        }

        public Appointment(Room room, Physician physician, Patient patient,
            TimeInterval timeInterval, bool active, ProcedureType procedureType) : base()
        {
            Room = room;
            Physician = physician;
            Patient = patient;
            TimeInterval = timeInterval;
            ProcedureType = procedureType;
            Active = active;
        }

        public Appointment(string physicianId, string date, DateTime timeIntervalStart, string patientId, DateTime timeIntervalEnd)
        {
            this.PhysicianSerialNumber = physicianId;
            string[] parts = date.Split("-");
            this.Date = new DateTime(Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]), 0, 0, 0);
            this.TimeInterval = new TimeInterval(timeIntervalStart, timeIntervalEnd);
            this.Active = true;
            this.PatientSerialNumber = patientId;
        }

        public override bool Equals(object obj)
        {
            return obj is Appointment other && SerialNumber.Equals(other.SerialNumber);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "patient: " + Patient.Name + " " + Patient.Surname + "\nphysitian: " + Physician.Name + " " + Physician.Surname + "\ntime interval: " +
                   TimeInterval + "\nroom: " + Room + "\nprocedure type: " + ProcedureType;
        }

        public int CompareTo(Appointment other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}