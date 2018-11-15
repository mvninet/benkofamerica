using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTO.Models
{
    public class ParcelDimensions
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }
        
        public ParcelDimensions(float width, float height, float length)
        {
            Width = width;
            Height = height;
            Length = length;
        }

    }
}