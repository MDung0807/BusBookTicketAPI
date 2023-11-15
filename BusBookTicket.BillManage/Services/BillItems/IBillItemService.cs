﻿using BusBookTicket.BillManage.DTOs.Requests;
using BusBookTicket.BillManage.DTOs.Responses;
using BusBookTicket.Core.Infrastructure.Interfaces;

namespace BusBookTicket.BillManage.Services.BillItems;

public interface IBillItemService : IService<BillItemRequest, BillItemRequest, int, BillItemResponse>
{
    /// <summary>
    /// Get all item in ticket
    /// </summary>
    /// <param name="billID">ID bill</param>
    /// <returns>List all item in ticket</returns>
    Task<List<BillItemResponse>> GetItemInBill(int billID);
}