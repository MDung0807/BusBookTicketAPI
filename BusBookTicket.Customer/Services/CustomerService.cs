﻿using BusBookTicket.CustomerManage.DTOs.Requests;
using BusBookTicket.CustomerManage.DTOs.Responses;
using BusBookTicket.CustomerManage.Repositories;
using BusBookTicket.Common.Models.Entity;
using AutoMapper;
using BusBookTicket.Auth.Services.AuthService;
using BusBookTicket.Auth.DTOs.Requests;
using BusBookTicket.Common.Common;
using BusBookTicket.Common.Utils;

namespace BusBookTicket.CustomerManage.Services
{
    public class CustomerService : ICustomerService
    {
        #region -- Properties --
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        #endregion --  Properties --

        #region -- Constructor --
        public CustomerService(IMapper mapper,
            IAuthService authService,
            ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _authService = authService;
            _customerRepository = customerRepository;
        }
        #endregion -- Contructor --

        #region -- Public method --

        /// <summary>
        /// Get all customer by admin
        /// </summary>
        /// <returns></returns>
        public List<CustomerResponse> getAllCustomer()
        {
            List<Customer> customers = new List<Customer>();
            List<CustomerResponse> responses = new List<CustomerResponse>();
            customers = _customerRepository.getAll();
            foreach(Customer customer in customers)
            {
                responses.Add(_mapper.Map<CustomerResponse>(customer));
            }
            return responses;
        }

        /// <summary>
        /// Create Customer and account genera
        /// Call Auth Service to create account and get account.
        /// After create customer
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool create(FormRegister entity)
        {
            Customer customer = new Customer();

            customer = _mapper.Map<Customer>(entity);

            // Set Full data in form regisger
            customer.dateUpdate = DateTime.Now;
            customer.dateCreate = DateTime.Now;

            AuthRequest authRequest = _mapper.Map<AuthRequest>(entity);
            _authService.create(authRequest);
            customer.account = _authService.getAccountByUsername(entity.username, entity.roleName);
            _customerRepository.create(customer);

            return true;
        }

        public bool delete(int id)
        { 
            Customer customer = _customerRepository.getByID(id);
            customer = setStatus(customer, (int)EnumsApp.Delete);
            _customerRepository.delete(customer);
            return true;
        }

        public ProfileResponse getByID(int id)
        {
            Customer customer = new Customer();
            customer = _customerRepository.getByID(id);
            return _mapper.Map<ProfileResponse>(customer);
        }

        public List<ProfileResponse> getAll()
        {
            throw new NotImplementedException();
        }

        public bool update(FormUpdate entity, int id)
        {
            Customer customer = new Customer();
            
            customer = _mapper.Map<Customer>(entity);
            customer.customerID = id;
            _customerRepository.update(customer);
            return true;
        }
        #endregion -- Public method --

        #region -- Private Method --

        private Customer setStatus(Customer customer, int status)
        {
            customer.status = customer.status != null ? status : customer.status;
            customer.account.status = customer.account.status != null ? status: customer.account.status;
            return customer;
        }
        #endregion
    }
}
