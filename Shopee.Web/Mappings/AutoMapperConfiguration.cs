﻿using AutoMapper;
using Shopee.Model.Models;
using Shopee.Web.Models;

namespace Shopee.Web.Mappings
{
        public class AutoMapperConfiguration
        {
            public static void Configure()
            {

                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Post, PostViewModel>();
                    cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                    cfg.CreateMap<Tag, TagViewModel>();
                    cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                    cfg.CreateMap<Product, ProductViewModel>();
                    cfg.CreateMap<ProductTag, ProductTagViewModel>();
                });
            }

        }
    }