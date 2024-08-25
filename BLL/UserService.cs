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
        UserEntity user = null;
        UserRepository obj = new UserRepository();
        public bool InsertUser(string name, string username, string email, string password, string role, string phone, string address, string zip)
        {
            user = new UserEntity
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
            int i = obj.AddUser(user);
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
            int id = obj.GetId(uname, pwd);
            return id;
        }
        public string GetUserRole(string uname, string pwd)
        {
            string role = obj.GetRole(uname, pwd);
            return role;
        }
        public bool ValidateUser(string uname, string pwd) {
            string count = obj.GetCountOfId(uname, pwd);
            if(count == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
