using AutoMapper;
using eShop.DataBaseRepository.Db.Models;
using eShop.DataTransferObject.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductDTO, ProductModel>();
            CreateMap<ProductModel, ProductDTO>();

            CreateMap<ProductDetailsDTO, ProductDetailsModel>();
        }

    }
}

