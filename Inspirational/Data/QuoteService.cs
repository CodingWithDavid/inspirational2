
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inspirational
{
    public static class QuoteService
    {
        public static async Task<Quote> Get(List<Quote> data)
        {
            Quote result = new Quote();

            if (data.Any())
            {
                Random r = new Random();
                int index = r.Next(1, data.Count - 1);
                try
                {
                    var t = from a in data
                            where a.id == index
                            select a;
                    if (t.Any())
                    {
                        result = t.FirstOrDefault()!;
                    }
                }
                catch
                {
                    result = data.ElementAt(0);
                }
                //always make sure there is a value for author
                if (string.IsNullOrEmpty(result.author))
                {
                    result.author = "Unknown";
                }
            }
            await Task.CompletedTask;
            return result;
        }
    }
}
