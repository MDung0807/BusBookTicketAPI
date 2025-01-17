﻿using AutoMapper;
using BusBookTicket.Core.Common.Exceptions;
using BusBookTicket.Core.Infrastructure.Interfaces;
using BusBookTicket.Core.Models.Entity;
using BusBookTicket.Core.Utils;
using BusBookTicket.RoutesManage.DTOs.Requests;
using BusBookTicket.RoutesManage.DTOs.Responses;
using BusBookTicket.RoutesManage.Paging;
using BusBookTicket.RoutesManage.Specifications;

namespace BusBookTicket.RoutesManage.Service;

public class RoutesService : IRoutesService
{
    #region -- Properties --

    private IMapper _mapper;
    private readonly IGenericRepository<Routes> _repository;
    private readonly IRouteDetailService _detailService;
    private readonly IUnitOfWork _unitOfWork;
    #endregion -- Properties --

    public RoutesService(IMapper mapper, IUnitOfWork unitOfWork, IRouteDetailService detailService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = _unitOfWork.GenericRepository<Routes>();
        _detailService = detailService;
    }
    public async Task<RoutesResponse> GetById(int id)
    {
        RouteSpecifications routeSpecifications = new RouteSpecifications(id: id, checkStatus: true);
        Routes routes = await _repository.Get(routeSpecifications);
        return _mapper.Map<RoutesResponse>(routes);
    }

    public async Task<List<RoutesResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(RoutesCreate entity, int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Create(RoutesCreate entity, int userId)
    {
        Routes routes = _mapper.Map<Routes>(entity);
        try
        {
            routes.Status = (int)EnumsApp.Active;
            await _repository.Create(routes, userId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ExceptionDetail(AppConstants.ERROR);
        }
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

    public async Task<bool> ChangeToWaiting(List<int> ids, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ChangeStatus(List<int> ids, int userId)
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

    public Task<RoutesPagingResult> GetAllByAdmin(RoutesPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<RoutesPagingResult> GetAll(RoutesPaging pagingRequest)
    {
        RouteSpecifications specifications = new RouteSpecifications(paging: pagingRequest, checkStatus:false);
        List<Routes> routes = await _repository.ToList(specifications);
        int count = await _repository.Count(new RouteSpecifications());
        List<RoutesResponse> responses = await AppUtils.MapObject<Routes, RoutesResponse>(routes, _mapper);
        RoutesPagingResult result = AppUtils.ResultPaging<RoutesPagingResult, RoutesResponse>(
            pagingRequest.PageIndex,
            pagingRequest.PageSize,
            count,
            responses
        );
        return result;
    }

    public async Task<RoutesPagingResult> GetAll(RoutesPaging pagingRequest, int idMaster, bool checkStatus = false)
    {
        RouteSpecifications specifications = new RouteSpecifications(companyId:idMaster, paging: pagingRequest);
        int count = await _repository.Count(new RouteSpecifications(companyId: idMaster));
        List<Routes> routes = await _repository.ToList(specifications);
        RoutesPagingResult result = AppUtils.ResultPaging<RoutesPagingResult, RoutesResponse>(
            pagingRequest.PageIndex,
            pagingRequest.PageSize,
            count: count,
            items: await AppUtils.MapObject<Routes, RoutesResponse>(routes, _mapper));
        return result;
    }

    public Task<bool> DeleteHard(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RoutesPagingResult> FindByParam(string param, RoutesPaging pagingRequest = default, bool checkStatus = true)
    {
        RouteSpecifications specifications = new RouteSpecifications(),
            specificationsNotPaging = new RouteSpecifications();
        specifications.FindByParam(param, paging:pagingRequest, checkStatus);
        specificationsNotPaging.FindByParam(param, checkStation: checkStatus);

        var result = await _repository.ToList(specifications);
        int count = await _repository.Count(specificationsNotPaging);
        
        return AppUtils.ResultPaging<RoutesPagingResult, RoutesResponse>(
            pagingRequest.PageIndex,
            pagingRequest.PageSize,
            count: count,
            items: await AppUtils.MapObject<Routes, RoutesResponse>(result, _mapper));
    }

    public async Task<RoutesResponse> GetById(int id, int companyId)
    {
        RouteSpecifications routeSpecifications = new RouteSpecifications(id: id, checkStatus: true, companyId: companyId);
        Routes routes = await _repository.Get(routeSpecifications);
        return _mapper.Map<RoutesResponse>(routes);
    }
}