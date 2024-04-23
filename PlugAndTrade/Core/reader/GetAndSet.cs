namespace PlugAndTrade.Core.reader
{
    public class GetAndSet
    {
        public string id { get; set; }
        public bool sellable { get; set; }
        public bool visible { get; set; }
        public NetContent ?netContent { get; set; }
    }

    public class NetContent
    {
        public double unitOfMeasure { get; set; }
        public double value { get; set; }
    }

}
