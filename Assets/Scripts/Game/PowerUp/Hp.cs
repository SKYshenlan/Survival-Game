using QFramework;
using SurvivalGame;
using UnityEngine;

namespace Brotato
{
	public partial class Hp : ViewController
	{
		void Start()
		{
			// Code Here
		}
        /// <summary>
        /// 拾取血包
        /// </summary>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<pickupRange>())
            {
                if(Global.HP.Value!= Global.MaxHp.Value)
                {
                    AudioKit.PlaySound("hp");
                    Global.HP.Value++;
                    this.DestroyGameObjGracefully();
                }
            }

        }
    }
}
