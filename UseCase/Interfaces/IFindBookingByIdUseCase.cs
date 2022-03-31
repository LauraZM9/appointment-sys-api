using System;
using appointment_sys_api.Boundary.Response;

namespace appointment_sys_api.UseCase.Interfaces;

public interface IFindBookingByIdUseCase
{
    public BookingResponse Execute(int id);
}