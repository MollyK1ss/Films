using System;
using System.Collections.Generic;

namespace Films.Models
{
    public partial class Poster
    {
        public Poster()
        {
            Films = new HashSet<Film>();
        }

        public int Id { get; set; }
        public string Path { get; set; } = null!;

        public virtual ICollection<Film> Films { get; set; }
    }
}
