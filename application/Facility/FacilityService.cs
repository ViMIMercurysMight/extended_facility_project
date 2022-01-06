using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Application.Facility
{
    public class FacilityService
    {

        private readonly IApplicationDbContext _context;
        
        public FacilityService(IApplicationDbContext context)
                  =>   _context = context;
        



        public void CreateFacility( Domain.Entities.Facility facility )
        {

            _context.Facility.Add( facility );
            _context.SaveChanges();
        }


        public void UpdateFacility( Domain.Entities.Facility facility )
        {

            _context.Facility.Update(facility);
            _context.SaveChanges();
        }


        public void DeleteFacility( int id )
        {

            Domain.Entities.Facility facility =
                _context.Facility.FirstOrDefault( p => p.Id == id );

            if( facility != null )
            {
                _context.Facility.Remove(facility);
                _context.SaveChanges();
            }
        }

       

    }
}
