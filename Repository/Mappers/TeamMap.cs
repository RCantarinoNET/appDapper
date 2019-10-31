using Dapper.FluentMap.Mapping;

namespace Repository.Mappers
{
    public class TeamMap : EntityMap<Domain.Entities.Team>
    {

        public TeamMap()
        {
            Map(x => x.Id).ToColumn("ID");
            Map(x => x.Name).ToColumn("NM_TIME");
        }
    }
}