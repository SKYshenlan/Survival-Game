using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brotato;
using QFramework;

namespace Brotato
{
    internal class ExpUpgradeItem
    {
        public EasyEvent OnChanged = new EasyEvent();
        public string Key { get; private set; }
        public string Des { get; private set; }
        public int MaxLeve { get; private set; }
        public int CurrentLeve { get; private set; } = 0;
        public BindableProperty<bool> Visible = new BindableProperty<bool>();
        /// <summary>
        /// 是否到达升级上限
        /// </summary>
        public bool UpgradeFinish { get; set; } = false;
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
        private Func<ExpUpgradeItem, bool> mCondtion;
        private Action<ExpUpgradeItem,int> mOnUpgrade;
        public void Upgrade()
        {
            CurrentLeve++;
            mOnUpgrade?.Invoke(this,CurrentLeve);
            if (CurrentLeve >= 10)
            {
                UpgradeFinish = true;
            }
            OnChanged.Trigger();
        }
        public ExpUpgradeItem WithKey(string key)
        {
            Key = key;
            return this;
        }
        public ExpUpgradeItem WithDes(string des)
        {
            Des = des;
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
        public ExpUpgradeItem Condtion(Func<ExpUpgradeItem, bool> condtion)
        {
            mCondtion = condtion;
            return this;
        }
    }
}
