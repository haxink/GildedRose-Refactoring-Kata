namespace csharp.Handler
{
    public abstract class IHandler
    {
        public abstract void UpdateQuality(Item item);

        protected void LowerQualityValueByOne(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
        protected void IncreaseQualityValueByOne(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }

    public class NormalItemHandler : IHandler
    {
        public override void UpdateQuality(Item item)
        {
            this.LowerQualityValueByOne(item);

            item.SellIn--;

            if (item.SellIn < 0)
            {
                this.LowerQualityValueByOne(item);
            }
        }
    }

    public class AgedBrieItemHandler : IHandler
    {
        public override void UpdateQuality(Item item)
        {
            this.IncreaseQualityValueByOne(item);

            item.SellIn--;

            if (item.SellIn < 0)
            {
                this.IncreaseQualityValueByOne(item);
            }
        }
    }

    public class SulfurasHandler : IHandler
    {
        public override void UpdateQuality(Item item) { }
    }

    public class BackstageHandler : IHandler
    {
        public override void UpdateQuality(Item item)
        {
            this.IncreaseQualityValueByOne(item);

            if (item.SellIn < 11)
            {
                this.IncreaseQualityValueByOne(item);
            }

            if (item.SellIn < 6)
            {
                this.IncreaseQualityValueByOne(item);
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }

    public class ConjuredHandler : IHandler
    {
        public override void UpdateQuality(Item item) { }
    }
}
