using Microsoft.AspNetCore.Mvc;
using Trip.Path.Share.Common.Repository;
using Trip.Path.Share.Common.UnitOfWork;
using Trip.Path.Share.Data.Entity;
using Trip.Path.Share.Data.Persistance;

namespace Trip.Path.Share.Api.Controllers
{
    [Route("api/trip")]
    [ApiController]
    public class TripController : ControllerBase
    {
        readonly IAsyncContextRepository<TripShareDbContext, TripEntity, Guid> _tripRepo;
        readonly IUnitOfWork<TripShareDbContext> _unitOfWork;
        public TripController(IAsyncContextRepository<TripShareDbContext, TripEntity, Guid> tripRepo,
            IUnitOfWork<TripShareDbContext> unitOfWork)
        {
            _tripRepo = tripRepo;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var trips = _tripRepo.Queryable().ToList();
            return Ok(trips);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var trips = _tripRepo.GetByIdentity(id);
            return Ok(trips);
        }


        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Post(string name)
        {
            var newTrip = new TripEntity()
            {
                Name = name
            };

             _tripRepo.Add(newTrip);
            await _unitOfWork.Commit();
            return Created(name, newTrip.Id);
        }



        [HttpPut]
        [Route("{id}/modify")]
        public async Task<IActionResult> Post([FromBody] string name, Guid id)
        {
            var tripTobeModified =  _tripRepo.GetByIdentity(id);
            tripTobeModified.Name = name;
            _tripRepo.Update(tripTobeModified);
            await _unitOfWork.Commit();
            return Ok(name);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Post(Guid id)
        {
            var tripTobeModified =  _tripRepo.GetByIdentity(id);
            _tripRepo.Delete(tripTobeModified);
            await _unitOfWork.Commit();
            return Ok(id);
        }


    }
}
