using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {

            if (rental.RentDate != null && rental.ReturnDate != null)
            {

                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);


            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }



        }



        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int carId)
        {
            var result = _rentalDal.Get(p => p.CarId == carId);
            if(result!=null)
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.CarId == carId));
            }
            else
            {
                return new ErrorDataResult<Rental>(_rentalDal.Get(p => p.CarId == carId));
            }
            
        }

        public IDataResult<List<RentalDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            if (rental.RentDate >= DateTime.Now)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.Updated);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }
    }
}
