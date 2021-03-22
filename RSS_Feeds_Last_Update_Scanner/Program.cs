using System;
using System.Collections.Generic;
using System.Linq;

namespace RSS_Feeds_Last_Update_Scanner
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = 10;

            List<string> companies = GetCompaniesWithNoActivityFor(days);
            
            Console.Read();

        }

        static List <string> GetCompaniesWithNoActivityFor(int days)
        {
            
            var scanner = new RSSFeedScanner();

            //the given Dictionary of RSS Feed URLs by company name is encapsulated in Storage ;
            var given = new Storage();

            return given.FeedURLsByCompany.Where(
                                                    co =>
                                                    co.Value //Value is the list of RSS urls for company co
                                                            .Select(    url     => scanner.GetDaysAgoLastPost(url))//select last update days ago
                                                            .OrderBy(   days    => days)                             //asc order - recent update first  
                                                            .FirstOrDefault() > days                                 //qualifier - most recent update > days
                                                 )
                                            .Select(co => co.Key) 
                                            .ToList(); 
                         
        }



    }
}
