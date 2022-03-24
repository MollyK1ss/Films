using System;
using System.Collections.Generic;

namespace Films.Models
{
    public partial class User
    {
        public User()
        {
            Films = new HashSet<Film>();
        }

        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Pass { get; set; } = null!;

        public virtual ICollection<Film> Films { get; set; }
    }
}
