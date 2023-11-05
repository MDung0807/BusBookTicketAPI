using BusBookTicket.BusStationManage.DTOs.Requests;
using BusBookTicket.BusStationManage.DTOs.Responses;
using BusBookTicket.Core.Common;
using BusBookTicket.Core.Infrastructure.Interfaces;

namespace BusBookTicket.BusStationManage.Services;

public interface IBusStationService : IService<BST_FormCreate, BST_FormUpdate, int, BusStationResponse>
{
    Task<BusStationResponse> getStationByName(string name);
    Task<List<BusStationResponse>> getStationByLocation(string location);
}