using Blog.Data.Entity;

namespace Blog.Business.Services.Abstract
{
	public interface ISettingService
	{
		List<SettingDto> GetAll();
		SettingDto GetById(int id);
		void Insert(SettingDto setting);
		void Update(SettingDto setting);
		void DeleteById(int id);
	}
}
