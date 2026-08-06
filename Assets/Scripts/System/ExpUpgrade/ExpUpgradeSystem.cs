using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QFramework;
using SurvivalGame;

namespace Brotato
{
    internal class ExpUpgradeSystem : AbstractSystem
    {
        public List<ExpUpgradeItem> Item { get; } = new List<ExpUpgradeItem>();
        public ExpUpgradeItem Add(ExpUpgradeItem item)
        {
            Item.Add(item);
            return item;
        }
        protected override void OnInit()
        {
            Add(new ExpUpgradeItem()
                .WithKey("atk_damage_lv1")
                .WithDes("小幅度提升伤害Lv1")
                .OnUpgrade(_ =>
                {
                    //记录当前等级攻击力
                    float _atk = Global.Atk.Value;
                    //提升15%的攻击
                    Global.Atk.Value += _atk * 0.15f;
                })
            );
        }
    }
}
