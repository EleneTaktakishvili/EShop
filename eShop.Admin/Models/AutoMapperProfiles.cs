using AutoMapper;
using eShop.DataTransferObject.DTOModels;

namespace eShop.Admin.Models
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CategoryDTO, CategoryModel>();
            CreateMap<CategoryModel, CategoryDTO>();
            CreateMap<OrderDTO, OrderModel>();
            CreateMap<RoleDTO, RoleModel>();
            CreateMap<RoleModel, RoleDTO>();
            CreateMap<UserDTO, UserModel>();
            CreateMap<ProductDTO, ProductModel>();
            CreateMap<OrdeDetailsDTO, OrdeDetailsModel>();
            CreateMap<OrdeDetailsModel, OrdeDetailsDTO>();
        }

    }
}
