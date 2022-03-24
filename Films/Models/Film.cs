using System;
using System.Collections.Generic;

namespace Films.Models
{
    public partial class Film
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? Date { get; set; }
        public int? IdCreator { get; set; }
        public int? IdPoster { get; set; }
        public int? IdUser { get; set; }

        public virtual Creator? IdCreatorNavigation { get; set; }
        public virtual Poster? IdPosterNavigation { get; set; }
        public virtual User? IdUserNavigation { get; set; }
    }
}
