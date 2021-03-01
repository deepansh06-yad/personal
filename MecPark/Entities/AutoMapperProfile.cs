using AutoMapper;
using Entities;
using MecPark.Entities;
using Models.AllocationManagers;
using Models.Garages;
using Models.ParkingHistories;
using Models.ParkingManagers;
using Models.Parkings;
using Models.Spaces;
using Models.Users;


namespace Entities.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();

            CreateMap<AllocationManager, AllocationManagerModel>();
            CreateMap<ParkingManager, ParkingManagerModel>();

            CreateMap<Garage, GarageModel>();
            CreateMap<CreateGarageModel, Garage>();
            CreateMap<UpdateGarageModel, Garage>();

            CreateMap<Space, SpaceModel>();
            CreateMap<CreateSpaceModel, Space>();
            CreateMap<UpdateSpaceModel, Space>();

            CreateMap<BookParkingModel, Parking>();
            CreateMap<ParkingHistory, ReceiptModel>();
        }
    }
}