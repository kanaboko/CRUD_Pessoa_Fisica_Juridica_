﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}