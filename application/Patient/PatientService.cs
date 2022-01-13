using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Application.Patient
{
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



        public async Task<Common.PaginatedList<PatientDTO, Domain.Entities.Patient, Domain.Entities.Facility>> GetPage(int page, int pageSize)
             => new Common.PaginatedList<PatientDTO, Domain.Entities.Patient, Domain.Entities.Facility>(
                 page,
                 pageSize, 
                 _context.Patients,
                 Map,
                 p => p.Facility );
        

        public async Task<PatientDTO> GetPatient(int id)
              => (PatientDTO)_context.Patients.Where(p => p.Id == id).Include( p => p.Facility ).Select(p => Map(p));


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



        private static Domain.Entities.Patient Map(PatientDTO patient)
            => (new Mapper(new MapperConfiguration(
                cfg => cfg.CreateMap<PatientDTO, Domain.Entities.Patient>()))
            .Map<Domain.Entities.Patient>(patient));



        private static PatientDTO Map(Domain.Entities.Patient patient)
            => (new Mapper(new MapperConfiguration(
                cfg => cfg.CreateMap<Domain.Entities.Patient, PatientDTO>()
                .ForMember("Facility", opt => opt.MapFrom<Facility.FacilityDTO>(
                    c => new Facility.FacilityDTO()
                    {
                        Id = c.Facility.Id,
                        Name = c.Facility.Name,
                        Email = c.Facility.Email,
                        PhoneNumber = c.Facility.PhoneNumber,
                        Address = c.Facility.Address,
                        FacilityStatus = new Facility.FacilityStatusDTO()
                    }))))).Map<PatientDTO>( patient );
         

    }
}
