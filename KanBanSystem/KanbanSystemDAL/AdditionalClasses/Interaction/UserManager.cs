﻿using KanbanSystemDAL.AdditionalClasses.Helpers;
using KanbanSystemDAL.Model;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Interaction
{
    public class UserManager
    {
        KanbanSystemContext context;
        public UserManager(KanbanSystemContext _context)
        {
            context = _context;
        }
        public async Task RegisterAsync(User user)
        {
            try
            {
                var foundUser = await FindHelper<User>.FindEntityAsync(context.Users, user);
                foundUser = CheckNullHelper<User>.CheckNullable(foundUser, "User with such login data is already in DB", true);
                context.Users.Add(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> LoginAsync(LoginData loginData)
        {
            try
            {
                var foundUser = await context.Users.FirstOrDefaultAsync(x => x.LoginData.CompareTo(loginData).Equals(0));
                return CheckNullHelper<User>.CheckNullable(foundUser, "User with such login data not found", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}