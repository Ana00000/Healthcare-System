﻿using Model.Hospital;
using Model.MedicalExam;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class PrescriptionRepository: IPrescriptionRepository
    {
        private MySqlConnection connection;
        public PrescriptionRepository()
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=Tanjaa;password=TanjaaD");
            }
            catch (Exception e)
            {
            }
        }
        ///Tanja Drcelic RA124/2017 and Marija Vucetic RA157/2017
        /// <summary>
        ///Get prescriptions from table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///list of prescriptions
        ///</returns>
        public List<Prescription> GetPrescriptions(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Prescription> prescriptions = new List<Prescription>();
            while (sqlReader.Read())
            {
                Prescription entity = new Prescription();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Date = (DateTime)sqlReader[1];
                entity.Notes = (string)sqlReader[2];
                prescriptions.Add(entity);
            }
            connection.Close();
            foreach (Prescription prescription in prescriptions)
            {
                prescription.MedicineDosage = GetMedicineDosage("Select medicinedosages.SerialNumber,medicinedosages.Note,medicinedosages.Amount,medicines.SerialNumber,medicines.GenericName,medicines.CopyrightName,medicinetypes.SerialNumber,medicinetypes.Type  from medicinedosages,medicines,medicinetypes where medicinedosages.PrescriptionSerialNumber like '" + prescription.SerialNumber + "' and medicinedosages.MedicineSerialNumber like medicines.SerialNumber and medicines.MedicineTypeSerialNumber like medicinetypes.SerialNumber");
            }
            return prescriptions;
        }
        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get medicine dosages from table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///list of medicine dosages
        ///</returns>
        public List<MedicineDosage> GetMedicineDosage(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<MedicineDosage> resultList = new List<MedicineDosage>();
            while (sqlReader.Read())
            {
                MedicineDosage entity = new MedicineDosage();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Amount = (double)sqlReader[2];
                entity.Note = (string)sqlReader[1];
                entity.Medicine = new Medicine {SerialNumber= (string)sqlReader[3],GenericName= (string)sqlReader[4],CopyrightName= (string)sqlReader[5],MedicineType=new MedicineType {SerialNumber= (string)sqlReader[6],Type= (string)sqlReader[7] } };
                entity.Medicine.SerialNumber = (string)sqlReader[1];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }
        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Create sqlDml for get prescriptions
        ///</summary>
        ///<param name="property"> search by property
        ///<param name="value"> search value
        ///<param name="dateTimes"> search by date times
        ///<param name="not"> search for negation
        ///</param>
        ///<returns>
        ///list of prescriptions
        ///</returns>
        public List<Prescription> GetPrescriptionsByProperty(string property, string value, string dateTimes,bool not)
        {
            List<Prescription> prescriptions = GetPrescriptions("Select * from prescriptions where Date between "+dateTimes);
            if(not)
                return Negation(property, value, prescriptions);
            return Regular(property, value, prescriptions);
        }
        private List<Prescription> Negation(string property, string value, List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
            {
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                {
                    if (property.Equals("All"))
                    {
                        if (!medicineDosage.Medicine.GenericName.Contains(value.ToUpper()) && !medicineDosage.Medicine.MedicineType.Type.Contains(value.ToUpper()))
                            resultList.Add(prescription);
                    }
                    else if (property.Equals("Medicine name"))
                    {
                        if (!medicineDosage.Medicine.GenericName.ToUpper().Contains(value.ToUpper()))
                            resultList.Add(prescription);
                    }
                    else
                    {
                        if (!medicineDosage.Medicine.MedicineType.Type.ToUpper().Contains(value.ToUpper()))
                            resultList.Add(prescription);
                    }
                }
            }
            return resultList;
        }
        private List<Prescription> Regular(string property, string value, List<Prescription> prescriptions)
        {
            List<Prescription> resultList = new List<Prescription>();
            foreach (Prescription prescription in prescriptions)
            {
                foreach (MedicineDosage medicineDosage in prescription.MedicineDosage)
                {
                    if (property.Equals("All"))
                    {
                        if (medicineDosage.Medicine.GenericName.ToUpper().Contains(value.ToUpper()) || medicineDosage.Medicine.MedicineType.Type.ToUpper().Contains(value.ToUpper()))
                            resultList.Add(prescription);
                    }
                    else if (property.Equals("Medicine name"))
                    {
                        if (medicineDosage.Medicine.GenericName.ToUpper().Contains(value.ToUpper()))
                            resultList.Add(prescription);
                    }
                    else
                    {
                        if (medicineDosage.Medicine.MedicineType.Type.ToUpper().Contains(value.ToUpper()))
                            resultList.Add(prescription);
                    }
                }
            }
            return resultList;
        }
    }
}