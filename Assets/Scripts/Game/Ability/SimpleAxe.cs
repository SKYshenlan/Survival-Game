using QFramework;
using SurvivalGame;
using UnityEngine;

namespace Brotato
{
	public partial class SimpleAxe : ViewController
	{
		void Start()
		{
			// Code Here
		}
		private float Second = 0;
        private void Update()
        {
			Second += Time.deltaTime;
			if( Second >= 1f)
			{
				Axe.Instantiate()
					.Show()
                    .Position(this.Position())
                    .Self(self =>
                    {
                        //获取刚体
                        var rigidbody2D = self.GetComponent<Rigidbody2D>();
                        //随机x位置
                        var ranX = RandomUtility.Choose(- 8, -5,-3 ,3,5, 8);
                        //随机y位置
                        var ranY = RandomUtility.Choose(3,5, 8);
                        //设置一个瞬间的绝对速度
                        rigidbody2D.velocity = new Vector2(ranX, ranY);
						self.OnTriggerEnter2DEvent(call =>
						{
                            var Box = call.GetComponent<HurtBox>();
                            if (Box)
                            {
                                if (Box.Owner.CompareTag("Enemy"))
                                {
                                    Box.Owner.GetComponent<Enemy>().Hide(Global.Atk.Value);
                                }
                            }
                        }).UnRegisterWhenGameObjectDestroyed(self);
                        ActionKit.OnUpdate.Register(() =>
                        {
                            if (Play.Defaulf)
                            {
                                if (Play.Defaulf.Position().y - self.Position().y > 15)
                                {
                                    self.DestroyGameObjGracefully();
                                }
                            }
                        }).UnRegisterWhenGameObjectDestroyed(self);
                    });
				Second = 0f;
			}
        }
    }
}
