using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.Repositories;
using DAL.Entities;

namespace BLL
{
    public class UserService
    {
        UserDataAccess userDataAccess = new UserDataAccess();
        public bool InsertUser(string name, string username, string email, string password, string role, string phone, string address, string zip)
        {
            var user = new UserEntity
            {
                FullName = name,
                Username = username,
                Email = email,
                Password = password,
                Role = role,
                Phone = phone,
                Address = address,
                ZipCode = zip
            };
            int i = userDataAccess.AddUser(user);
            if(i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetUserId(string uname, string pwd)
        {
            int id = userDataAccess.GetId(uname, pwd);
            return id;
        }
        public string GetUserRole(string uname, string pwd)
        {
            string role = userDataAccess.GetRole(uname, pwd);
            return role;
        }
        public bool ValidateUser(string uname, string pwd) {
            string count = userDataAccess.GetCountOfId(uname, pwd);
            if(count == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public (string FullName, string Email) GetUserNameAndEmail(int uId)
        {
            return userDataAccess.GetNameAndEmail(uId);
        }
    }
}
