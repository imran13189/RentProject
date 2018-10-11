using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Entities.Model
{
    public class LoggedInUserDetails
    {
        public long UserID { get; set; }
      public string Name { get; set; }
        public string Email { get; set; }
       public string Mobile { get; set; }
        public int RoleId { get; set; }
    }

    public class LoggedInPhysicianStaffDetails
    {
        public Guid PhysicianId { get; set; }
        public Guid? PhysicianAdminId { get; set; }
        public int? UserType { get; set; }
        public int UserId { get; set; }
        public int PhysicianAdminUserID { get; set; }
    }

    public class LoggedInPharmacyStaffDetails
    {
        public Guid PharmacyStaffId { get; set; }
        public Guid? PharmacyAdminId { get; set; }
        public int? UserType { get; set; }
        public int UserId { get; set; }
        public int PhysicianAdminUserID { get; set; }
    }

    public class PlanDetails
    {
        public bool IsPlanExpired { get; set; }
        public bool IsPlanSelected { get; set; }
        public int PlanId { get; set; }
    }
}
