using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QFramework;

namespace Brotato
{
    /// <summary>
    /// 升级物品
    /// </summary>
    public class CoinsUpgradeItem
    {
        public EasyEvent OnChanged = new EasyEvent();
        public string Key {  get;private set; }
        public string Des {  get;private set; }
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
                return ! UpgradeFinish && mCondtion.Invoke(this);
            }
            return !UpgradeFinish;
        }
        private Func<CoinsUpgradeItem, bool> mCondtion;
        private Action<CoinsUpgradeItem> mOnUpgrade;
        public void Upgrade()
        {
            mOnUpgrade?.Invoke(this);
            UpgradeFinish = true;
            OnChanged.Trigger();
            CoinsUpgradeSystem.OnCoinsUpgradeSystemChanged.Trigger();
        }
        public CoinsUpgradeItem WithKey(string key)
        {
            Key = key;
            return this;
        }
        public CoinsUpgradeItem WithDes(string des)
        {
            Des = des;
            return this;
        }
        public CoinsUpgradeItem WithPrice(int price)
        {
            Price = price;
            return this;
        }
        public CoinsUpgradeItem OnUpgrade(Action<CoinsUpgradeItem> onUpgrade)
        {
            mOnUpgrade = onUpgrade;
            return this;
        }
        public CoinsUpgradeItem Condtion(Func<CoinsUpgradeItem,bool> condtion)
        {
            mCondtion = condtion;
            return this;
        }
    }
}
