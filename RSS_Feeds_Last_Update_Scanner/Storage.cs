using System;
using System.Collections.Generic;
using System.Text;

namespace RSS_Feeds_Last_Update_Scanner
{
    class Storage
    {
        public Dictionary<string, List<string>> FeedURLsByCompany { get; set; }

        public Storage()
        {
            FeedURLsByCompany = new Dictionary<string, List<string>>
            {
                { "The Apology Line",                new List<string>{"https://rss.art19.com/apology-line" }        },
                { "The Daily by The New York Times", new List<string>{"http://rss.art19.com/the-daily", ""}         },
                { "The Bible in a Year",             new List<string>{"https://feeds.fireside.fm/bibleinayear/rss"} },
                { "Crime Junkie",                    new List<string>{"https://feeds.megaphone.fm/ADL9840290619" }  },
        
            };

        }

     
    }
}
