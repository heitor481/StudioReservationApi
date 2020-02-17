using StudioReservation.Shared.Entity;

namespace StudioReservation.NewDomain.Entities
{
    public class ReservationStudioRoomSchedule : IIdentity
    {
        public virtual Reservation Reservation { get; set; }
        public int ReservationId { get; set; }

        public virtual StudioRoomSchedule StudioRoomSchedule { get; set; }

        public int StudioRoomScheduleId { get; set; }
    }
}
