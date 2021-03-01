using Business.Interface;
using Entities.Repository;
using MecPark.Entities;
using Models.AllocationManagers;
using Models.ParkingManagers;
using Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class UserManager : IUserManager
    {
        private readonly IUserService _dbcontext;
        public UserManager(IUserService dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public UserModel Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User Create(User user, string password, string origin)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void ForgotPassword(ForgotPasswordModel model, string orgin)
        {
            throw new NotImplementedException();
        }

        public AllocationManagerModel GetAllocationManagerById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetAllocationManagerId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AllocationManagerModel> GetAllocationManagers()
        {
            return _dbcontext.GetAllocationManagers();
        }

        public ParkingManagerModel GetParkingManagerById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetParkingManagerId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParkingManagerModel> GetParkingManagers()
        {
            return _dbcontext.GetParkingManagers();
        }

        public string getRole(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void ResetPassword(ResetPasswordModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(User userParam, string password = null)
        {
            return _dbcontext.Update(userParam);
        }

        public void VerifyEmail(string token)
        {
            throw new NotImplementedException();
        }
    }
}
