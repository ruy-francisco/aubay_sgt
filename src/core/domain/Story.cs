using System.Collections.Generic;

namespace core.domain
{
    public class Story
    {
        public string by { get; set; }
        public long descendants { get; set; }
        public long id { get; set; }
        public IEnumerable<long> kids { get; set; }
        public long score { get; set; }
        public long time { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }
}
