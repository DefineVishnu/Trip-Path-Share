using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Path.Share.Common.Base;

namespace Trip.Path.Share.User.Data.Entity
{
    public class UserEntity : BaseEntity<int>
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }

    }
}
