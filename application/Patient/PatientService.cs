using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Application.Patient
{

    using Domain.Entities;
    public class PatientService
    {

        private readonly IApplicationDbContext _context;

        public PatientService(IApplicationDbContext context)
            => _context = context;


        public async Task<Common.QueryResult<PatientDTO>> CreatePatient(PatientDTO patient)
         => await Common.ExeptionFilter<PatientDTO>.TryExecute(async () =>
         {

                 await _context.Patients.AddAsync(PatientDTO.Map(patient));
                 await _context.SaveChanges();

                 return new() { Data = patient, IsSucced = true };

         });



        public async Task<Common.QueryResult<Common.PaginatedList<PatientDTO, Patient, Facility>>> GetPage(int page, int pageSize)
         => await Common.ExeptionFilter< Common.PaginatedList<PatientDTO, Patient, Facility>>.TryExecute(async () =>
         {

             Common.PaginatedList<PatientDTO, Patient, Facility> pagenatedList = new(page, pageSize);

             pagenatedList = await Common.PaginatedList<PatientDTO, Patient, Facility>.SetCount(
                      _context.Patients,
                      pagenatedList);


             pagenatedList = await Common.PaginatedList<PatientDTO, Patient, Facility>.SetPageItems(
               _context.Patients
                , pagenatedList
                , PatientDTO.Map
                , p => p.Facility);

             return new()
             {
                 Data = pagenatedList,
                 IsSucced = true,

             };
         });




        public async Task<Common.QueryResult<PatientDTO>> GetPatient(int id)
         => await Common.ExeptionFilter<PatientDTO>.TryExecute(async () =>
         {

             PatientDTO patient = await _context.Patients
                                  .Where(p => p.Id == id)
                                  .Include(p => p.Facility)
                                  .Select(p => PatientDTO.Map(p))
                                  .FirstOrDefaultAsync();

             if (patient != null)
                 return new()
                 {
                     Data = patient,
                     IsSucced = true
                 };

             else
                 return new()
                 {
                     IsSucced = false,
                     ErrorMessage = "Patient with ID doesn`t exist"
                 };

         });



        public async Task<Common.QueryResult<int>> DeletePatient(int id)
         => await Common.ExeptionFilter<int>.TryExecute(async () =>
         {

             Patient patient =
                 _context.Patients.FirstOrDefault(p => p.Id == id);

             if (patient == null)
                 return new()
                 {
                     Data = id,
                     IsSucced = false,
                     ErrorMessage = "Patient with ID doesn`t exist"
                 };

             _context.Patients.Remove(patient);
             await _context.SaveChanges();


             return new()
             {
                 Data = id,
                 IsSucced = true
             };


         });


        public async Task<Common.QueryResult<PatientDTO>> UpdatePatient(PatientDTO patient)
               => await Common.ExeptionFilter<PatientDTO>.TryExecute( async () => { 
                _context.Patients.Update(PatientDTO.Map(patient));
                await _context.SaveChanges();

                return new()
                {
                    Data = patient,
                    IsSucced = true
                };

        });


    }
}
