using Dapper.FluentMap.Mapping;

namespace Repository.Mappers
{
    public class PlayerMap : EntityMap<Domain.Entities.Player>
    {
        public PlayerMap()
        {
            Map(x => x.Id).ToColumn("ID");
            Map(x => x.Age).ToColumn("NR_IDADE");
            Map(x => x.Name).ToColumn("NM_JOGADOR");
            Map(x => x.TeamId).ToColumn("ID_TIME");
            Map(x => x.Team).Ignore();
        }
    }
}


