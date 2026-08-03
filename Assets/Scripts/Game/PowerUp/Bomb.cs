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
