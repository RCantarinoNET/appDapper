using Dapper.Contrib.Extensions;

namespace Domain.Entities
{
    [Table ("TB_TIME")]
    public class Team : BaseEntity
    {
        public string Name { get; set; }
    }
}