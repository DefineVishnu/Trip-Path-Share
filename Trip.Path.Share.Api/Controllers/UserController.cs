using Microsoft.AspNetCore.Mvc;
using Trip.Path.Share.Common.Repository;
using Trip.Path.Share.Common.UnitOfWork;
using Trip.Path.Share.Data.Entity;
using Trip.Path.Share.Data.Persistance;
using Trip.Path.Share.User.Data.Entity;

namespace Trip.Path.Share.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IAsyncContextRepository<UserDbContext, UserEntity, int> _userRepo;
        readonly IUnitOfWork<UserDbContext> _unitOfWork;
        public UserController(IAsyncContextRepository<UserDbContext, UserEntity, int> userRepo,
            IUnitOfWork<UserDbContext> unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var trips = _userRepo.Queryable().ToList();
            return Ok(trips);
        }


        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Post(UserEntity newUser)
        {
             _userRepo.Add(newUser);
            await _unitOfWork.Commit();
            return Created(newUser.DisplayName, newUser.Id);
        }



        [HttpPut]
        [Route("{id}/modify")]
        public async Task<IActionResult> Post(UserEntity updateUser, int id)
        {
            var userTobeModified =  _userRepo.GetByIdentity(id);
            userTobeModified.DisplayName = updateUser.DisplayName;
            userTobeModified.Email = updateUser.Email;
            _userRepo.Update(userTobeModified);
            await _unitOfWork.Commit();
            return Ok(id);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Post(int id)
        {
            var tripTobeModified =  _userRepo.GetByIdentity(id);
            _userRepo.Delete(tripTobeModified);
            await _unitOfWork.Commit();
            return Ok(id);
        }


    }
}
