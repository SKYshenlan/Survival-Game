using System.Collections.Generic;
using QFramework;
using SurvivalGame;
using UnityEngine;

namespace Brotato
{
	public partial class RotatteSword : ViewController
	{
		private List<Collider2D> mSword = new List<Collider2D>();
		void Start()
		{
			//监听数量
			Global.RotatteSwordCount.RegisterWithInitValue(count =>
			{
				var toAddCount = count - mSword.Count;
				for (int i = 0; i < toAddCount; i++)
				{
					//生成剑
					mSword.Add(Sword.InstantiateWithParent(this)
						.Self(self =>
                        {
							//碰撞回调
                            self.OnTriggerEnter2DEvent(call =>
                             {
                                var Box = call.GetComponent<HurtBox>();
                                if (Box)
                                {
                                     if (Box.Owner.CompareTag("Enemy"))
                                     {
                                         Box.Owner.GetComponent<Enemy>().Hide(Global.RotatteSwordAtk.Value);
										 if (Random.Range(0, 1f) < 0.5f)
                                         {	
											 //自身方向与朝向玩家位置方向产生的推力
                                             call.attachedRigidbody.velocity = call.NormalizedDirection2DFrom(self)*5+call.NormalizedDirection2DFrom(Play.Defaulf)*10;
										 }
                                     }
                                }
                             }).UnRegisterWhenGameObjectDestroyed(self);
                        })
						.Show());
				}
                UpdateCirclePos();
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
			Global.RotatteSwordRange.RegisterWithInitValue((range) =>
			{
				UpdateCirclePos();

            }).UnRegisterWhenGameObjectDestroyed(gameObject);

        }
		void UpdateCirclePos()
		{
            //半径
            var radius = Global.RotatteSwordRange.Value;
			var durationDegrees = 360/mSword.Count;
            for (int i = 0; i < mSword.Count; i++)
            {
				//计算位置
				var Circlepos = new Vector2(Mathf.Cos(durationDegrees * i * Mathf.Deg2Rad), Mathf.Sin(durationDegrees * i * Mathf.Deg2Rad)) * radius;
				mSword[i].LocalPosition(Circlepos.x, Circlepos.y)
				.LocalEulerAnglesZ(durationDegrees * i - 90);
            }
            
        }
        private void Update()
        {
			//速度
			var degree = Time.frameCount * Global.RotatteSwordSpeed.Value;
			this.LocalEulerAnglesZ(-degree);
        }
    }
}
