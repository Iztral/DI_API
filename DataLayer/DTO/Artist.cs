using System.Collections.Generic;

namespace DataLayer.DTO
{
    public class Artist : BaseModel
    {
        public string Name { get; set; }

        public IEnumerable<Track> Tracks { get; set; }
    }
}