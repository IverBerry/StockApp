using Microsoft.EntityFrameworkCore;
using StockApp.Context;
using StockApp.Entities;
using StockApp.Models.Users;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockApp.Services
{
    public class UserService
    {
        private readonly ApplicationContext _dbContext;

        public UserService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<LoginUserViewModel> Login(LoginUserViewModel vm)
        {
            var user = _dbContext.Users.FirstOrDefault(u=> u.UserName == vm.UserName && u.Password == vm.Password);

            if(user == null)
            {
                vm.HasError = true;
                vm.Error = "Creedenciales incorrectas.";
            }

            return vm;

        }

        

        public async Task<List<UserViewModel>> GetAllUsers( )
        {
            var users = await _dbContext.Users.ToListAsync();

            var usersvm = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
                Phone = user.Phone,
            }).ToList();


            return usersvm;

        }

		public async Task<RegisterUserViewModel> Register(RegisterUserViewModel vm)
		{
			var user = _dbContext.Users.FirstOrDefault(u => u.UserName == vm.UserName);

			if (user != null)
			{
				vm.HasError = true;
				vm.Error = "Existe un usuario con este username, ingrese otro.";
				return vm;
			}

			User newuser = new();
			newuser.FirstName = vm.FirstName;
			newuser.LastName = vm.LastName;
			newuser.Email = vm.Email;
			newuser.UserName = vm.UserName;
			newuser.Password = vm.Password;
			newuser.Phone = vm.Phone;

			_dbContext.Users.Add(newuser);
			_dbContext.SaveChanges();

			return vm;

		}

		public async Task Update(UpdateUserViewModel vm)
		{

			var usertoupdate = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == vm.Id);

			if (usertoupdate != null)
			{
                usertoupdate.FirstName = vm.FirstName;
                usertoupdate.LastName = vm.LastName;
                usertoupdate.Email = vm.Email;
                usertoupdate.UserName = vm.UserName;
                usertoupdate.Phone = vm.Phone;

				_dbContext.Users.Update(usertoupdate);
				_dbContext.SaveChanges();
			}

		}

		public async Task Delete(int id)
		{

			var usertodelete = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

			if (usertodelete != null)
			{
				_dbContext.Users.Remove(usertodelete);
				_dbContext.SaveChanges();
			}

		}


        public async Task<UpdateUserViewModel> GetUpdateViewModelById(int id)
        {
			UpdateUserViewModel updateUserViewModel = new();
			var usertoupdate = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (usertoupdate != null)
            {
                updateUserViewModel.Id = usertoupdate.Id;
                updateUserViewModel.UserName = usertoupdate.UserName; 
                updateUserViewModel.FirstName = usertoupdate.FirstName;
                updateUserViewModel.LastName = usertoupdate.LastName;
                updateUserViewModel.Phone = usertoupdate.Phone;
                updateUserViewModel.Email = usertoupdate.Email;
            }

			return updateUserViewModel;
        }

	}
}
