﻿using BusBookTicket.Application.Notification.Paging;
using BusBookTicket.Application.Notification.Services;
using BusBookTicket.Application.Notification.Specification;
using BusBookTicket.Core.Infrastructure.Interfaces;
using BusBookTicket.Core.Models.Entity;
using BusBookTicket.Core.Utils;
using Microsoft.AspNetCore.SignalR;

namespace BusBookTicket.Application.Notification;

public class NotificationHub : Hub
{
    private static Dictionary<string, int> _clientsNotification = new();

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<NotificationObject> _repository;
    private readonly INotificationService _notificationService;

    public NotificationHub(IUnitOfWork unitOfWork, INotificationService notificationService)
    {
        _unitOfWork = unitOfWork;
        _notificationService = notificationService;
        _repository = unitOfWork.GenericRepository<NotificationObject>();
    }
    public override async Task OnConnectedAsync()
    {
        
        string token = Context.GetHttpContext()?.Request.Query["access_token"].ToString() ?? throw new Exception();
        var claims = JWTUtils.GetPrincipal(token);
        string role = claims.Claims.ElementAt(2).Value;
        string userId = claims.Claims.ElementAt(0).Value;
        
        await Groups.AddToGroupAsync(Context.ConnectionId, $"{role}_{userId}");
        await Groups.AddToGroupAsync(Context.ConnectionId, role);

        //Add client into group with role
        NotificationObjectSpecification specification = new NotificationObjectSpecification(actor:$"{role}_{userId}");
        int countNotificationNotSeen = await _repository.Count(specification);
        var notifications = await _notificationService.GetNotification(actor:$"{role}_{userId}");
        await Clients.Group($"{role}_{userId}").SendAsync("ReceiveCountUnReadingNotification",countNotificationNotSeen );
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        string token = Context.GetHttpContext()?.Request.Query["access_token"].ToString() ?? throw new Exception();
        string username = JWTUtils.GetUserName(token);
        _clientsNotification.Remove(username);
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, username);
        await base.OnDisconnectedAsync(exception);
    }
}