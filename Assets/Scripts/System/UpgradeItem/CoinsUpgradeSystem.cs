using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QFramework;

namespace Brotato
{
    public class CoinsUpgradeSystem : AbstractSystem
    {
        public List<CoinsUpgradeItem> Item {  get;} = new List<CoinsUpgradeItem>();
        protected override void OnInit()
        {
            Item.Add(new CoinsUpgradeItem()
            .WithKey("aaa")
            .WithDes("")
            .OnUpgrade(() =>
            {

            }));
        }
        public void Say()
        {

        }
    }
}
