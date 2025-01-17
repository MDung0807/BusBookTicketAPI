﻿using BusBookTicket.Auth.Security;
using BusBookTicket.Buses.DTOs.Requests;
using BusBookTicket.Buses.DTOs.Responses;
using BusBookTicket.Buses.Paging.BusType;
using BusBookTicket.Buses.Services.BusTypeServices;
using BusBookTicket.Buses.Utils;
using BusBookTicket.Buses.Validator;
using BusBookTicket.Core.Common;
using BusBookTicket.Core.Common.Exceptions;
using BusBookTicket.Core.Utils;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusBookTicket.Buses.Controllers;

[ApiController]
[Route("api/bustypes")]
public class BusTypeController : ControllerBase
{
    private readonly IBusTypeService _busTypeService;

    public BusTypeController(IBusTypeService busTypeService)
    {
        _busTypeService = busTypeService;
    }

    #region -- Controllers --
    
    [Authorize(Roles = "ADMIN")]
    [HttpGet("admin/active")]
    public async Task<IActionResult> Active(int id)
    {
        int userId = JwtUtils.GetUserID(HttpContext);
        bool status = await _busTypeService.ChangeIsActive(id, userId);
        return Ok(new Response<string>(!status, BusTypeConstants.SUCCESS));
    }
    [Authorize(Roles = "ADMIN")]
    [HttpGet("admin/disable")]
    public async Task<IActionResult> Disable(int id)
    {
        int userId = JwtUtils.GetUserID(HttpContext);
        bool status = await _busTypeService.ChangeToDisable(id, userId);
        return Ok(new Response<string>(!status, BusTypeConstants.SUCCESS));
    }
        
    [Authorize(Roles = "ADMIN")]
    [HttpGet("admin/waiting")]
    public async Task<IActionResult> ChangeIsWaiting(int id)
    {
        int userId = JwtUtils.GetUserID(HttpContext);
        bool status = await _busTypeService.ChangeToWaiting(id, userId);
        return Ok(new Response<string>(!status, BusTypeConstants.SUCCESS));
    }
    
    [HttpGet("getAll")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromQuery] BusTypePaging paging)
    {
        BusTypePagingResult responses = await _busTypeService.GetAll(paging);
        return Ok(new Response<BusTypePagingResult>(false, responses));
    }
    
    [HttpGet("find")]
    [AllowAnonymous]
    public async Task<IActionResult> Find([FromQuery] string param, [FromQuery] BusTypePaging paging)
    {
        BusTypePagingResult responses = await _busTypeService.FindByParam(param, paging);
        return Ok(new Response<BusTypePagingResult>(false, responses));
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        BusTypeResponse response = await _busTypeService.GetById(id);
        return Ok(new Response<BusTypeResponse>(false, response));
    }
    
    [Authorize(Roles = "ADMIN")]
    [HttpPut("admin/update")]
    public async Task<IActionResult> Update([FromBody] BusTypeFormUpdate request)
    {
        var validator = new BusTypeFormUpdateValidator();
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidatorException(result.Errors);
        }
        int userId = JwtUtils.GetUserID(HttpContext);
        bool status = await _busTypeService.Update(request, request.Id, userId);
        return Ok(new Response<string>(!status, "Response"));
    }
    
    [Authorize(Roles = "ADMIN")]
    [HttpPost("admin/create")]
    public async Task<IActionResult> CreateByAdmin([FromBody] BusTypeForm request)
    {
        var validator = new BusTypeFormValidator();
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidatorException(result.Errors);
        }
        int userId = JwtUtils.GetUserID(HttpContext);
        request.Status = (int)EnumsApp.Active;
        bool status = await _busTypeService.Create(request, userId);
        return Ok(new Response<string>(!status, "Response"));
    }
    
    [Authorize(Roles = "ADMIN")]
    [HttpDelete("admin/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        int userId = JwtUtils.GetUserID(HttpContext);
        bool status = await _busTypeService.Delete(id, userId);
        return Ok(new Response<string>(!status, "Response"));
    }
    
    [Authorize(Roles = "COMPANY")]
    [HttpPost("companies/create")]
    public async Task<IActionResult> CreateByCompany([FromBody] BusTypeForm request)
    {
        var validator = new BusTypeFormValidator();
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidatorException(result.Errors);
        }
        request.Status = 0;
        int userId = JwtUtils.GetUserID(HttpContext);
        bool status = await _busTypeService.Create(request, userId);
        return Ok(new Response<string>(!status, "Response"));
    }

    [HttpGet("companies/statistical")]
    [Authorize(Roles = AppConstants.COMPANY)]
    public async Task<IActionResult> Statistical()
    {
        int userId = JwtUtils.GetUserID(HttpContext);
        var result = await _busTypeService.Statistical(idMaster: userId);
        return Ok(new Response<Object>(false, result));
    }
    
    [HttpGet("admin/statistical")]
    [Authorize(Roles = AppConstants.ADMIN)]
    public async Task<IActionResult> AdminStatistical()
    {
        var result = await _busTypeService.Statistical();
        return Ok(new Response<Object>(false, result));
    }
    #endregion -- Controllers --
}