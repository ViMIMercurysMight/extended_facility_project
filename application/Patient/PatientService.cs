using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Patient
{
    public class PatientService
    {

        private IApplicationDbContext _context;
        
        public PatientService(IApplicationDbContext context)
            => _context = context;


        public void CreatePatient( Domain.Entities.Patient patient )
        {
            _context.Patient.Add(patient);
            _context.SaveChanges();

        }


        public void DeletePatient( int id )
        {
            Domain.Entities.Patient patient =
                _context.Patient.FirstOrDefault( p => p.Id == id );

            if( patient != null)
            {
                _context.Patient.Remove(patient);
                _context.SaveChanges();
            }

        }


        public void UpdatePatient( Domain.Entities.Patient patient )
        {

            _context.Patient.Update(patient);
            _context.SaveChanges();
        }

    }
}
