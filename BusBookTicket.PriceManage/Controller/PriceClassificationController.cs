﻿using BusBookTicket.Auth.Security;
using BusBookTicket.Core.Common;
using BusBookTicket.Core.Common.Exceptions;
using BusBookTicket.Core.Utils;
using BusBookTicket.PriceManage.DTOs.Requests;
using BusBookTicket.PriceManage.Paging;
using BusBookTicket.PriceManage.Services;
using BusBookTicket.PriceManage.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusBookTicket.PriceManage.Controller;

[ApiController]
[Route("api/PriceClassifications")]
public class PriceClassificationController : ControllerBase
{
    private readonly IPriceClassificationService _service;

    public PriceClassificationController(IPriceClassificationService service)
    {
        _service = service;
    }

    #region -- Controller --

    [Authorize(Roles = AppConstants.COMPANY)]
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] PriceClassificationCreate request)
    {
        var validator = new PriceClassificationCreateValidator();
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidatorException(result.Errors);
        }

        int userId = JwtUtils.GetUserID(HttpContext);
        request.CompanyName = JwtUtils.GetUserName(HttpContext);
        var status = await _service.Create(request, userId);
        return Ok(new Response<string>(!status, AppConstants.SUCCESS));
    }

    [HttpGet("find")]
    [Authorize(Roles = AppConstants.COMPANY)]
    public async Task<IActionResult> FindByParam([FromQuery] string param, [FromQuery] PriceClassificationPaging paging)
    {
        var result = await _service.FindByParam(param: param, paging);
        return Ok(new Response<PriceClassificationPagingResult>(false, result));
    }
    [Authorize(Roles = AppConstants.COMPANY)]
    [HttpGet("getInCompany")]
    public async Task<IActionResult> GetInCompany([FromQuery] PriceClassificationPaging paging)
    {
        int userId = JwtUtils.GetUserID(HttpContext);
        var result = await _service.GetAll(paging, userId);
        return Ok(new Response<PriceClassificationPagingResult>(false,result));
    }
    
    [HttpGet("getActiveInCompany")]
    public async Task<IActionResult> GetActiveInCompany([FromQuery] PriceClassificationPaging paging)
    {
        int userId = JwtUtils.GetUserID(HttpContext);
        var result = await _service.GetAll(paging, userId, checkStatus: true);
        return Ok(new Response<PriceClassificationPagingResult>(false,result));
    }
    
    [Authorize(Roles = AppConstants.ADMIN)]
    [HttpPut("ChangeIsActive")]
    public async Task<IActionResult> ChangeIsActive([FromQuery] int id)
    {
        int userId = JwtUtils.GetUserID(HttpContext);
        var result = await _service.ChangeIsActive(id, userId);
        return Ok(new Response<string>(!result, AppConstants.SUCCESS));
    }
    
    [Authorize(Roles = AppConstants.ADMIN)]
    [HttpPut("ChangeIsWaiting")]
    public async Task<IActionResult> ChangeIsWaiting([FromQuery] int id)
    {
        int userId = JwtUtils.GetUserID(HttpContext);
        var result = await _service.ChangeToWaiting(id, userId);
        return Ok(new Response<string>(!result, AppConstants.SUCCESS));
    }
    
    [Authorize(Roles = AppConstants.ADMIN)]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] PriceClassificationPaging paging)
    {
        int userId = JwtUtils.GetUserID(HttpContext);
        var result = await _service.GetAllByAdmin(paging);
        return Ok(new Response<PriceClassificationPagingResult>(false, result));
    }
    #endregion -- Controller --
}