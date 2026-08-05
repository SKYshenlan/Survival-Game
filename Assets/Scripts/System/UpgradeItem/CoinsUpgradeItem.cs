using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brotato
{
    public class CoinsUpgradeItem
    {
        public string Key {  get;private set; }
        public string Des {  get;private set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
        private Action<CoinsUpgradeItem> mOnUpgrade;
        public void Upgrade()
        {
            mOnUpgrade?.Invoke(this);
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

    }
}
