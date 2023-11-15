﻿using BusBookTicket.Auth.Security;
using BusBookTicket.BillManage.DTOs.Requests;
using BusBookTicket.BillManage.DTOs.Responses;
using BusBookTicket.BillManage.Services.BillItems;
using BusBookTicket.BillManage.Services.Bills;
using BusBookTicket.Core.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusBookTicket.BillManage.Controllers;

public class BillController : ControllerBase
{
    private readonly IBillService _billService;
    private readonly IBillItemService _billItemService;

    public BillController(IBillService billService, IBillItemService billItemService)
    {
        this._billService = billService;
        this._billItemService = billItemService;
    }

    #region -- Controller --
    [Authorize(Roles = "CUSTOMER")]
    [HttpPost("create")]
    public async Task<IActionResult> CreateBill([FromBody] BillRequest billRequest)
    {
        int userId = JwtUtils.GetUserID(HttpContext);
        await _billService.Create(billRequest, userId);
        return Ok(new Response<string>(false, "Response"));
    }

    [Authorize(Roles = "CUSTOMER")]
    [HttpGet("getBill")]
    public async Task<IActionResult> GetBill(int id)
    {
        BillResponse billResponse = await _billService.GetById(id);
        return Ok(new Response<BillResponse>(false, billResponse));
    }
    
    [Authorize(Roles = "CUSTOMER")]
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllBill()
    {
        List<BillResponse> billResponse = await _billService.GetAll();
        return Ok(new Response<List<BillResponse>>(false, billResponse));
    }
    #endregion -- Controller --

}