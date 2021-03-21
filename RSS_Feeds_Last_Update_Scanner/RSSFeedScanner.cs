using System;
using System.Collections.Generic;
using System.Text;

namespace RSS_Feeds_Last_Update_Scanner
{
    public interface IRSSFeedScanner 
    {
        public int GetLastUpdateDaysAgo(string url);
    }

    public class RSSFeedScanner:IRSSFeedScanner 
    {
       
        public int GetLastUpdateDaysAgo(string url)
        {


            return 1;
        }


      
    }
}
