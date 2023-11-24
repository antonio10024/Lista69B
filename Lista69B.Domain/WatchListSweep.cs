using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Domain
{
    public class WatchListSweep
    {
        public WatchListSweep()
        {
            this.ExecutionDate = DateTime.UtcNow;
            this.Founds = new List<FoundWatchList>();
        }

        public void add(FoundWatchList item)
        {
            if (item is null)
            {
                throw new ArgumentNullException();
            }
            this.Founds.Add(item);
        }
        public int Id { get; private set; }
        public DateTime ExecutionDate { get; private set; }
        public List<FoundWatchList> Founds { get; private set; }

    }

    
}
