using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Application.Patient
{
    public class PatientService
    {

        private readonly IApplicationDbContext _context;

        public PatientService(IApplicationDbContext context)
            => _context = context;


        public async Task<int> CreatePatient(PatientDTO patient)
        {
            await _context.Patients.AddAsync(Map(patient));
           return await _context.SaveChanges();

        }



        public async Task<Common.PaginatedList<PatientDTO, Domain.Entities.Patient>> GetPage(int page, int pageSize)
             => new Common.PaginatedList<PatientDTO, Domain.Entities.Patient>(page, pageSize, _context.Patients, Map, "Facility");
        

        public async Task<PatientDTO> GetPatient(int id)
              => (PatientDTO)_context.Patients.Where(p => p.Id == id).Include( p => p.Facility ).Select(p => Map(p));


        public async Task<int> DeletePatient(int id)
        {
            Domain.Entities.Patient patient =
               _context.Patients.FirstOrDefault(p => p.Id == id);

            if (patient != null)
            {
                _context.Patients.Remove(patient);
                return await _context.SaveChanges();
            }

            return -1;
        }


        public async Task<int> UpdatePatient(PatientDTO patient)
        {

            _context.Patients.Update(Map(patient));
            return await _context.SaveChanges();
        }



        private static Domain.Entities.Patient Map(PatientDTO patient) 
          =>  new()
            {
                DateOfBirth  = patient.DateOfBirth,
                FirstName    = patient.FirstName,
                LastName     = patient.LastName,
                Id           = patient.Id,
                FacilityId   = patient.FacilityId,
            };


        private static PatientDTO Map(Domain.Entities.Patient patient) 
            => new()
             {
                 Id          = patient.Id,
                 FirstName   = patient.FirstName,
                 LastName    = patient.LastName,
                 FacilityId  = patient.FacilityId,
                 DateOfBirth = patient.DateOfBirth,
                 Facility    = new Facility.FacilityDTO()
                 {
                     Id         = patient.Facility.Id,
                     Name       = patient.Facility.Name,
                     Email      = patient.Facility.Email,
                     PhoneNumber  = patient.Facility.PhoneNumber,
                     Address      = patient.Facility.Address,
                     FacilityStatus = new Facility.FacilityStatusDTO()
                 }
             };


    }
}
