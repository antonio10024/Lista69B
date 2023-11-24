using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Domain
{
    public class FoundWatchList
    {
        public int Id { get; set; }
        public Guid WatchListId { get; set; }
        public int List69BId { get; set; }
        public WatchListSweep WatchListSweep { get; set; }
        public int WatchListSweepId { get; set; }
    }
}
