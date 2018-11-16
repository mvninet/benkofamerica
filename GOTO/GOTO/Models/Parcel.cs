using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTO.Models
{
    public class Parcel
    {
        public ParcelType TypeOfParcel { get; set; }
        public ParcelDimensions Dimensions { get; set; }
        public float Weight { get; set; }

        public Parcel(ParcelType typeOfParcel, ParcelDimensions dimensions, float weight)
        {
            TypeOfParcel = typeOfParcel;
            Dimensions = dimensions;
            Weight = weight;
        }
    }
}