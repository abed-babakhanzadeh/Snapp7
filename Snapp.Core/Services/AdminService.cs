using Microsoft.EntityFrameworkCore;
using Snapp.Core.Generators;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Admin;
using Snapp.DataAccessLayer.Context;
using Snapp.DataAccessLayer.Entities;


namespace Snapp.Core.Services
{
	using Snapp.Core.Securities;

	public class AdminService : IAdmin
	{
		private DatabaseContext _context;

		public AdminService(DatabaseContext context)
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

		#region Car

		public async Task<List<Car>> GetCars()
		{
			return await _context.Cars.OrderBy(c => c.Name).ToListAsync();
		}

		public async Task<Car> GetCarById(Guid id)
		{
			return await _context.Cars.FindAsync(id);
		}

		public void AddCar(CarViewModel viewModel)
		{
			Car car = new Car()
			{
				Id = CodeGenerators.GetId(),
				Name = viewModel.Name,
			};
			_context.Cars.Add(car);
			_context.SaveChanges();
		}

		public bool UpdateCar(Guid id, CarViewModel viewModel)
		{
			Car car = _context.Cars.Find(id);
			if (car != null)
			{
				car.Name = viewModel.Name;
				_context.Cars.Update(car);
				_context.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}

		}

		public void DeleteCar(Guid id)
		{
			Car car = _context.Cars.Find(id);
			if (car != null)
			{
				_context.Cars.Remove(car);
				_context.SaveChanges();

			}
		}

		#endregion

		#region Color

		public async Task<List<Color>> GetColors()
		{
			return await _context.Colors.OrderBy(c => c.Name).ToListAsync();
		}

		public async Task<Color> GetColorsById(Guid id)
		{
			return await _context.Colors.FindAsync(id);
		}

		public void AddColor(ColorViewModel viewModel)
		{
			Color color = new Color()
			{
				Id = CodeGenerators.GetId(),
				Name = viewModel.Name,
				Code = viewModel.Code,
			};
			_context.Colors.Add(color);
			_context.SaveChanges();
		}

		public bool UpdateColor(Guid id, ColorViewModel viewModel)
		{
			Color color = _context.Colors.Find(id);
			if (color != null)
			{
				color.Name = viewModel.Name;
				color.Code = viewModel.Code;
				//_context.Colors.Update(color);
				_context.SaveChanges();
				return true;
			}

			return false;
		}

		public void DeleteColor(Guid id)
		{
			Color color = _context.Colors.Find(id);
			if (color != null)
			{
				_context.Colors.Remove(color);
				_context.SaveChanges();
			}
		}

		#endregion

		#region RateType

		public async Task<List<RateType>> GetRateTypes()
		{
			return await _context.RateTypes.OrderBy(r => r.Name).ToListAsync();
		}

		public async Task<RateType> GetRateTypesById(Guid id)
		{
			return await _context.RateTypes.FindAsync(id);
		}

		public void AddRateType(RateTypeViewModel viewModel)
		{
			RateType rateType = new RateType()
			{
				id = CodeGenerators.GetId(),
				Name = viewModel.Name,
				Ok = viewModel.Ok,
				ViewOrder = viewModel.ViewOrder
			};
			_context.Add(rateType);
			_context.SaveChanges();
		}

		public bool UpdateRateType(Guid id, RateTypeViewModel viewModel)
		{
			RateType rateType = _context.RateTypes.Find(id);
			if (rateType != null)
			{
				rateType.Name = viewModel.Name;
				rateType.Ok = viewModel.Ok;
				rateType.ViewOrder = viewModel.ViewOrder;
				_context.SaveChanges();
				return true;
			}

			return false;
		}

		public void DeleteRateType(Guid id)
		{
			RateType rateType = _context.RateTypes.Find(id);
			if (rateType != null)
			{
				_context.RateTypes.Remove(rateType);
				_context.SaveChanges();
			}
		}

		#endregion

		#region SiteSetting

		public async Task<Setting> GetSetting()
		{
			return await _context.Settings.SingleOrDefaultAsync();
		}

		public bool UpdateSiteSetting(SiteSettingViewModel viewModel)
		{
			Setting setting = _context.Settings.SingleOrDefault();
			if (setting != null)
			{
				setting.Name = viewModel.Name;
				setting.Desc = viewModel.Desc;
				setting.Tel = viewModel.Tel;
				setting.Fax = viewModel.Fax;

				_context.SaveChanges();
				return true;
			}

			return false;
		}

		public bool UpdatePriceSetting(PriceSettingViewModel viewModel)
		{
			Setting setting = _context.Settings.SingleOrDefault();
			if (setting != null)
			{
				setting.IsDistance = viewModel.IsDistance;
				setting.IsWeatherPrice = viewModel.IsWeatherPrice;

				_context.SaveChanges();
				return true;
			}

			return false;
		}

		public bool UpdateAboutSetting(AboutSettingViewModel viewModel)
		{
			Setting setting = _context.Settings.SingleOrDefault();
			if (setting != null)
			{
				setting.About = viewModel.About;

				_context.SaveChanges();
				return true;
			}

			return false;
		}

		public bool UpdateTermsSetting(TermsSettingViewModel viewModel)
		{
			Setting setting = _context.Settings.SingleOrDefault();
			if (setting != null)
			{
				setting.Terms = viewModel.Terms;

				_context.SaveChanges();
				return true;
			}

			return false;

		}

		#endregion

		#region PriceType

		public async Task<List<PriceType>> GetPriceTypes()
		{
			return await _context.PriceTypes.OrderBy(p => p.Name).ToListAsync();
		}

		public async Task<PriceType> GetPriceTypesById(Guid id)
		{
			return await _context.PriceTypes.FindAsync(id);
		}

		public void AddPriceType(PriceTypeViewModel viewModel)
		{
			PriceType priceType = new PriceType()
			{
				Id = CodeGenerators.GetId(),
				Name = viewModel.Name,
				Start = viewModel.Start,
				End = viewModel.End,
				Price = viewModel.Price
			};
			_context.PriceTypes.Add(priceType);
			_context.SaveChanges();
		}

		public bool UpdatePriceType(Guid id, PriceTypeViewModel viewModel)
		{
			PriceType priceType = _context.PriceTypes.Find(id);
			if (priceType != null)
			{
				priceType.Name = viewModel.Name;
				priceType.Start = viewModel.Start;
				priceType.End = viewModel.End;
				priceType.Price = viewModel.Price;
				_context.SaveChanges();
				return true;
			}

			return false;
		}

		public void DeletePriceType(Guid id)
		{
			PriceType priceType = _context.PriceTypes.Find(id);
			if (priceType != null)
			{
				_context.Remove(priceType);
				_context.SaveChanges();
			}
		}

		#endregion

		#region MonthType

		public async Task<List<MonthType>> GetMonthTypes()
		{
			return await _context.MonthTypes.OrderBy(p => p.Name).ToListAsync();
		}

		public async Task<MonthType> GetMonthTypesById(Guid id)
		{
			return await _context.MonthTypes.FindAsync(id);
		}

		public void AddMonthType(MonthTypeViewModel viewModel)
		{
			MonthType monthType = new MonthType()
			{
				Id = CodeGenerators.GetId(),
				Name = viewModel.Name,
				Start = viewModel.Start,
				End = viewModel.End,
				Percent = viewModel.Percent
			};
			_context.MonthTypes.Add(monthType);
			_context.SaveChanges();
		}

		public bool UpdateMonthType(Guid id, MonthTypeViewModel viewModel)
		{
			MonthType monthType = _context.MonthTypes.Find(id);
			if (monthType != null)
			{
				monthType.Name = viewModel.Name;
				monthType.Start = viewModel.Start;
				monthType.End = viewModel.End;
				monthType.Percent = viewModel.Percent;
				_context.SaveChanges();
				return true;
			}

			return false;
		}

		public void DeleteMonthType(Guid id)
		{
			MonthType monthType = _context.MonthTypes.Find(id);
			if (monthType != null)
			{
				_context.Remove(monthType);
				_context.SaveChanges();
			}
		}

		#endregion

		#region Humidity

		public async Task<List<Humidity>> GetHumidities()
		{
			return await _context.Humidities.OrderBy(h => h.Name).ToListAsync();
		}

		public async Task<Humidity> GetHumiditiesById(Guid id)
		{
			return await _context.Humidities.FindAsync(id);
		}

		public void AddHumidity(MonthTypeViewModel viewModel)
		{
			Humidity humidity = new Humidity()
			{
				Id = CodeGenerators.GetId(),
				End = viewModel.End,
				Percent = viewModel.Percent,
				Start = viewModel.Start,
				Name = viewModel.Name,
			};
			_context.Humidities.Add(humidity);
			_context.SaveChanges();
		}

		public bool UpdateHumidity(Guid id, MonthTypeViewModel viewModel)
		{
			Humidity humidity = _context.Humidities.Find(id);
			if (humidity != null)
			{
				humidity.Start = viewModel.Start;
				humidity.Name = viewModel.Name;
				humidity.Percent = viewModel.Percent;
				humidity.End = viewModel.End;

				_context.SaveChanges();
				return true;
			}

			return false;
		}

		public void DeleteHumidity(Guid id)
		{
			Humidity humidity = _context.Humidities.Find(id);
			if (humidity != null)
			{
				_context.Humidities.Remove(humidity);
				_context.SaveChanges();
			}
		}

		#endregion

		#region Temperature

		public async Task<List<Temperature>> GetTemperatures()
		{
			return await _context.Temperatures.OrderBy(t => t.Name).ToListAsync();
		}

		public async Task<Temperature> GetTemperaturesById(Guid id)
		{
			return await _context.Temperatures.FindAsync(id);
		}

		public void AddTemperature(MonthTypeViewModel viewModel)
		{
			Temperature temperature = new Temperature()
			{
				Id = CodeGenerators.GetId(),
				End = viewModel.End,
				Start = viewModel.Start,
				Name = viewModel.Name,
				Percent = viewModel.Percent
			};
			_context.Temperatures.Add(temperature);
			_context.SaveChanges();
		}

		public bool UpdateTemperature(Guid id, MonthTypeViewModel viewModel)
		{
			Temperature temperature = _context.Temperatures.Find(id);
			if (temperature == null)
			{
				temperature.Start = viewModel.Start;
				temperature.End = viewModel.End;
				temperature.Percent = viewModel.Percent;
				temperature.Name = viewModel.Name;

				_context.SaveChanges();
				return true;
			}

			return false;
		}

		public void DeleteTemperature(Guid id)
		{
			Temperature temperature = _context.Temperatures.Find(id);
			if (temperature != null)
			{
				_context.Temperatures.Remove(temperature);
				_context.SaveChanges();
			}
		}

		#endregion

		#region Role

		public async Task<List<Role>> GetRoles()
		{
			return await _context.Roles.OrderBy(r => r.Name).ToListAsync();
		}

		public async Task<Role> GetRolesById(Guid id)
		{
			return await _context.Roles.FindAsync(id);
		}

		public void AddRole(RoleViewModel viewModel)
		{
			Role role = new Role()
			{
				Id = CodeGenerators.GetId(),
				Name = viewModel.Name,
				Title = viewModel.Title,
			};
			_context.Roles.Add(role);
			_context.SaveChanges();
		}

		public bool UpdateRole(Guid id, RoleViewModel viewModel)
		{
			Role role = _context.Roles.Find(id);
			if (role != null)
			{
				role.Name = viewModel.Name;
				role.Title = viewModel.Title;

				this._context.SaveChanges();
				return true;
			}

			return false;
		}

		public void DeleteRole(Guid id)
		{
			Role role = _context.Roles.Find(id);
			if (role != null)
			{
				_context.Roles.Remove(role);
				_context.SaveChanges();
			}
		}



		#endregion

		#region User

		public bool CheckUsername(string username)
		{
			return _context.Users.Any(u => u.Username == username);
		}

		public void AddUser(UserViewModel viewModel)
		{
			User user = new User()
			{
				Id = CodeGenerators.GetId(),
				IsActive = viewModel.IsActive,
				Password = HashEncode.GetHashCode(HashEncode.GetHashCode(CodeGenerators.GetActiveCode())),
				RoleId = viewModel.RoleId,
				Token = null,
				Username = viewModel.Username,
				Wallet = 0
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

			if (GetRoleId(viewModel.RoleId) == "driver")
			{
				Driver driver = new Driver()
				{
					IsConfirm = false,
					Address = null,
					Avatar = null,
					CarId = null,
					ColorId = null,
					Img = null,
					CarCode = null,
					Tel = null,
					NationalCode = null,
					UserId = user.Id,
				};

				_context.Drivers.Add(driver);
			}

			_context.SaveChanges();
		}

		public async Task<List<User>> GetUsers()
		{
			return await _context.Users.Include(u => u.Role).OrderBy(u => u.Username).ToListAsync();
		}

		public void DeleteUser(Guid id)
		{
			User user = _context.Users.Find(id);
			_context.Users.Remove(user);
			_context.SaveChanges();
		}

		public void AddDriver(Guid id)
		{
			Driver driver = new Driver()
			{
				IsConfirm = false,
				Address = null,
				Avatar = null,
				CarId = null,
				ColorId = null,
				Img = null,
				CarCode = null,
				Tel = null,
				NationalCode = null,
				UserId = id,
			};

			_context.Drivers.Add(driver);
			_context.SaveChanges();
		}

		public void DeleteDriver(Guid id)
		{
			Driver driver = _context.Drivers.Find(id);
			_context.Drivers.Remove(driver);
			_context.SaveChanges();
		}

		public bool UpdateUser(Guid id, UserViewModel viewModel)
		{
			User user = _context.Users.Find(id);
			if (user != null)
			{
				user.RoleId = viewModel.RoleId;
				user.Username = viewModel.Username;
				user.IsActive = viewModel.IsActive;

				return true;
			}

			return false;
		}

		public string GetRoleId(Guid id)
		{
			return _context.Roles.Find(id).Name;
		}

		#endregion
	}
}
