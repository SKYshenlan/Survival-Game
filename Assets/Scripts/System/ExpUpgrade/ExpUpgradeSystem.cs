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
    /// <summary>
    /// 局内升级系统
    /// </summary>
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
            ResetData();
            Global.Leve.Register(lv =>
            {
                Roll();
            });
        }
        public void ResetData()
        {
            Item.Clear();

            Add(new ExpUpgradeItem()
                .WithKey("simple_sword")
                .WithDes(lv =>
                {
                    return lv switch
                    {
                        1 => $"剑Lv{lv}:攻击身边的敌人",
                        2 => $"剑Lv{lv}:攻击力+3 数量+2",
                        3 => $"剑Lv{lv}:攻击力+2 间隔-0.25s",
                        4 => $"剑Lv{lv}:攻击力+2 间隔-0.25s",
                        5 => $"剑Lv{lv}:攻击力+3 数量+2",
                        6 => $"剑Lv{lv}:范围+1 间隔-0.25s",
                        7 => $"剑Lv{lv}:攻击力+3 数量+2",
                        8 => $"剑Lv{lv}:攻击力+2 范围+1",
                        9 => $"剑Lv{lv}:攻击力+3 间隔-0.25s",
                        10 => $"剑Lv{lv}:攻击力+3 数量+2",
                        _ =>null
                    };
                })
                .WithMax(10)
                .OnUpgrade((_, leve) =>
                {
                    switch (leve)
                    {
                        case 1:
                            break;
                        case 2:
                            Global.Atk.Value += 3;
                            Global.AtkCount.Value += 2;
                            break;
                        case 3:
                            Global.Atk.Value += 2;
                            Global.AtkSpeed.Value-= 0.25f;
                            break;
                        case 4:
                            Global.Atk.Value += 2;
                            Global.AtkSpeed.Value -= 0.25f;
                            break;
                        case 5:
                            Global.Atk.Value += 3;
                            Global.AtkCount.Value += 2;
                            break;
                        case 6:
                            Global.AtkRamge.Value += 1;
                            Global.AtkSpeed.Value -= 0.25f;
                            break;
                        case 7:
                            Global.Atk.Value += 3;
                            Global.AtkCount.Value += 2;
                            break;
                        case 8:
                            Global.Atk.Value += 2;
                            Global.AtkRamge.Value += 1;
                            break;
                        case 9:
                            Global.Atk.Value += 3;
                            Global.AtkSpeed.Value -= 0.25f;
                            break;
                        case 10:
                            Global.Atk.Value += 3;
                            Global.AtkCount.Value += 2;
                            break;
                    }
                }));
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
