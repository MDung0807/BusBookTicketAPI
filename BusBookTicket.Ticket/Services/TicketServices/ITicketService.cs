﻿using System.Runtime.InteropServices.JavaScript;
using BusBookTicket.Core.Infrastructure.Interfaces;
using BusBookTicket.Ticket.DTOs.Requests;
using BusBookTicket.Ticket.DTOs.Response;
using BusBookTicket.Ticket.Paging;

namespace BusBookTicket.Ticket.Services.TicketServices;

public interface ITicketService : IService<TicketFormCreate, TicketFormUpdate, int, TicketResponse, TicketPaging, TicketPagingResult>
{
    /// <summary>
    /// FindTicket
    /// </summary>
    /// <param name="searchForm"></param>
    /// <param name="paging"></param>
    /// <returns></returns>
    Task<TicketPagingResult> GetAllTicket(SearchForm searchForm, TicketPaging paging);

    /// <summary>
    /// Change status is complete
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<bool> ChangeCompleteStatus(int id, int userId);

    /// <summary>
    /// Get all ticket on date
    /// </summary>
    /// <param name="idMaster"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    Task<TicketPagingResult> GetAllTicketOnDate(int idMaster, DateOnly date, TicketPaging paging);

    /// <summary>
    /// Get all ticket in month
    /// </summary>
    /// <param name="month">month</param>
    /// <param name="companyId">id for company</param>
    /// <param name="paging">paging</param>
    /// <param name="checkStatus"></param>
    /// <returns></returns>
    Task<TicketPagingResult> GetAll(DateOnly month, int companyId, TicketPaging paging, bool checkStatus = true);

    /// <summary>
    /// Minutes Before Ticket Have Departure
    /// </summary>
    /// <param name="minute"></param>
    /// <param name="checkStatus"></param>
    /// <returns></returns>
    Task<List<Core.Models.Entity.Ticket>> DepartureBeforeMinute(int minute, bool checkStatus = false);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="checkStatus"></param>
    /// <returns></returns>
    Task<List<Core.Models.Entity.Ticket>> TicketComplete(bool checkStatus = false);

    /// <summary>
    /// Get total ticket in last month
    /// </summary>
    /// <param name="companyId"></param>
    /// <returns></returns>
    Task<object> GetTotalTicket(int companyId);

    Task<bool> CreateWithManyBuses(TicketFormCreateManyBus request, int userId);
}