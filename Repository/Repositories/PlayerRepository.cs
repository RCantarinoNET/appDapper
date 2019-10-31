using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Domain.Entities;
using Dommel;

namespace Repository.Repositories
{
    public class PlayerRepository : Base.RepositoryBase<Player>
    {
        private readonly string _conexString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Dapper_DB;Integrated Security=True";
        public override async Task<IEnumerable<Player>> GetAll()
        {
            await using var db = new SqlConnection(_conexString);
            return db.GetAll<Player, Team, Player>((player, team) =>
            {
                player.Team = team;
                return player;
            });
        }
    }
}