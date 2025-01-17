﻿using AutoMapper;
using BusBookTicket.AddressManagement.DTOs.Requests.Unit;
using BusBookTicket.AddressManagement.DTOs.Responses.Unit;
using BusBookTicket.AddressManagement.Specification;
using BusBookTicket.Core.Infrastructure.Interfaces;
using BusBookTicket.Core.Models.Entity;
using BusBookTicket.Core.Utils;

namespace BusBookTicket.AddressManagement.Services.UnitService;

public class UnitService : IUnitService
{
    #region -- Properties --

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<AdministrativeUnit> _repository;
    private readonly IMapper _mapper;

    #endregion

    public UnitService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GenericRepository<AdministrativeUnit>();
        _mapper = mapper;
    }
    
    #region -- Public Method --

    public async Task<UnitResponse> GetById(int id)
    {
        UnitSpecification unitSpecification = new UnitSpecification(id);
        AdministrativeUnit unit = await _repository.Get(unitSpecification, checkStatus: false);
        UnitResponse response = new UnitResponse();
        response = _mapper.Map<UnitResponse>(unit);
        return response;
    }

    public async Task<List<UnitResponse>> GetAll()
    {
        UnitSpecification unitSpecification = new UnitSpecification();
        List<AdministrativeUnit> units = await _repository.ToList(unitSpecification);
        return await AppUtils.MapObject<AdministrativeUnit, UnitResponse>(units, _mapper);
    }

    public Task<bool> Update(UnitUpdate entity, int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(UnitCreate entity, int userId)
    {
        throw new NotImplementedException();
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

    public Task<List<UnitResponse>> GetAllByAdmin()
    {
        throw new NotImplementedException();
    }

    #endregion
}