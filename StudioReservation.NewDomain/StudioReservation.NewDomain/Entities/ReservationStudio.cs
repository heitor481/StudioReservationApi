namespace StudioReservation.NewDomain.Entities
{
    public class ReservationStudio
    {
        public virtual Reservation Reservation { get; set; }
        public int ReservationId { get; set; }

        public virtual Studio Studio { get; set; }

        public int StudioId { get; set; }
    }
}
