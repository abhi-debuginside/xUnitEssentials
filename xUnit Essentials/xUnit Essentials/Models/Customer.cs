using System;
using System.Collections.Generic;
using System.Text;
using xUnit_Essentials.Models.Enums;

namespace xUnit_Essentials.Models
{
    public class Customer
    {
        public Customer(DateTime joinDate)
        {
            JoinedOn = joinDate.Date;
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinedOn { get; set; }
        public MembershipTypes MembershipType
        {
            get
            {
                var years = 0;
                var diff = DateTime.Now.Date.Subtract(JoinedOn.Date);
                years = (int)diff.TotalDays / 365;

                if (years <= 3)
                {
                    return MembershipTypes.Bronze;
                }
                else if (years > 3 && years < 5)
                {
                    return MembershipTypes.Silver;
                }
                else if (years > 5 && years < 10)
                {
                    return MembershipTypes.Gold;
                }
                else if (years > 10)
                {
                    return MembershipTypes.Platinum;
                }
                else
                {
                    return MembershipTypes.None;
                }
            }
        }
    }
}