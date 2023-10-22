﻿using System;
using System.Collections;
using System.Collections.Generic;
using TravelSite.Models;
using TravelSite.Models.Params;

namespace TravelSite.Params
{
    public class TouristRouteFromCreationParam
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal price { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        public string Features { get; set; }

        public string Fees { get; set; }

        public string Notes { get; set; }

        public double? Rating { get; set; }
        public string TravelDays { get; set; }
        public string TripType { get; set; }
        public string DepartureCity { get; set; }
        public ICollection<TouristRoutePictureParam> TouristRoutePictures { get; set; }
            = new List<TouristRoutePictureParam>();
    }
}
