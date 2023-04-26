using Core.Dtos;
using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;


        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Register(RegisterDto registerData)
        {
            if (registerData == null)
            {
                return;
            }


            var user = new User
            {
                Username = registerData.Username,
                Email = registerData.Email,
                Password = registerData.Password,
                RoleId = registerData.RoleId
            };
            unitOfWork.Users.Insert(user);
            unitOfWork.SaveChanges();
        }

 
        public List<User> GetAll()
        {
            var results = unitOfWork.Users.GetAll();

            return results;
        }

        public UserDto GetById(int userId)
        {
            var user = unitOfWork.Users.GetById(userId);

            var result = user.ToUserDto();

            return result;
        }
    }
}
