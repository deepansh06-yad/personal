﻿using System.Collections.Generic;

namespace MecPark.Entities
{
    public class Garage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public bool hasCleaningService { get; set; }
        public string TotalCapacity { get; set; }
        public string OccupiedCapacity { get; set; }
        public int ParkingManagerId { get; set; }
        public ParkingManager ParkingManager { get; set; }
        public string Space { get; set; }
        public string ParkingRate { get; set; }
        public string CleaningRate { get; set; }
        public List<Space> Spaces { get; set; }
    }
}
