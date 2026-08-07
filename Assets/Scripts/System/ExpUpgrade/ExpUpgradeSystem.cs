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
            var atkLv1 = Add(new ExpUpgradeItem()
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
            var atkLv2 = Add(new ExpUpgradeItem()
                .WithKey("atk_damage_lv2")
                .WithDes("小幅度提升伤害Lv2")
                .Condtion(_=> atkLv1.UpgradeFinish)
                .OnUpgrade(_ =>
                {
                    //记录当前等级攻击力
                    float _atk = Global.Atk.Value;
                    //提升15%的攻击
                    Global.Atk.Value += _atk * 0.15f;
                })
            );
            var atkLv3 = Add(new ExpUpgradeItem()
                .WithKey("atk_damage_lv3")
                .WithDes("小幅度提升伤害Lv3")
                .Condtion(_ => atkLv2.UpgradeFinish)
                .OnUpgrade(_ =>
                {
                    //记录当前等级攻击力
                    float _atk = Global.Atk.Value;
                    //提升15%的攻击
                    Global.Atk.Value += _atk * 0.15f;
                })
            );
            var atkLv4 = Add(new ExpUpgradeItem()
                .WithKey("atk_damage_lv4")
                .WithDes("小幅度提升伤害Lv4")
                .Condtion(_ => atkLv3.UpgradeFinish)
                .OnUpgrade(_ =>
                {
                    //记录当前等级攻击力
                    float _atk = Global.Atk.Value;
                    //提升15%的攻击
                    Global.Atk.Value += _atk * 0.15f;
                })
            );
            var atkLv5 = Add(new ExpUpgradeItem()
                .WithKey("atk_damage_lv5")
                .WithDes("小幅度提升伤害Lv5")
                .Condtion(_ => atkLv4.UpgradeFinish)
                .OnUpgrade(_ =>
                {
                    //记录当前等级攻击力
                    float _atk = Global.Atk.Value;
                    //提升15%的攻击
                    Global.Atk.Value += _atk * 0.15f;
                })
            );
            var atkSpeedLv1 = Add(new ExpUpgradeItem()
                .WithKey("atk_speed_lv1")
                .WithDes("提升攻击速度Lv1")
                .OnUpgrade(_ =>
                {
                    //记录当前等级攻击速度
                    float _atk = Global.AtkSpeed.Value;
                    //提升5%的攻击速度
                    Global.AtkSpeed.Value += _atk * 0.05f;
                })
            );
            var atkSpeedLv2 = Add(new ExpUpgradeItem()
                .WithKey("atk_speed_lv2")
                .WithDes("提升攻击速度Lv2")
                .Condtion(_ => atkSpeedLv1.UpgradeFinish)
                .OnUpgrade(_ =>
                {
                    //记录当前等级攻击速度
                    float _atk = Global.AtkSpeed.Value;
                    //提升5%的攻击速度
                    Global.AtkSpeed.Value += _atk * 0.05f;
                })
            );
            var atkSpeedLv3 = Add(new ExpUpgradeItem()
                .WithKey("atk_speed_lv3")
                .WithDes("提升攻击速度Lv3")
                .Condtion(_ => atkSpeedLv2.UpgradeFinish)
                .OnUpgrade(_ =>
                {
                    //记录当前等级攻击速度
                    float _atk = Global.AtkSpeed.Value;
                    //提升5%的攻击速度
                    Global.AtkSpeed.Value += _atk * 0.05f;
                })
            );
            var atkSpeedLv4 = Add(new ExpUpgradeItem()
                .WithKey("atk_speed_lv4")
                .WithDes("提升攻击速度Lv4")
                .Condtion(_ => atkSpeedLv3.UpgradeFinish)
                .OnUpgrade(_ =>
                {
                    //记录当前等级攻击速度
                    float _atk = Global.AtkSpeed.Value;
                    //提升5%的攻击速度
                    Global.AtkSpeed.Value += _atk * 0.05f;
                })
            );
            var atkSpeedLv5 = Add(new ExpUpgradeItem()
                .WithKey("atk_speed_lv5")
                .WithDes("提升攻击速度Lv5")
                .Condtion(_ => atkSpeedLv4.UpgradeFinish)
                .OnUpgrade(_ =>
                {
                    //记录当前等级攻击速度
                    float _atk = Global.AtkSpeed.Value;
                    //提升5%的攻击速度
                    Global.AtkSpeed.Value += _atk * 0.05f;
                })
            );
            atkLv1.OnChanged.Register(() =>
            {
                atkLv2.OnChanged.Trigger();
            });
            atkLv2.OnChanged.Register(() =>
            {
                atkLv3.OnChanged.Trigger();
            });
            atkLv3.OnChanged.Register(() =>
            {
                atkLv4.OnChanged.Trigger();
            });
            atkLv4.OnChanged.Register(() =>
            {
                atkLv5.OnChanged.Trigger();
            });
            atkSpeedLv1.OnChanged.Register(() =>
            {
                atkSpeedLv2.OnChanged.Trigger();
            });
            atkSpeedLv2.OnChanged.Register(() =>
            {
                atkSpeedLv3.OnChanged.Trigger();
            });
            atkSpeedLv3.OnChanged.Register(() =>
            {
                atkSpeedLv4.OnChanged.Trigger();
            });
            atkSpeedLv4.OnChanged.Register(() =>
            {
                atkSpeedLv5.OnChanged.Trigger();
            });
        }
    }
}
