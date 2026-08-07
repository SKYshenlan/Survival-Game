using UnityEngine;
using QFramework;
using System;
using SurvivalGame;

namespace Brotato
{
	public partial class SimpleCircle : ViewController
	{
		void Start()
		{
			Circle.OnTriggerEnter2DEvent(call =>
			{
				var Box = call.GetComponent<HurtBox>();
				if (Box)
				{
					if (Box.Owner.CompareTag("Enemy"))
					{
						Box.Owner.GetComponent<Enemy>().Hide(Global.Atk.Value);
					}
				}

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
		}
        private void Update()
        {
			//半径
			var radius = 3;
			//速度
			var degree = Time.frameCount;
			//计算位置
			var Circlepos = new Vector2(-Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad)) * radius;
            Circle.LocalPosition(Circlepos.x,Circlepos.y);
        }
    }
}
