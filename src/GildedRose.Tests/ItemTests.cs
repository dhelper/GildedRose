using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void UpdateQuality_QualityBiggerThan0_QualityDecreased()
        {
            var item = new Item { Quality = 1 };

            item.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void UpdateQuality_SellInBiggerThan0_SellInDecreased()
        {
            var item = new Item { SellIn = 1 };

            item.UpdateQuality();

            Assert.That(item.SellIn, Is.EqualTo(0));
        }

        [Test]
        public void UpdateQuality_QualityEquals0_QualityCannotBeNegative()
        {
            var item = new Item { Quality = 0 };

            item.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void UpdateQuality_SellInPassed_QualityDcreaseBy2()
        {
            var item = new Item { SellIn = 0, Quality = 2 };

            item.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void UpdateQuality_AgedBree_QualityIncreasedBy1DcreaseBy2()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 };

            item.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(2));
        }

        [Test]
        public void UpdateQuality_AgedBreeWithQualityOf50_QualityNeverIncreaseAbove50()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 };

            item.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(50));
        }

        [Test]
        public void UpdateQuality_AgedBree_SellInDecreases()
        {
            var item = new Item { Name = "Aged Brie", Quality = 1, SellIn = 1 };

            item.UpdateQuality();

            Assert.That(item.SellIn, Is.EqualTo(0));
        }

        [Test]
        public void UpdateQuality_AgedBreeSellInIsZero_QualityIncreaseByTwo()
        {
            var item = new Item { Name = "Aged Brie", Quality = 1, SellIn = 0 };

            item.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(3));
        }

        [Test]
        public void UpdateQuality_LegendatyItem_QualityNeveralDecreased()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 1 };

            item.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(1));
        }

        [Test]
        public void UpdateQuality_LegendatyItem_SellInNeveralDecreased()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 1 };

            item.UpdateQuality();

            Assert.That(item.SellIn, Is.EqualTo(1));
        }

        [Test]
        public void UpdateQuality_EventItem_QualityShouldIncrease()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 11 };

            item.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(2));
        }

        [TestCase(10)]
        [TestCase(9)]
        [TestCase(8)]
        [TestCase(7)]
        [TestCase(6)]
        public void UpdateQuality_EventItemTenOrLessDaysTillEvent_IncreaseQualityBy(int daysLeft)
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = daysLeft };

            item.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(3));
        }

        [TestCase(5)]
        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void UpdateQuality_EventItemFiveDaysOrLessReamins_IncreaseQualityByThree(int daysLeft)
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = daysLeft };

            item.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(4));
        }

        [Test]
        public void UpdateQuality_EventItemSellInPassed_QualityIsZero()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 0 };

            item.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void UpdateQuality_EventItem_SellInDecrementNormally()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 1, SellIn = 1 };

            item.UpdateQuality();

            Assert.That(item.SellIn, Is.EqualTo(0));
        }
    }
}