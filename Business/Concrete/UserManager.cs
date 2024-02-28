using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length > 4 && user.LastName.Length > 4)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }

            return new ErrorResult(Messages.UserNameInvalid);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.Get();

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<List<User>>(Messages.Invalid);
            }

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<List<User>> GetById(int Id)
        {
            var result = _userDal.Get(u => u.Id == Id);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<List<User>>(Messages.Invalid);
            }

            return new SuccessDataResult<List<User>>(_userDal.Get(u => u.Id == Id));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
