﻿using AutoMapper;
using BusBookTicket.Core.Infrastructure.Interfaces;
using BusBookTicket.Core.Models.Entity;
using BusBookTicket.Core.Utils;
using BusBookTicket.RoutesManage.DTOs.Requests;
using BusBookTicket.RoutesManage.DTOs.Responses;
using BusBookTicket.RoutesManage.Paging;
using BusBookTicket.RoutesManage.Specifications;

namespace BusBookTicket.RoutesManage.Service;

public class RouteDetailService : IRouteDetailService
{

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<RouteDetail> _repository;

    public RouteDetailService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GenericRepository<RouteDetail>();
    }
    public Task<RouteDetailResponse> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<RouteDetailResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(RouteDetailCreate entity, int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Create(RouteDetailCreate entity, int userId)
    {
        foreach (var item in entity.Items)
        {
            RouteDetail detail = _mapper.Map<RouteDetail>(item);
            await _repository.Create(detail, userId);
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

    public Task<RouteDetailPagingResult> GetAllByAdmin(RouteDetailPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<RouteDetailPagingResult> GetAll(RouteDetailPaging pagingRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<RouteDetailPagingResult> GetAll(RouteDetailPaging pagingRequest, int idMaster)
    {
        RouteDetailSpecification specification = new RouteDetailSpecification(companyId: idMaster,paging:pagingRequest);
        int count = await _repository.Count(new RouteDetailSpecification(companyId: idMaster));
        List<RouteDetail> routeDetails = await _repository.ToList(specification);

        List<RouteDetailResponse> responses =
            await AppUtils.MapObject<RouteDetail, RouteDetailResponse>(routeDetails, _mapper);
        RouteDetailPagingResult result = AppUtils.ResultPaging<RouteDetailPagingResult, RouteDetailResponse>(
            pagingRequest.PageIndex,
            pagingRequest.PageSize,
            count, responses
            );
        return result;
    }

    public Task<bool> DeleteHard(int id)
    {
        throw new NotImplementedException();
    }
}