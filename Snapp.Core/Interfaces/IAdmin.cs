using Snapp.Core.ViewModels.Admin;
using Snapp.DataAccessLayer.Entities;

namespace Snapp.Core.Interfaces
{
	public interface IAdmin : IDisposable
	{
		#region Car

		Task<List<Car>> GetCars();

		Task<Car> GetCarById(Guid id);

		void AddCar(CarViewModel viewModel);

		bool UpdateCar(Guid id, CarViewModel viewModel);

		void DeleteCar(Guid id);

		#endregion

		#region Color

		Task<List<Color>> GetColors();

		Task<Color> GetColorsById(Guid id);

		void AddColor(ColorViewModel viewModel);

		bool UpdateColor(Guid id, ColorViewModel viewModel);

		void DeleteColor(Guid id);

		#endregion

		#region RateType

		Task<List<RateType>> GetRateTypes();

		Task<RateType> GetRateTypesById(Guid id);

		void AddRateType(RateTypeViewModel viewModel);

		bool UpdateRateType(Guid id, RateTypeViewModel viewModel);

		void DeleteRateType(Guid id);

		#endregion

		#region Setting

		Task<Setting> GetSetting();

		bool UpdateSiteSetting(SiteSettingViewModel viewModel);
		bool UpdatePriceSetting(PriceSettingViewModel viewModel);
		bool UpdateAboutSetting(AboutSettingViewModel viewModel);
		bool UpdateTermsSetting(TermsSettingViewModel viewModel);

		#endregion

		#region PriceType

		Task<List<PriceType>> GetPriceTypes();

		Task<PriceType> GetPriceTypesById(Guid id);

		void AddPriceType(PriceTypeViewModel viewModel);

		bool UpdatePriceType(Guid id, PriceTypeViewModel viewModel);

		void DeletePriceType(Guid id);

		#endregion

        #region MonthType

        Task<List<MonthType>> GetMonthTypes();

        Task<MonthType> GetMonthTypesById(Guid id);

        void AddMonthType(MonthTypeViewModel viewModel);

        bool UpdateMonthType(Guid id, MonthTypeViewModel viewModel);

        void DeleteMonthType(Guid id);

		#endregion

		#region Humidity

		Task<List<Humidity>> GetHumidities();

		Task<Humidity> GetHumiditiesById(Guid id);

		void AddHumidity(MonthTypeViewModel viewModel);

		bool UpdateHumidity(Guid id, MonthTypeViewModel viewModel);

		void DeleteHumidity(Guid id);

		#endregion

		#region Temprature

		Task<List<Temperature>> GetTemperatures();

		Task<Temperature> GetTemperaturesById(Guid id);

		void AddTemperature(MonthTypeViewModel viewModel);

		bool UpdateTemperature(Guid id, MonthTypeViewModel viewModel);

		void DeleteTemperature(Guid id);

		#endregion
	}
}
