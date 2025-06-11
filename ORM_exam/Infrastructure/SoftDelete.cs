using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public enum State
    {
        InDB,
        Deleted
    }

    public class SoftDelete
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateDeleted { get; set; } = DateTime.Now;

        public string EntityState { get; set; }
    }
}
