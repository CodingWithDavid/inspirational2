public class Quote
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public static async Task<Quote> Get(List<Quote> data)
    {
        Quote result = new();

        if (data.Any())
        {
            Random r = new();
            int index = r.Next(1, data.Count);
            try
            {
                var t = from a in data
                        where a.Id == index
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
            if (string.IsNullOrEmpty(result.Author))
            {
                result.Author = "Unknown";
            }
        }
        await Task.CompletedTask;
        return result;
    }
}