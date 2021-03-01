using MecPark.Entities;
using Models.AllocationManagers;
using Models.ParkingManagers;
using Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IUserManager
    {
        UserModel Authenticate(string email, string password);
        void VerifyEmail(string token);
        void ForgotPassword(ForgotPasswordModel model, string orgin);
        void ResetPassword(ResetPasswordModel model);
        IEnumerable<UserModel> GetUsers();
        IEnumerable<AllocationManagerModel> GetAllocationManagers();
        IEnumerable<ParkingManagerModel> GetParkingManagers();
        UserModel GetUserById(int id);
        AllocationManagerModel GetAllocationManagerById(int id);
        ParkingManagerModel GetParkingManagerById(int id);
        User Create(User user, string password, string origin);
        void Update(User user, string password = null);
        void Delete(int id);
        string getRole(int id);
        int GetAllocationManagerId(int id);
        int GetParkingManagerId(int id);
    }
}
