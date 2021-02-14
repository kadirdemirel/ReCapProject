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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            if(customer.CompanyName.Length>0)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
          
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<CustomerDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDal.GetCustomerDetails());
        }

        public IResult Update(Customer customer)
        {
            if (customer.CompanyName.Length > 0)
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.Updated);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }
    }
}
