using QFramework;
using SurvivalGame;
using UnityEngine;

namespace Brotato
{
	public partial class Coins : ViewController
	{
		void Start()
		{
			// Code Here
		}
        /// <summary>
        /// 拾取金币
        /// </summary>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<pickupRange>())
            {
                Global.Coins.Value++;
                this.DestroyGameObjGracefully();
            }

        }
    }
}
