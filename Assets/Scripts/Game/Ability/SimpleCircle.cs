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
			UpdateCirclePos();

        }
		void UpdateCirclePos()
		{
            //半径
            var radius = 3;
            //计算位置
            var Circlepos = new Vector2(Mathf.Cos(0 * Mathf.Deg2Rad), Mathf.Sin(0 * Mathf.Deg2Rad)) * radius;
            Circle.LocalPosition(Circlepos.x, Circlepos.y)
                .LocalEulerAnglesZ(-90);
        }
        private void Update()
        {


			//速度
			var degree = Time.frameCount;
			this.LocalEulerAnglesZ(-degree);
			
        }
    }
}
