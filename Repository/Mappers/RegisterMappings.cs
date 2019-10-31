using System;
using Dapper.Contrib.Extensions;
using Dapper.FluentMap;
using Domain.Entities;

namespace Repository.Mappers
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(cfg =>
            {
                cfg.AddMap(new PlayerMap());
                cfg.AddMap(new TeamMap());

            });
        }

    }
}