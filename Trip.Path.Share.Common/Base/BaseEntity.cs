using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Path.Share.Common.Base
{
    public abstract class BaseEntity<TIdentity>
    {
        [Key]
        public virtual TIdentity Id { get; set; }
    }
}
