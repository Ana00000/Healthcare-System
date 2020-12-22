﻿using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Service.HospitalAccountsService;

namespace HealthClinicBackend.Backend.Controller
{
    public class HospitalLogInController
    {
        private readonly HospitalLogInService _hospitalLogInService;

        public HospitalLogInController()
        {
            _hospitalLogInService = new HospitalLogInService(new PatientDatabaseSql(), new PhysicianDatabaseSql(),
                new SecretaryDatabaseSql());
        }

        public HospitalLogInController(HospitalLogInService hospitalLogInService)
        {
            _hospitalLogInService = hospitalLogInService;
        }

        public TypeOfUser GetUserType(string jmbg, string password)
        {
            return _hospitalLogInService.GetUserType(jmbg, password);
        }
    }
}