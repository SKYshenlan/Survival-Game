using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brotato;
using QFramework;
using Unity.Mathematics;

namespace Brotato
{
    internal class ExpUpgradeItem
    {
        public ExpUpgradeItem(bool flag)
        {
            IsWeapon = flag;
        }
        /// <summary>
        /// 是否是武器
        /// </summary>
        public bool IsWeapon = false;
        /// <summary>
        /// 建
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Des => mDesFun(CurrentLeve.Value);
        /// <summary>
        /// 等级
        /// </summary>
        public int MaxLeve { get; private set; }
        /// <summary>
        /// 当前等级
        /// </summary>
        public BindableProperty<int> CurrentLeve = new BindableProperty<int>(1);
        public BindableProperty<bool> Visible = new BindableProperty<bool>();
        private Func<int, string> mDesFun;
        /// <summary>
        /// 是否到达升级上限
        /// </summary>
        public bool UpgradeFinish { get; set; } = false;
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }

        private Action<ExpUpgradeItem,int> mOnUpgrade;
        public void Upgrade()
        {
            mOnUpgrade?.Invoke(this,CurrentLeve.Value);
            CurrentLeve.Value++;
            if (CurrentLeve.Value > 10)
            {
                UpgradeFinish = true;
            }
        }
        public ExpUpgradeItem WithKey(string key)
        {
            Key = key;
            return this;
        }
        public ExpUpgradeItem WithDes(Func<int,string> des)
        {
            mDesFun = des;
            return this;
        }
        public ExpUpgradeItem WithPrice(int price)
        {
            Price = price;
            return this;
        }
        public ExpUpgradeItem WithMax(int leve)
        {
            MaxLeve = leve;
            return this;
        }
        public ExpUpgradeItem OnUpgrade(Action<ExpUpgradeItem,int> onUpgrade)
        {
            mOnUpgrade = onUpgrade;
            return this;
        }
    }
}
