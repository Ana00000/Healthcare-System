﻿using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.MedicineService;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers

{
    public class SuperintendentMedicineController
    {
        private readonly SuperintendentMedicineService _superintendentMedicineService;

        public SuperintendentMedicineController()
        {
            _superintendentMedicineService = new SuperintendentMedicineService();
        }

        public SuperintendentMedicineController(SuperintendentMedicineService superintendentMedicineService)
        {
            _superintendentMedicineService = superintendentMedicineService;
        }

        public List<Medicine> GetAll()
        {
            return _superintendentMedicineService.GetAll();
        }

        public List<Medicine> GetByName(string name)
        {
            return _superintendentMedicineService.GetByName(name);
        }

        public List<Medicine> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return _superintendentMedicineService.GetByRoomSerialNumber(roomSerialNumber);
        }

        public List<Medicine> GetAllApproved()
        {
            return _superintendentMedicineService.GetAllApproved();
        }

        public List<Rejection> GetAllRejected()
        {
            return _superintendentMedicineService.GetAllRejected();
        }

        public List<Medicine> GetAllWaiting()
        {
            return _superintendentMedicineService.GetAllWaiting();
        }

        public void DeleteWaitingMedicine(Medicine medicine)
        {
            _superintendentMedicineService.DeleteWaitingMedicine(medicine);
        }

        public void NewWaitingMedicine(Medicine medicine)
        {
            _superintendentMedicineService.NewWaitingMedicine(medicine);
        }

        public void EditWaitingMedicine(Medicine medicineDto)
        {
            _superintendentMedicineService.EditWaitingMedicine(medicineDto);
        }

        public void DeleteRejection(Rejection rejection)
        {
            _superintendentMedicineService.DeleteRejection(rejection);
        }

        public void NewRejection(Rejection rejection)
        {
            _superintendentMedicineService.NewRejection(rejection);
        }

        public void EditRejection(Rejection rejection)
        {
            _superintendentMedicineService.EditRejection(rejection);
        }

        public void DeleteApprovedMedicine(Medicine medicine)
        {
            _superintendentMedicineService.DeleteApprovedMedicine(medicine);
        }

        public void NewApprovedMedicine(Medicine medicine)
        {
            _superintendentMedicineService.NewApprovedMedicine(medicine);
        }
    }
}