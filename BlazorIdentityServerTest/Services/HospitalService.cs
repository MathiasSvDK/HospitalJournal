using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorIdentityServerTest.Models;

namespace BlazorIdentityServerTest.Services
{
    public class HospitalService
    {

        public HospitalContext _hospitalContext { get; set; }
        public HospitalService(HospitalContext _context)
        {
            _hospitalContext = _context;
        }

        public Hospital GetHospital(int id)
        {
            return _hospitalContext.Hospitals.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(Hospital hospital)
        {
            _hospitalContext.Update(hospital);
        }

        public void Save() {
            _hospitalContext.SaveChanges();
        }
    }
}