public class Assortment
{

    public static Task<string> readAssortment()
    {
        IList<string> list = new List<string>();
        DirectoryInfo pricing = new DirectoryInfo("C:\\Users\\pontande123\\source\\repos\\plugAndTrade\\PlugAndTrade\\PlugAndTrade\\data\\Availabilities\\");
        foreach (FileInfo f in pricing.GetFiles())
        {
            string filename = f.FullName;
            string jsonString = File.ReadAllText(filename);
            GetAndSet getAndSet = JsonSerializer.Deserialize<GetAndSet>(jsonString);
            var id = getAndSet.id;
            list.Add(id);
        }
        return (Task<string>)list;
    }
}
