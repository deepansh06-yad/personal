﻿namespace Models.Garages
{
    public class GarageModel
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
        public string Space { get; set; }
    }
}
