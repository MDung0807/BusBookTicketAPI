﻿using AutoMapper;
using BusBookTicket.Buses.DTOs.Requests;
using BusBookTicket.Buses.DTOs.Responses;
using BusBookTicket.Buses.Services.SeatServices;
using BusBookTicket.Buses.Services.SeatTypServices;
using BusBookTicket.Buses.Specification;
using BusBookTicket.Core.Infrastructure.Interfaces;
using BusBookTicket.Core.Models.Entity;
using BusBookTicket.Core.Utils;

namespace BusBookTicket.Buses.Services.BusTypeServices;

public class BusService : IBusService
{
    #region -- Properties --

    private readonly IMapper _mapper;
    private readonly IBusTypeService _busTypeService;
    private readonly ISeatTypeService _seatTypeService;
    private readonly ISeatService _seatService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Bus> _repository;
    private readonly IGenericRepository<BusStop> _busStopRepository;
    #endregion -- Properties --

    public BusService(
        IMapper mapper, 
        IBusTypeService busTypeService
        ,ISeatTypeService seatTypeService
        ,ISeatService seatService,
        IUnitOfWork unitOfWork)
    {
        this._mapper = mapper;
        this._seatTypeService = seatTypeService;
        this._busTypeService = busTypeService;
        this._seatService = seatService;
        this._unitOfWork = unitOfWork;
        this._repository = unitOfWork.GenericRepository<Bus>();
        this._busStopRepository = unitOfWork.GenericRepository<BusStop>();
    }
    public async Task<BusResponse> GetById(int id)
    {
        BusSpecification busSpecification = new BusSpecification(id);
        Bus bus = await _repository.Get(busSpecification);
        return _mapper.Map<BusResponse>(bus);
    }

    public async Task<List<BusResponse>> GetAll()
    {
        BusSpecification busSpecification = new BusSpecification();
        List<Bus> buses = await _repository.ToList(busSpecification);
        List<BusResponse> responses = await AppUtils.MappObject<Bus, BusResponse>(buses, _mapper);
        return responses;
    }

    public async Task<bool> Update(FormUpdateBus entity, int id, int userId)
    {
        Bus bus = _mapper.Map<Bus>(entity);
        bus.Id = id;
        await _repository.Update(bus, userId);
        return true;
    }

    public async Task<bool> Delete(int id, int userId)
    {
        BusSpecification busSpecification = new BusSpecification(id);
        Bus bus = await _repository.Get(busSpecification);
        bus.Status = (int)EnumsApp.Delete;
        await _repository.Update(bus, userId);
        return true;
    }

    public async Task<bool> Create(FormCreateBus entity, int userId)
    {
        await _unitOfWork.BeginTransaction();
        try
        {
            //Get Data
            BusTypeResponse busType = await _busTypeService.GetById(entity.busTypeID);
            SeatTypeResponse seatType = await _seatTypeService.GetById(entity.seatTypeID);
            
            //Save Bus
            Bus bus = _mapper.Map<Bus>(entity);
            bus.Status = (int)EnumsApp.Active;
            bus = await _repository.Create(bus, userId);
            
            foreach (int stationID in entity.listBusStopID)
            {
                BusStop busStop = new BusStop();
                busStop.BusStation ??= new BusStation();
                busStop.BusStation.Id = stationID;
                busStop.Bus ??= new Bus();
                busStop.Bus.Id= bus.Id;

                await _busStopRepository.Create(busStop, userId);
            }
            
            int totalSeat = busType.totalSeats == 0? 1: busType.totalSeats;

            
            //Save Seat in bus
            for (int i = 0; i < totalSeat; i++)
            {
                SeatForm seatForm = new SeatForm();
                seatForm.seatNumber = seatType.type + "_" + i.ToString();
                seatForm.seatTypeID = seatType.typeID;
                seatForm.busID = bus.Id;
                seatForm.description = "";
                seatForm.price = seatType.price;
                seatForm.seatID = 0;

                await _seatService.Create(seatForm, userId);
            }
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            await _unitOfWork.RollbackTransactionAsync();
            Console.WriteLine(e);
            throw new Exception("ERRROR");
        }
    }
}