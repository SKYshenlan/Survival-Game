using UnityEngine;
using QFramework;
using SurvivalGame;
using System.Linq;

namespace Brotato
{
    public partial class AbilityCount : ViewController, IController
	{
        

        void Start()
		{
			Global.AtkeUnlocked.RegisterWithInitValue(flag =>
			{
				if (flag)
				{
					Simple_Sword.Show();
                }
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			Global.RotatteSwordeUnlocked.RegisterWithInitValue(flag =>
			{
				if (flag)
				{
                    RotatteSword.Show();
                }
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			Global.BasketBalleUnlocked.RegisterWithInitValue(flag =>
			{
				if (flag)
				{
                    BasketBallAbilit.Show();
                }
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			Global.KinfeUnlocked.RegisterWithInitValue(flag =>
			{
				if (flag)
				{
                    SimpleKnife.Show();
                }
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			//随机升级
			this.GetSystem<ExpUpgradeSystem>().Item.Where(item => item.IsWeapon)
				.ToList()	
				.GetRandomItem().Upgrade();
		}
        public IArchitecture GetArchitecture()
        {
			return Global.Interface;
        }
    }
}
