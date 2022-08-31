using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorIdentityServerTest.Models;
using BlazorIdentityServerTest.Interfaces;

namespace BlazorIdentityServerTest.Services
{
    public class HospitalService : IHospitalService
    {

        public HospitalContext _hospitalContext { get; set; }
        public HospitalService(HospitalContext _context)
        {
            _hospitalContext = _context;
        }

        
        ///<summary>
        /// Get all of the hospitals
        /// <returns>All hospitals</returns>
        /// </summary>
        public List<Hospital> Get() {
            return _hospitalContext.Hospitals.ToList();
        }
        

        ///<summary>
        /// Get a hospital by a specific id
        ///<param name="id">ID of a hospital</param>
        /// <returns>A Hospital</returns>
        /// </summary>
        public Hospital Get(int id)
        {
            return _hospitalContext.Hospitals.Where(x => x.Id == id).FirstOrDefault();
        }


        ///<summary>
        /// Update a hospital with new values
        ///<param name="hospital">The hospital that has to be updated with updated values</param>
        /// </summary>
        public void Update(Hospital hospital)
        {
            _hospitalContext.Update(hospital);
        }

        ///<summary>
        /// Save the changes to the database
        /// </summary>
        public void Save() {
            _hospitalContext.SaveChanges();
        }
    }
}