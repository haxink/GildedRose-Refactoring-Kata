using csharp.Handler;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                IHandler handler;

                if (Items[i].Name == Constants.AgedBrieItem)
                {
                    handler = new AgedBrieItemHandler();
                }
                else if (Items[i].Name == Constants.SulfurasItem)
                {
                    handler = new SulfurasHandler();
                }
                else if (Items[i].Name == Constants.BackstageItem)
                {
                    handler = new BackstageHandler();
                }
                else if (Items[i].Name == Constants.ConjuredItem)
                {
                    handler = new ConjuredHandler();
                }
                else
                {
                    handler = new NormalItemHandler();
                }

                handler.UpdateQuality(Items[i]);
            }
        }
    }
}
