using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
//using System.Threading.Tasks;

namespace RSS_Feeds_Last_Update_Scanner
{
    public interface IRSSFeedScanner 
    {
        public int GetDaysAgoLastPost(string url);
    }

    public class RSSFeedScanner:IRSSFeedScanner 
    {
       
        public int GetDaysAgoLastPost(string url)
        {
       
            var reader = XmlReader.Create(url);
            
            var feed = SyndicationFeed.Load(reader);

            reader.Close();
            //using PublishDate property of RSS feed post (item) to determine the last activity date
            int daysAgo = feed.Items.OrderByDescending(item => item.PublishDate)                                       //order by date  recent first
                                 .Take(1)                                                                           //take most recent post
                                 .Select(item => GetOffsetInDaysNow(item.PublishDate.UtcDateTime)).FirstOrDefault();   //select Diff between now and PublishDate

            return daysAgo;

        }

        private int GetOffsetInDaysNow(DateTime utcDateTime)
        {
            //Diff between now and PublishDate in days

            var diff  =   DateTimeOffset.UtcNow - utcDateTime;

            return diff.Days;
        }

       



    }
}
