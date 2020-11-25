// File:    PhysitianScheduleController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianScheduleController

using Backend.Dto;
using Backend.Service.SchedulingService;
using Model.Accounts;
using Model.Schedule;
using System;
using System.Collections.Generic;

namespace Backend.Controller.PhysitianControllers
{
    public class PhysitianScheduleController
    {
        private Physitian loggedPhysitian;
        private PhysitianScheduleService physitianScheduleService;

        public PhysitianScheduleController(Physitian loggedPhysitian)
        {
            this.loggedPhysitian = loggedPhysitian;
            this.physitianScheduleService = new PhysitianScheduleService(loggedPhysitian);
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return physitianScheduleService.GetAppointmentsByDate(date);
        }

        public void NewAppointment(AppointmentDTO appointment)
        {
            physitianScheduleService.NewAppointment(appointment);
        }
    }
}