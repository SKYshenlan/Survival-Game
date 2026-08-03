using QFramework;
using SurvivalGame;
using UnityEngine;

namespace Brotato
{
	public partial class Bomb : ViewController
	{
		void Start()
		{
			// Code Here

		}
        /// <summary>
        /// 对所有敌人造成伤害
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<pickupRange>())
            {
                AudioKit.PlaySound("bomb");
                foreach (var enemy in FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
                {
                    enemy.Hide(enemy.HP);
                }
                this.DestroyGameObjGracefully();
            }

        }
    }
}
