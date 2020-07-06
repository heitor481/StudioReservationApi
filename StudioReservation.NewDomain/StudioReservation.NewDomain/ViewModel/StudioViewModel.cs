using System.Collections.Generic;
using StudioReservation.NewDomain.ValueObjects;

namespace StudioReservation.NewDomain.ViewModel
{
    public class StudioViewModel
    {
        public string StudioName { get; set; }

        public int Id { get; set; }

        public Address Address { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            StudioViewModel studioViewModel = obj as StudioViewModel;
            return (studioViewModel != null)
                && (StudioName == studioViewModel.StudioName)
                && (Id == studioViewModel.Id)
                && (Address == studioViewModel.Address);
        }

        public override int GetHashCode()
        {
            //it means that in some point, it could cause an overflow of int value. And we are okay with that
            unchecked
            {
                const int HashingBase = (int) 2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!object.ReferenceEquals(null, StudioName) ? StudioName.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!object.ReferenceEquals(null, Id) ? Id.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!object.ReferenceEquals(null, Address) ? Address.GetHashCode() : 0);
                return hash;
            }
        }
    }

}