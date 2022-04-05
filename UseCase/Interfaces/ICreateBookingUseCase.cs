using appointment_sys_api.Boundary.Request;
using appointment_sys_api.Boundary.Response;

namespace appointment_sys_api.UseCase.Interfaces;

    public interface ICreateBookingUseCase
    {
        public BookingResponse Execute(BookingRequest request);
    }
