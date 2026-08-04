using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brotato
{
    public class CoinsUpgradeItem
    {
        public string Key {  get; set; }
        public string Des {  get; set; }
        private Action mOnUpgrade;
        public void Upgrade()
        {
            mOnUpgrade?.Invoke();
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
        public CoinsUpgradeItem OnUpgrade(Action onUpgrade)
        {
            mOnUpgrade = onUpgrade;
            return this;
        }

    }
}
