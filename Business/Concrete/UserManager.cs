using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
            ValidationTool.Validate(new UserValidator(), user);

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<List<User>>(Messages.Invalid);
            }

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int Id)
        {
            var result = _userDal.GetAll(u => u.Id == Id);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<User>(Messages.Invalid);
            }

            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == Id));
        }

        public IResult Update(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);

            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
