using QFramework;
using SurvivalGame;
using Unity.VisualScripting;
using UnityEngine;

namespace Brotato
{
	public partial class Exp : ViewController
	{
		void Start()
		{
			// Code Here
		}
        private void OnTriggerEnter2D(Collider2D collision)
        {
			if (collision.GetComponent<pickupRange>())
			{
                Global.Exp.Value++;
                this.DestroyGameObjGracefully();
            }

		}
    }
}
