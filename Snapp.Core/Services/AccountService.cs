using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snapp.Core.Generators;
using Snapp.Core.Interfaces;
using Snapp.Core.Securities;
using Snapp.Core.Senders;
using Snapp.Core.ViewModels;
using Snapp.DataAccessLayer.Context;
using Snapp.DataAccessLayer.Entities;

namespace Snapp.Core.Services
{
	public class AccountService : IAccount
	{
		private DatabaseContext _context;

		public AccountService(DatabaseContext context)
		{
			_context = context;
		}
		public void Dispose()
		{
			if (_context != null)
			{
				_context.Dispose();
			}
		}

		public bool CheckMobileNumber(string username)
		{
			return _context.Users.Any(u => u.Username == username);
		}

		public async Task<User> RegisterUser(RegisterViewModel viewModel)
		{
			if (!CheckMobileNumber(viewModel.Username))
			{
				var tempCode = CodeGenerators.GetActiveCode();
				//ثبت نام و ارسال پیامک فعالسازی
				User user = new User()
				{
					IsActive = false,
					Id = CodeGenerators.GetId(),
					Password = HashEncode.GetHashCode(HashEncode.GetHashCode(tempCode)),
					RoleId = GetRoleByName("user"),
					Token = null,
					Username = viewModel.Username,
				};

				_context.Users.Add(user);

				UserDetail userDetail = new UserDetail()
				{
					UserId = user.Id,
					BirthDate = null,
					Date = DateTimeGenerator.GetShamsiDate(),
					Time = DateTimeGenerator.GetShamsiTime(),
					FullName = null,
				};

				_context.UserDetails.Add(userDetail);
				_context.SaveChanges();

				try
				{
					SmsSender.VerifySend(user.Username, tempCode);
				}
				catch
				{
					
				}
				return await Task.FromResult(user);
			}
			else
			{
				User user =await GetUser(viewModel.Username);
				string code = CodeGenerators.GetActiveCode();
				UpdateUserPassword(user.Id, code);

				try
				{
					SmsSender.VerifySend(user.Username, code);
				}
				catch
				{

				}
				return await Task.FromResult(user);
			}
		}

        public async Task<User> RegisterDriver(RegisterViewModel viewModel)
        {
            if (!CheckMobileNumber(viewModel.Username))
            {
                var tempCode = CodeGenerators.GetActiveCode();
                //ثبت نام و ارسال پیامک فعالسازی
                User user = new User()
                {
                    IsActive = false,
                    Id = CodeGenerators.GetId(),
                    Password = HashEncode.GetHashCode(HashEncode.GetHashCode(tempCode)),
                    RoleId = GetRoleByName("driver"),
                    Token = null,
                    Username = viewModel.Username,
                };

                _context.Users.Add(user);

                UserDetail userDetail = new UserDetail()
                {
                    UserId = user.Id,
                    BirthDate = null,
                    Date = DateTimeGenerator.GetShamsiDate(),
                    Time = DateTimeGenerator.GetShamsiTime(),
                    FullName = null,
                };

                _context.UserDetails.Add(userDetail);

                Driver driver = new Driver()
                {
					IsConfirm = false,
					Address = null,
					Avatar = null,
					CarId= null,
					ColorId = null,
					Img = null,
					CarCode = null,
					Tel = null,
					NationalCode = null,
					UserId = user.Id,
                };

				_context.Drivers.Add(driver);

                _context.SaveChanges();

                try
                {
                    SmsSender.VerifySend(user.Username,  tempCode);
                }
                catch
                {
					
                }
                return await Task.FromResult(user);
            }
            else
            {
                User user =await GetUser(viewModel.Username);
                string code = CodeGenerators.GetActiveCode();
                UpdateUserPassword(user.Id, code);

                try
                {
                    SmsSender.VerifySend(user.Username,  code);
                }
                catch
                {

                }
                return await Task.FromResult(user);
            }
        }

        public Guid GetRoleByName(string name)
		{
			return _context.Roles.SingleOrDefault(r => r.Name == name).Id;
		}

		public async Task<User> GetUser(string username)
		{
			return await Task.FromResult(_context.Users.SingleOrDefault(u => u.Username == username));
		}

		public void UpdateUserPassword(Guid Id, string code)
		{
			User user = _context.Users.Find(Id);
			user.Password = HashEncode.GetHashCode(HashEncode.GetHashCode(code));
			_context.SaveChanges();
		}

		public async Task<User> ActiveUser(ActiveViewModel viewModel)
		{
			string password = HashEncode.GetHashCode(HashEncode.GetHashCode(viewModel.Code));
			User user = _context.Users.SingleOrDefault(u => u.Password == password);
			if (user != null)
			{
				user.IsActive = true;
				user.Password = HashEncode.GetHashCode(HashEncode.GetHashCode(CodeGenerators.GetActiveCode()));

				_context.SaveChanges();
			}

			return await Task.FromResult(user);
		}
	}
}
