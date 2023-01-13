using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snapp.Core.ViewModels;
using Snapp.DataAccessLayer.Entities;

namespace Snapp.Core.Interfaces
{
	public interface IAccount : IDisposable
	{
		bool CheckMobileNumber(string username);

		Task<User> RegisterUser(RegisterViewModel viewModel);

		Task<User> RegisterDriver(RegisterViewModel viewModel);

		Guid GetRoleByName(string name);

		Task<User> GetUser(string username);

		void UpdateUserPassword(Guid Id, string code);

		Task<User>	ActiveUser(ActiveViewModel viewModel);
	}
}
