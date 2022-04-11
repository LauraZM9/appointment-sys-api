using appointment_sys_api.Boundary.Response;
using appointment_sys_api.Boundary.Request;

namespace appointment_sys_api.UseCase.Interfaces;

public interface ICreateBookingUseCase
{
    public BookingResponse Execute(BookingRequest request);
}