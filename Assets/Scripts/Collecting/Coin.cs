namespace Collecting
{
    public class Coin : Collectable
    {
        protected override void AddToCollector(Collector collector) => 
            collector.Collect(this);
    }
}