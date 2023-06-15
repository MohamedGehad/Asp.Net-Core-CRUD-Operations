using AutoMapper;
using DataAccessLayer.Models;
using PrestionLayer.ViewModels;

namespace PrestionLayer.MaplingProfile
{
	public class EmployeeProfile : Profile
	{
		public EmployeeProfile() {
			CreateMap<EmployeeViewModel, Employee>().
					ForMember(d => d.Name, o => o.MapFrom(s => s.Name)).ReverseMap();
		}
	}
}
 