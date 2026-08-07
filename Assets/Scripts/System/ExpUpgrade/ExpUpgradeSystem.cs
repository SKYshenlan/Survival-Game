using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QFramework;
using SurvivalGame;
using UnityEngine;

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
            var atkLv1 = Add(new ExpUpgradeItem()
                .WithKey("atk_damage_lv1")
                .WithDes("小幅度提升伤害Lv1")
                .WithMax(10)
                .OnUpgrade((_,leve)=>
                {
                    if (leve == 1)
                    {

                    }
                    //记录当前等级攻击力
                    float _atk = Global.Atk.Value;
                    //提升15%的攻击
                    Global.Atk.Value += _atk * 0.15f;
                })
            );
            
            var atkSpeedLv1 = Add(new ExpUpgradeItem()
                .WithKey("atk_speed_lv1")
                .WithDes("提升攻击速度Lv1")
                .WithMax(10)
                .OnUpgrade((_, leve) =>
                {
                    if(leve == 2)
                    {

                    }
                    //记录当前等级攻击速度
                    float _atk = Global.AtkSpeed.Value;
                    //提升5%的攻击速度
                    Global.AtkSpeed.Value += _atk * 0.05f;
                })
            );
            Roll();

        }
        public void Roll()
        {
            foreach (var item1 in Item)
            {
                item1.Visible.Value = false;
            }
            var item = Item.Where(item => !item.UpgradeFinish).ToList().GetRandomItem();
            if(item == null)
            {

            }
            else
            {
                item.Visible.Value = true;
            }
        }
    }
}
