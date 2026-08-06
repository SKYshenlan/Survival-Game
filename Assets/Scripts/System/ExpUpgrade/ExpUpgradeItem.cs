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
        /// <summary>
        /// 是否到达升级上限
        /// </summary>
        public bool UpgradeFinish { get; set; } = false;
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
        public bool ConditionCheck()
        {
            if (mCondtion != null)
            {
                return !UpgradeFinish && mCondtion.Invoke(this);
            }
            return !UpgradeFinish;
        }
        private Func<ExpUpgradeItem, bool> mCondtion;
        private Action<ExpUpgradeItem> mOnUpgrade;
        public void Upgrade()
        {
            mOnUpgrade?.Invoke(this);
            UpgradeFinish = true;
            OnChanged.Trigger();
            CoinsUpgradeSystem.OnCoinsUpgradeSystemChanged.Trigger();
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
        public ExpUpgradeItem OnUpgrade(Action<ExpUpgradeItem> onUpgrade)
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
