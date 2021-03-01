using MecPark.Entities;
using Models.AllocationManagers;
using Models.ParkingManagers;
using Models.Users;
using System.Collections.Generic;
namespace Entities.Repository
{
    public interface IUserService
    {
        public UserModel Authenticate(string email, string password);
        public void VerifyEmail(string token);
        public void ForgotPassword(ForgotPasswordModel model, string origin);
        public void ResetPassword(ResetPasswordModel model);
        public IEnumerable<UserModel> GetUsers();
        public IEnumerable<AllocationManagerModel> GetAllocationManagers();
        public IEnumerable<ParkingManagerModel> GetParkingManagers();
        public UserModel GetUserById(int id);
        public AllocationManagerModel GetAllocationManagerById(int id);
        public ParkingManagerModel GetParkingManagerById(int id);
        User Create(User user, string password, string origin);
        void Update(User user, string password = null);
        public void Delete(int id);
        public string getRole(int id);
        public int GetAllocationManagerId(int id);
        public int GetParkingManagerId(int id);
    }
}
