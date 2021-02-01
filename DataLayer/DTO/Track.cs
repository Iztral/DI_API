﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DTO
{
    public class Track : BaseModel
    {
        public string Name { get; set; }

        [ForeignKey("Artist")]
        public int ArtistID { get; set; }

        public Artist Artist { get; set; }
    }
}
