using System.Linq;
using QFramework;
using SurvivalGame;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brotato
{
	public partial class Simple_Sword : ViewController
	{
		//时间（秒）
		private float Second = 0f;
		void Start()
		{
			// Code Here
		}
        private void Update()
        {
            Second += Time.deltaTime;
            if (Second >= Global.AtkSpeed.Value)
            {
                Second = 0;
                //查找满足条件的对象并返回数组         只查找激活状态             不进行排序
                var enemy = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
                // 按敌人与玩家位置的距离从小到大排序；并筛选出小于玩家攻击半径的敌人，再取前 Global.AtkCount.Value 个
                foreach (var item in enemy.OrderBy(e => e.Direction2DFrom(Play.Defaulf).magnitude)
                    .Where(e => e.Direction2DFrom(Play.Defaulf).magnitude < Global.AtkRamge.Value)
                    .Take(Global.AtkCount.Value))
                {
                    Sword.Instantiate()
                            .Position(item.Position() + Vector3.left * 0.25f)
                            .Show()
                            .Self(self =>
                            {
                                var selfCache = self;
                                selfCache.OnTriggerEnter2DEvent(call =>
                                {
                                    var hurtBox = call.GetComponent<HurtBox>();
                                    if (hurtBox != null)
                                    {
                                        if (hurtBox.Owner.CompareTag("Enemy"))
                                        {
                                            //暴击概率                    伤害          敌人
                                            DamageSystem.CalculateDamage(Global.Atk.Value, hurtBox.Owner.GetComponent<Enemy>());
                                        }
                                    }
                                }).UnRegisterWhenGameObjectDestroyed(gameObject);
                                //劈砍动画,创建一个动作序列
                                ActionKit.Sequence()
                                //添加一个回调动作
                                .Callback(() =>
                                {
                                    // 禁用selfCache
                                    selfCache.enabled = false;
                                })
                                //添加一个并行动作组
                                .Parallel(p =>
                                {
                                    //在并行组中添加一个插值动作，从0到10（值），持续时间0.2秒，z为插值因子（0~1）
                                    p.Lerp(0, 10, 0.2f, (z) => selfCache.LocalEulerAnglesZ(z));
                                    //在并行组中添加一个顺序子序列
                                    p.Append(ActionKit.Sequence()
                                        //子序列第一步：缩放从0到1.25，0.1秒
                                        .Lerp(0, 1.25f, 0.1f, scale => { selfCache.LocalScale(scale); })
                                        //子序列第二步：缩放从1.25回到1，0.1秒
                                        .Lerp(1.25f, 1, 0.1f, scale => { selfCache.LocalScale(scale); })
                                    );
                                })
                                .Callback(() => { selfCache.enabled = true; })
                                .Parallel(p =>
                                {
                                    p.Lerp(10, -180, 0.2f, z => selfCache.LocalEulerAnglesZ(z));
                                    //在并行组中添加一个顺序子序列
                                    p.Append(ActionKit.Sequence()
                                            //子序列第一步：缩放从1到1.25，0.1秒
                                            .Lerp(1, 1.25f, 0.1f, scale => { selfCache.LocalScale(scale); })
                                            //子序列第二步：缩放从1.25回到1，0.1秒
                                            .Lerp(1.25f, 1, 0.1f, scale => { selfCache.LocalScale(scale); })
                                    );
                                })
                                .Callback(() => { selfCache.enabled = true; })
                                .Lerp(-180, 0, 0.3f, z =>
                                {
                                    selfCache.LocalEulerAnglesZ(z)
                                    .LocalScale(z.Abs() / 180);
                                })
                                .Start(this, () =>
                                {
                                    //动作执行完删除对象
                                    selfCache.DestroyGameObjGracefully();
                                });
                            });
                }
            }
        }
    }
}
