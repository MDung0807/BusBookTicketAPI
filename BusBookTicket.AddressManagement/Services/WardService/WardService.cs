﻿using AutoMapper;
using BusBookTicket.AddressManagement.DTOs.Requests.Ward;
using BusBookTicket.AddressManagement.DTOs.Responses.Ward;
using BusBookTicket.AddressManagement.Specification;
using BusBookTicket.Core.Infrastructure.Interfaces;
using BusBookTicket.Core.Models.Entity;
using BusBookTicket.Core.Utils;

namespace BusBookTicket.AddressManagement.Services.WardService;

public class WardService : IWardService
{
    #region -- Properties --

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Ward> _repository;
    private readonly IMapper _mapper;
    #endregion -- Properties --

    #region -- Public method --

    public WardService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GenericRepository<Ward>();
        _mapper = mapper;
    }
    public async Task<WardResponse> GetById(int id)
    {
        Ward ward = await WardGet(id);
        return _mapper.Map<WardResponse>(ward);
    }

    public Task<List<WardResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(WardUpdate entity, int id, int userId)
    {
        Ward ward = _mapper.Map<Ward>(entity);
        await _repository.Update(ward, userId);
        return true;
    }

    public async Task<bool> Delete(int id, int userId)
    {
        WardSpecification wardSpecification = new WardSpecification(id);
        Ward ward = await _repository.Get(wardSpecification, checkStatus: false);
        ward = ChangeStatus(ward, (int)EnumsApp.Delete);
        await _repository.Update(ward, userId);
        return true;
    }

    public async Task<bool> Create(WardCreate entity, int userId)
    {
        Ward ward = _mapper.Map<Ward>(entity);
        await _repository.Create(ward, userId);
        return true;
    }

    public Task<bool> ChangeIsActive(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeIsLock(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToWaiting(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToWaiting(List<int> ids, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeStatus(List<int> ids, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToDisable(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckToExistById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckToExistByParam(string param)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetAllByAdmin(object pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetAll(object pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetAll(object pagingRequest, int idMaster, bool checkStatus = false)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<object> FindByParam(string param, object pagingRequest = default, bool checkStatus = true)
    {
        throw new NotImplementedException();
    }

    public Task<List<WardResponse>> GetAllByAdmin()
    {
        throw new NotImplementedException();
    }

    public async Task<Ward> WardGet(int id)
    {
        WardSpecification wardSpecification = new WardSpecification(id);
        Ward ward = await _repository.Get(wardSpecification);
        return ward;
    }

    #endregion -- Public method --

    #region -- Private Method --

    private Ward ChangeStatus(Ward entity, int status)
    {
        entity.Status = status;
        return entity;
    }
    #endregion -- Private Method --
}