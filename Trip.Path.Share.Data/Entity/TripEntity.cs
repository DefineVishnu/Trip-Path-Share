using Trip.Path.Share.Common.Base;

namespace Trip.Path.Share.Data.Entity
{
    public class TripEntity : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}
