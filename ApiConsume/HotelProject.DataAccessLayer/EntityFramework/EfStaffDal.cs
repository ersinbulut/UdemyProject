﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {

        }

        public int GetStaffCount()
        {
            using var context = new Context();
            var value = context.Staff.Count();
            return value;
        }

        public List<Staff> last4Staff()
        {
            using var context = new Context();
            var values = context.Staff.OrderByDescending(x => x.StaffID).Take(4).ToList();
            return values;
        }
    }
}
