using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTO.Models
{
    public class ParcelType
    {
        public string ParcelTypeName { get; set; }
        public float TypeCost { get; set; }

        public ParcelType(string parcelTypeName, float typeCost)
        {
            ParcelTypeName = parcelTypeName;
            TypeCost = typeCost;
        }
    }
}