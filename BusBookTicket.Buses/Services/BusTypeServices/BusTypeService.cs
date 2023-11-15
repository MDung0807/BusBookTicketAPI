﻿using AutoMapper;
using BusBookTicket.Buses.DTOs.Requests;
using BusBookTicket.Buses.DTOs.Responses;
using BusBookTicket.Buses.Specification;
using BusBookTicket.Core.Infrastructure.Interfaces;
using BusBookTicket.Core.Models.Entity;
using BusBookTicket.Core.Utils;

namespace BusBookTicket.Buses.Services.BusTypeServices;

public class BusTypeService : IBusTypeService
{
    #region -- Properties --

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<BusType> _repository;
    #endregion -- Properties --

    public BusTypeService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this._mapper = mapper;
        this._unitOfWork = unitOfWork;
        this._repository = unitOfWork.GenericRepository<BusType>();
    }
    public async Task<BusTypeResponse> GetById(int id)
    {
        BusTypeSpecification busTypeSpecification = new BusTypeSpecification(id);
        BusType busType = await _repository.Get(busTypeSpecification);
        return _mapper.Map<BusTypeResponse>(busType);
    }

    public async Task<List<BusTypeResponse>> GetAll()
    {
        BusTypeSpecification busTypeSpecification = new BusTypeSpecification();
        List<BusType> busTypes = await _repository.ToList(busTypeSpecification);
        List<BusTypeResponse> responses = await AppUtils.MappObject<BusType, BusTypeResponse>(busTypes, _mapper);
        return responses;
    }

    public async Task<bool> Update(BusTypeFormUpdate entity, int id, int userId)
    {
        BusType busType = _mapper.Map<BusType>(entity);
        busType.Id = id;
        await _repository.Update(busType, userId);
        return true;
    }

    public async Task<bool> Delete(int id, int userId)
    {
        BusTypeSpecification busTypeSpecification = new BusTypeSpecification(id);
        BusType busType = await _repository.Get(busTypeSpecification);
        busType.Status = (int)EnumsApp.Delete;
        await _repository.Delete(busType, userId);
        return true;
    }

    public async Task<bool> Create(BusTypeForm entity, int userId)
    {
        BusType busType = _mapper.Map<BusType>(entity);
        await _repository.Create(busType, userId);
        return true;
    }
}