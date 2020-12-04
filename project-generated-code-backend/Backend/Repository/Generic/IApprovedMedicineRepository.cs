// File:    ApprovedMedicineRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface ApprovedMedicineRepository

using Model.Hospital;

namespace Backend.Repository
{
    public interface IApprovedMedicineRepository : IGenericRepository<Medicine>
    {
    }
}