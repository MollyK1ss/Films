using System;
using System.Collections.Generic;

namespace Films.Models
{
    public partial class Creator
    {
        public Creator()
        {
            Films = new HashSet<Film>();
        }

        public int Id { get; set; }
        public string Fio { get; set; } = null!;

        public virtual ICollection<Film> Films { get; set; }
    }
}
