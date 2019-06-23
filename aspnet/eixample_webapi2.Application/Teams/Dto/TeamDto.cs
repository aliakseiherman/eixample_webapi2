using System;

namespace eixample_webapi2.Dto
{
    public class TeamDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
