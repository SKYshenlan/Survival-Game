using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QFramework;
using SurvivalGame;

namespace Brotato
{
    public class CoinsUpgradeSystem : AbstractSystem
    {
        public List<CoinsUpgradeItem> Item {  get;} = new List<CoinsUpgradeItem>();
        protected override void OnInit()
        {
            Item.Add(new CoinsUpgradeItem()
            .WithKey("coins_percent")
            .WithDes("提升金币掉落概率")
            .WithPrice(10)
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
        public void Say()
        {

        }
    }
}
