using System;
using System.Linq;
using Repository.Mappers;
using Repository.Repositories;
using Xunit;

namespace Testes
{
    public class UnitTest1
    {

        private readonly PlayerRepository _playerRepository;

        public UnitTest1()
        {
            _playerRepository = new PlayerRepository();
            RegisterMappings.Register();
        }
        
        [Fact]
        public async void GetAll()
        {
            try
            {
                var result = await _playerRepository.GetAll();
                Assert.True(result.Any());
            }
            catch (Exception e)
            {
                var erro = e.StackTrace;

            }
        }
    }
}