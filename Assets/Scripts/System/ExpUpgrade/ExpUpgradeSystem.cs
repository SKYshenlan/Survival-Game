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
                        2 => $"剑Lv{lv}:攻击+3 数量+2",
                        3 => $"剑Lv{lv}:攻击+2 间隔-0.25s",
                        4 => $"剑Lv{lv}:攻击+2 间隔-0.25s",
                        5 => $"剑Lv{lv}:攻击+3 数量+2",
                        6 => $"剑Lv{lv}:范围+1 间隔-0.25s",
                        7 => $"剑Lv{lv}:攻击+3 数量+2",
                        8 => $"剑Lv{lv}:攻击+2 范围+1",
                        9 => $"剑Lv{lv}:攻击+3 间隔-0.25s",
                        10 => $"剑Lv{lv}:攻击+3 数量+2",
                        _ =>null
                    };
                })
                .WithMax(10)
                .OnUpgrade((_, leve) =>
                {
                    switch (leve)
                    {
                        case 1:
                            Global.AtkeUnlocked.Value = true;
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
            Add(new ExpUpgradeItem()
                .WithKey("simple_Kinf")
                .WithDes(lv =>
                {
                    return lv switch
                    {
                        1 => $"飞刀Lv{lv}:向最近的敌人发射一把飞刀",
                        2 => $"飞刀Lv{lv}:攻击+3 数量+2",
                        3 => $"飞刀Lv{lv}:攻击+1 间隔-0.1s 数量+1",
                        4 => $"飞刀Lv{lv}:穿透+1 间隔-0.1s 数量+1",
                        5 => $"飞刀Lv{lv}:攻击+3 数量+1",
                        6 => $"飞刀Lv{lv}:数量+1 间隔-0.1s",
                        7 => $"飞刀Lv{lv}:穿透+1 间隔-0.1s",
                        8 => $"飞刀Lv{lv}:穿透+1 间隔-0.1s 数量+1",
                        9 => $"飞刀Lv{lv}:攻击+3 间隔-0.1s",
                        10 => $"飞刀Lv{lv}:攻击+3 数量+2",
                        _ => null
                    };
                })
                .WithMax(10)
                .OnUpgrade((_, leve) =>
                {
                    switch (leve)
                    {
                        case 1:
                            Global.KinfeUnlocked.Value = true;
                            break;
                        case 2:
                            Global.KinfAtk.Value += 3;
                            Global.KinfAtkCout.Value += 2;
                            break;
                        case 3:
                            Global.KinfAtk.Value += 1;
                            Global.KinfAtkSpeed.Value -= 0.1f;
                            Global.KinfAtkCout.Value += 1;
                            break;
                        case 4:
                            Global.KinfPenetration.Value += 1;
                            Global.KinfAtkCout.Value += 1;
                            Global.AtkSpeed.Value -= 0.1f;
                            break;
                        case 5:
                            Global.KinfAtk.Value += 3;
                            Global.KinfAtkCout.Value += 1;
                            break;
                        case 6:
                            Global.KinfAtkCout.Value += 1;
                            Global.KinfAtkSpeed.Value -= 0.1f;
                            break;
                        case 7:
                            Global.KinfPenetration.Value += 1;
                            Global.KinfAtkSpeed.Value -= 0.1f;
                            break;
                        case 8:
                            Global.KinfPenetration.Value += 1;
                            Global.KinfAtkSpeed.Value -= 0.1f;
                            Global.KinfAtkCout.Value += 1;
                            break;
                        case 9:
                            Global.KinfAtk.Value += 3;
                            Global.KinfAtkSpeed.Value -= 0.1f;
                            break;
                        case 10:
                            Global.KinfAtk.Value += 3;
                            Global.KinfAtkCout.Value += 2;
                            break;
                    }
                }));
            Add(new ExpUpgradeItem()
                .WithKey("Rotatte_Sword")
                .WithDes(lv =>
                {
                    return lv switch
                    {
                        1 => $"守卫剑Lv{lv}:环绕身边的剑",
                        2 => $"守卫剑Lv{lv}:数量+1 攻击+1",
                        3 => $"守卫剑Lv{lv}:攻击+2 速度+25%",
                        4 => $"守卫剑Lv{lv}:速度+50%",
                        5 => $"守卫剑Lv{lv}:数量+1 攻击+1",
                        6 => $"守卫剑Lv{lv}:攻击+2 速度+25%",
                        7 => $"守卫剑Lv{lv}:数量+1 攻击+1",
                        8 => $"守卫剑Lv{lv}:攻击+2 速度+25%",
                        9 => $"守卫剑Lv{lv}:数量+1 攻击+1",
                        10 => $"守卫剑Lv{lv}:攻击+2 速度+25%",
                        _ => null
                    };
                })
                .WithMax(10)
                .OnUpgrade((_, leve) =>
                {
                    switch (leve)
                    {
                        case 1:
                            Global.RotatteSwordeUnlocked.Value = true;
                            break;
                        case 2:
                            Global.RotatteSwordCount.Value += 1;
                            Global.RotatteSwordAtk.Value += 1;
                            break;
                        case 3:
                            Global.RotatteSwordAtk.Value += 2;
                            Global.RotatteSwordSpeed.Value *= 1.25f;
                            break;
                        case 4:
                            Global.RotatteSwordSpeed.Value *= 1.50f;
                            break;
                        case 5:
                            Global.RotatteSwordCount.Value += 1;
                            Global.RotatteSwordAtk.Value += 1;
                            break;
                        case 6:
                            Global.RotatteSwordAtk.Value += 2;
                            Global.RotatteSwordSpeed.Value *= 1.25f;
                            break;
                        case 7:
                            Global.RotatteSwordCount.Value += 1;
                            Global.RotatteSwordAtk.Value += 1;
                            break;
                        case 8:
                            Global.RotatteSwordAtk.Value += 2;
                            Global.RotatteSwordSpeed.Value *= 1.25f;
                            break;
                        case 9:
                            Global.RotatteSwordCount.Value += 1;
                            Global.RotatteSwordAtk.Value += 1;
                            break;
                        case 10:
                            Global.RotatteSwordAtk.Value += 2;
                            Global.RotatteSwordSpeed.Value *= 1.25f;
                            break;
                    }
                }));
            Add(new ExpUpgradeItem()
                .WithKey("basket_ball")
                .WithDes(lv =>
                {
                    return lv switch
                    {
                        1 => $"篮球Lv{lv}:拥有弹性的篮球",
                        2 => $"篮球Lv{lv}:攻击+3",
                        3 => $"篮球Lv{lv}:数量+1",
                        4 => $"篮球Lv{lv}:攻击+3",
                        5 => $"篮球Lv{lv}:数量+1",
                        6 => $"篮球Lv{lv}:攻击+3",
                        7 => $"篮球Lv{lv}:速度+20%",
                        8 => $"篮球Lv{lv}:攻击+3",
                        9 => $"篮球Lv{lv}:速度+20%",
                        10 => $"篮球Lv{lv}:数量+1",
                        _ => null
                    };
                })
                .WithMax(10)
                .OnUpgrade((_, leve) =>
                {
                    switch (leve)
                    {
                        case 1:
                            Global.BasketBalleUnlocked.Value = true;
                            break;
                        case 2:
                            Global.BasketBallAtk.Value += 3;
                            break;
                        case 3:
                            Global.BasketBallCount.Value += 1;
                            break;
                        case 4:
                            Global.BasketBallAtk.Value += 3;
                            break;
                        case 5:
                            Global.BasketBallCount.Value += 1;
                            break;
                        case 6:
                            Global.BasketBallAtk.Value += 3;
                            break;
                        case 7:
                            Global.BasketBallSpeed.Value *= 1.2f;
                            break;
                        case 8:
                            Global.BasketBallAtk.Value += 3;
                            break;
                        case 9:
                            Global.BasketBallSpeed.Value *= 1.2f;
                            break;
                        case 10:
                            Global.BasketBallCount.Value += 1;
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
            foreach (var item in Item.Where(item => !item.UpgradeFinish).Take(4))
            {
                if (item == null)
                {

                }
                else
                {
                    item.Visible.Value = true;
                }
            }
            
        }
    }
}
