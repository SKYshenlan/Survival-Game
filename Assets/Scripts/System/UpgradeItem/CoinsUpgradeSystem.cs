using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QFramework;
using SurvivalGame;
using Unity.Burst.Intrinsics;

namespace Brotato
{
    public class CoinsUpgradeSystem : AbstractSystem
    {
        public List<CoinsUpgradeItem> Item {  get;} = new List<CoinsUpgradeItem>();
        public static EasyEvent OnCoinsUpgradeSystemChanged = new EasyEvent();
        public CoinsUpgradeItem Add(CoinsUpgradeItem item)
        {
            Item.Add(item);
            return item;
        }
        protected override void OnInit()
        {
            var arrLv1 = Add(new CoinsUpgradeItem()
            .WithKey("coins_percent_Lv1")
            .WithDes("提升金币掉落Lv1")
            .WithPrice(10)
            .OnUpgrade((Item) =>
            {
                Global.Coins.Value -= Item.Price;
                //增加金币概率
                Global.CoinsPercent.Value += 0.05f;
            }));
            var arrLv2 = Add(new CoinsUpgradeItem()
            .WithKey("coins_percent_Lv2")
            .WithDes("提升金币掉落Lv2")
            .WithPrice(10)
            .Condtion((_) => arrLv1.UpgradeFinish)
            .OnUpgrade((Item) =>
            {
                Global.Coins.Value -= Item.Price;
                //增加金币概率
                Global.CoinsPercent.Value += 0.05f;
            }));
            var arrLv3 = Add(new CoinsUpgradeItem()
            .WithKey("coins_percent_Lv3")
            .WithDes("提升金币掉落Lv3")
            .WithPrice(10)
            .Condtion((_) => arrLv2.UpgradeFinish)
            .OnUpgrade((Item) =>
            {
                Global.Coins.Value -= Item.Price;
                //增加金币概率
                Global.CoinsPercent.Value += 0.05f;
            }));
            Item.Add(new CoinsUpgradeItem()
            .WithKey("exp_percent")
            .WithDes("提升经验掉落概率")
            .WithPrice(5)
            .OnUpgrade((Item) =>
            {
                Global.Coins.Value -= Item.Price;
                //增加经验概率
                Global.ExpPercent.Value += 0.05f;
            }));
            Item.Add(new CoinsUpgradeItem()
            .WithKey("hp_percent")
            .WithDes("提升血包掉落概率")
            .WithPrice(11)
            .OnUpgrade((Item) =>
            {
                Global.Coins.Value -= Item.Price;
                //增加血包概率
                Global.HpPercent.Value += 0.05f;
            }));
        }
    }
}
