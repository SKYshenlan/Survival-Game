using UnityEngine;
using QFramework;
using SurvivalGame;
using QAssetBundle;

namespace Brotato
{
	public partial class Ball : ViewController
	{
		void Start()
		{
			SdelfRigidbody2D.velocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f))*Random.Range(Global.BasketBallSpeed.Value -2,Global.BasketBallSpeed.Value +2);
			HurtBox.OnTriggerEnter2DEvent(call =>
			{
				var hurtBox = call.GetComponent<HurtBox>();
				if(hurtBox)
				{
					if (hurtBox.Owner.CompareTag("Enemy"))
					{
						var enemy = hurtBox.Owner.GetComponent<IEnemy>();
						enemy.Hide(Global.BasketBallAtk.Value);
                        if (Random.Range(0, 1f) < 0.5f&&call&&call.attachedRigidbody&&Play.Defaulf)
                        {
                            //自身方向与朝向玩家位置方向产生的推力
                            call.attachedRigidbody.velocity = call.NormalizedDirection2DFrom(this) * 5 + call.NormalizedDirection2DFrom(Play.Defaulf) * 10;
                        }
                    }
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
		}
        private void OnCollisionEnter2D(Collision2D collision)
        {
			var normal = collision.GetContact(0).normal;
			if (normal.x > normal.y)
			{
                var rb = SdelfRigidbody2D;
                rb.velocity = new Vector2(rb.velocity.x,
					Mathf.Sign(rb.velocity.y) * Random.Range(0.5f, 1.5f) * 
					Random.Range(Global.BasketBallSpeed.Value - 2, Global.BasketBallSpeed.Value + 2));
                rb.angularVelocity = Random.Range(-360, 360);
            }
			else
			{
				var rb = SdelfRigidbody2D;
				rb.velocity =
                    new Vector2(
						//保持原有水平方向，随机0.5~0.5倍
						Mathf.Sign(rb.velocity.x) * Random.Range(0.5f, 1.5f) * Random.Range(
							Global.BasketBallSpeed.Value - 2, Global.BasketBallSpeed.Value + 2)
						,rb.velocity.y);
				rb.angularVelocity = Random.Range(-360, 360);
            }
			AudioKit.PlaySound(Sfx.BALL);
        }
    }
}
