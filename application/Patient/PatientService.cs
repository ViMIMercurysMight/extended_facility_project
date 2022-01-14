using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Application.Patient
{

    using Domain.Entities;
    public class PatientService
    {

        private readonly IApplicationDbContext _context;

        public PatientService(IApplicationDbContext context)
            => _context = context;


        public async Task<int> CreatePatient(PatientDTO patient)
        {
            try
            {

                await _context.Patients.AddAsync(Map(patient));
               return await _context.SaveChanges();
      
            } catch( ApplicationException ex)
            {
                throw ex;
            }

        }



        public async Task<Common.PaginatedList<PatientDTO, Patient, Facility>> GetPage(int page, int pageSize)
        {

            Common.PaginatedList<PatientDTO, Patient, Facility> pagenatedList = new(page, pageSize);

            pagenatedList = await Common.PaginatedList<PatientDTO, Patient, Facility>.SetCount(
                     _context.Patients,
                     pagenatedList);


            pagenatedList = await Common.PaginatedList<PatientDTO, Patient, Facility>.SetPageItems(
              _context.Patients
               , pagenatedList
               , Map
               , p => p.Facility);

            return pagenatedList;

        }




        public async Task<PatientDTO> GetPatient(int id)
              => await _context.Patients
                                .Where(p => p.Id == id)
                                .Include(p => p.Facility)
                                .Select(p => Map(p))
                                .FirstOrDefaultAsync();


        public async Task<int> DeletePatient(int id)
        {
            try
            {
                Domain.Entities.Patient patient =
                _context.Patients.FirstOrDefault(p => p.Id == id);

                if (patient == null)
                    throw new ApplicationException("Patient Not Found");

                _context.Patients.Remove(patient);
               return  await _context.SaveChanges();

            }
            catch ( ApplicationException ex)
            {
                throw ex;
            }
         
        }


        public async Task<int> UpdatePatient(PatientDTO patient)
        {
            try
            {
                _context.Patients.Update(Map(patient));
                return await _context.SaveChanges();

            } catch( ApplicationException ex)
            {
                throw ex;
            }
          
        }



        private static Patient Map(PatientDTO patient)
            => (new Mapper(new MapperConfiguration(
                cfg => cfg.CreateMap<PatientDTO, Patient>()))
            .Map<Patient>(patient));



        private static PatientDTO Map(Patient patient)
            => (new Mapper(new MapperConfiguration(
                cfg => cfg.CreateMap<Patient, PatientDTO>()
                .ForMember("Facility", opt => opt.MapFrom(
                    c => new Application.Facility.FacilityDTO()
                    {
                        Id = c.Facility.Id,
                        Name = c.Facility.Name,
                        Email = c.Facility.Email,
                        PhoneNumber = c.Facility.PhoneNumber,
                        Address = c.Facility.Address,
                        FacilityStatus = new Application.Facility.FacilityStatusDTO()
                    }))))).Map<PatientDTO>( patient );
         

    }
}
