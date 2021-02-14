using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            if (user.FirstName.Length > 3 && user.LastName.Length > 2 && user.Email != null && user.Password.Length >= 4)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new ErrorResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User user)
        {
            if (user.FirstName.Length > 3 && user.LastName.Length > 2 && user.Email != null && user.Password.Length >= 4)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.Updated);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }
    }
}
