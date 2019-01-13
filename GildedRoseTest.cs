using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        #region SellIn

        [Test]
        public void SellInValueCanBeNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.NormalItem, SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(-1, Items[0].SellIn);
        }

        [Test]
        public void LowerSellInValueByOneAtTheEndOfTheDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.NormalItem, SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(0, Items[0].SellIn);
        }

        [Test]
        public void LowerSellInValueByNAfterNDays()
        {
            const int daysLeft = 10;
            IList<Item> Items = new List<Item> { new Item { Name = Constants.NormalItem, SellIn = daysLeft, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < daysLeft; i++)
            {
                app.UpdateQuality();

                Assert.AreEqual((daysLeft - i) - 1, Items[0].SellIn);
            }
        }

        #endregion

        #region Quality

        [Test]
        public void QualityValueIsNeverNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.NormalItem, SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(0, Items[0].Quality);
        }

        #region Normal Item

        [Test]
        public void NormalItemLowerQualityValueByOneAtTheEndOfTheDayWhenSellByDateNotYetPassed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.NormalItem, SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void NormalItemLowerQualityValueByNAfterNDaysWhenSellByDateNotYetPassed()
        {
            const int daysLeft = 10;
            IList<Item> Items = new List<Item> { new Item { Name = Constants.NormalItem, SellIn = daysLeft, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < daysLeft; i++)
            {
                app.UpdateQuality();

                Assert.AreEqual(50 - (i + 1), Items[0].Quality);
            }
        }

        [Test]
        public void NormalItemLowerQualityValueByTwoAtTheEndOfTheDayWhenSellByDatePassed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.NormalItem, SellIn = 0, Quality = 2 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void NormalItemLowerQualityValueTwiceFasterAfterNDaysWhenSellByDatePassed()
        {
            const int daysPassed = 10;
            IList<Item> Items = new List<Item> { new Item { Name = Constants.NormalItem, SellIn = 0, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < daysPassed; i++)
            {
                app.UpdateQuality();

                Assert.AreEqual(50 - (i + 1) * 2, Items[0].Quality);
            }
        }

        #endregion

        #region Aged Brie

        [Test]
        public void AgedBrieIncreaseQualityValueByOneAtTheEndOfTheDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.AgedBrieItem, SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(1, Items[0].Quality);
        }

        [Test]
        public void AgedBrieIncreaseQualityValueByNAfterNDays()
        {
            const int daysLeft = 10;
            IList<Item> Items = new List<Item> { new Item { Name = Constants.AgedBrieItem, SellIn = daysLeft, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < daysLeft; i++)
            {
                app.UpdateQuality();

                Assert.AreEqual((i + 1), Items[0].Quality);
            }
        }

        #endregion

        #region Sulfuras, Hand of Ragnaros Item

        [Test]
        public void SulfurasSellInValueNeverChanges()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.SulfurasItem, SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(1, Items[0].SellIn);
        }

        [Test]
        public void SulfurasQualityValueNeverChanges()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.SulfurasItem, SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(1, Items[0].Quality);
        }
        #endregion

        #region Backstage passes to a TAFKAL80ETC concert Item

        [Test]
        public void BackstageIncreaseQualityValueByOneAtTheEndOfTheDayWhenMoreThan10DaysLeft()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.BackstageItem, SellIn = 11, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(1, Items[0].Quality);
        }

        [Test]
        public void BackstageIncreaseQualityValueByNAfterNDaysWhenMoreThan10DaysLeft()
        {
            const int daysLeft = 20;
            IList<Item> Items = new List<Item> { new Item { Name = Constants.BackstageItem, SellIn = daysLeft, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < (daysLeft - 10); i++)
            {
                app.UpdateQuality();

                Assert.AreEqual((i + 1), Items[0].Quality);
            }
        }

        [Test]
        public void BackstageIncreaseQualityValueByTwoAtTheEndOfTheDayWhenLessThan10AndMoreThan5DaysLeft()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.BackstageItem, SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(2, Items[0].Quality);
        }

        [Test]
        public void BackstageIncreaseQualityValueTwiceFasterAfterNDaysWhenLessThan10AndMoreThan5DaysLeft()
        {
            const int daysLeft = 10;
            IList<Item> Items = new List<Item> { new Item { Name = Constants.BackstageItem, SellIn = daysLeft, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < (daysLeft - 5); i++)
            {
                app.UpdateQuality();

                Assert.AreEqual((i + 1) * 2, Items[0].Quality);
            }
        }

        [Test]
        public void BackstageIncreaseQualityValueByThreeAtTheEndOfTheDayWhenLessThan5DaysLeft()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.BackstageItem, SellIn = 5, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(3, Items[0].Quality);
        }

        [Test]
        public void BackstageIncreaseQualityValueThreeTimesFasterAfterNDaysWhenLessThan5DaysLeft()
        {
            const int daysLeft = 5;
            IList<Item> Items = new List<Item> { new Item { Name = Constants.BackstageItem, SellIn = daysLeft, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < daysLeft; i++)
            {
                app.UpdateQuality();

                Assert.AreEqual((i + 1) * 3, Items[0].Quality);
            }
        }

        [Test]
        public void BackstageDropQualityValueToZeroAfterTheConcert()
        {
            IList<Item> Items = new List<Item> { new Item { Name = Constants.BackstageItem, SellIn = 0, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.AreEqual(0, Items[0].Quality);
        }

        #endregion

        #region Conjured Mana Cake - not yet working properly

        //[Test]
        //public void ConjuredItemLowerQualityValueByTwoAtTheEndOfTheDay()
        //{
        //    IList<Item> Items = new List<Item> { new Item { Name = Constants.ConjuredItem, SellIn = 1, Quality = 2 } };
        //    GildedRose app = new GildedRose(Items);
        //    app.UpdateQuality();

        //    Assert.AreEqual(0, Items[0].Quality);
        //}

        //[Test]
        //public void ConjuredItemLowerQualityValueTwiceFasterAfterNDays()
        //{
        //    const int daysLeft = 10;
        //    IList<Item> Items = new List<Item> { new Item { Name = Constants.ConjuredItem, SellIn = daysLeft, Quality = 50 } };
        //    GildedRose app = new GildedRose(Items);

        //    for (int i = 0; i < daysLeft; i++)
        //    {
        //        app.UpdateQuality();

        //        Assert.AreEqual(50 - (i + 1) * 2, Items[0].Quality);
        //    }
        //}

        #endregion

        [Test]
        public void QualityIsNeverMoreThan50()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = Constants.AgedBrieItem, SellIn = 1, Quality = 50 },
                new Item { Name = Constants.BackstageItem, SellIn = 10, Quality = 49 },
                new Item { Name = Constants.BackstageItem, SellIn = 5, Quality = 49 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(50, Items[0].Quality);
            Assert.AreEqual(50, Items[1].Quality);
            Assert.AreEqual(50, Items[2].Quality);
        }

        #endregion
    }
}
