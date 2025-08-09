namespace Collecting
{
    public class Apple : Collectable
    {
        protected override void AddToCollector(Collector collector) => 
            collector.Collect(this);
    }
}