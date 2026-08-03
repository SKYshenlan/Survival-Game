using QFramework;
using SurvivalGame;
using Unity.VisualScripting;
using UnityEngine;

namespace Brotato
{
	/// <summary>
	/// 经验
	/// </summary>
	public partial class Exp : ViewController
	{
		void Start()
		{
			// Code Here
		}
		/// <summary>
		/// 拾取经验
		/// </summary>
        private void OnTriggerEnter2D(Collider2D collision)
        {
			if (collision.GetComponent<pickupRange>())
			{
				AudioKit.PlaySound("exp");
                Global.Exp.Value++;
                this.DestroyGameObjGracefully();
            }

		}
    }
}
