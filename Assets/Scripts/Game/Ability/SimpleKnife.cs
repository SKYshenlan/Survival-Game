using System.Linq;
using QAssetBundle;
using QFramework;
using SurvivalGame;
using UnityEngine;

namespace Brotato
{
    public partial class SimpleKnife : ViewController
    {
        private float Second = 0;
        void Start()
        {
            // Code Here
        }
        private void Update()
        {
            Second += Time.deltaTime;
            if (Second >= Global.KinfAtkSpeed.Value)
            {
                Second = 0;
                //查找满足条件的对象并返回数组         只查找激活状态             不进行排序
                var enemy = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None)
                    .OrderBy(e => Play.Defaulf.Distance2D(e))
                    .Take(Global.KinfAtkCout.Value);
                var i = 0;
                foreach (var item in enemy)
                {
                    if (i < 4)
                    {
                        ActionKit.DelayFrame(11 * i, () => AudioKit.PlaySound(Sfx.KNIFE))
                            .StartGlobal();
                        i++;
                    }
                    if (item)
                    {
                        Knife.Instantiate()
                            .Position(this.Position())
                            .Show()
                            .Self(self =>
                            {
                                var selfCache = self;
                                var dir = item.NormalizedDirection2DFrom(Play.Defaulf);
                                self.transform.up = dir;
                                //获取刚体
                                var rigidbody2D = self.GetComponent<Rigidbody2D>();
                                //设置一个瞬间的绝对速度
                                rigidbody2D.velocity = dir * 10;
                                var AttackCount = 0;
                                self.OnTriggerEnter2DEvent(call =>
                                {
                                    var Box = call.GetComponent<HurtBox>();
                                    if (Box)
                                    {
                                        if (Box.Owner.CompareTag("Enemy"))
                                        {
                                            //暴击概率                    伤害          敌人
                                            DamageSystem.CalculateDamage(Global.KinfAtk.Value, Box.Owner.GetComponent<Enemy>());
                                            AttackCount++;
                                            if(AttackCount >= Global.KinfPenetration.Value)
                                            {
                                                selfCache.DestroyGameObjGracefully();

                                            }
                                        }
                                    }
                                }).UnRegisterWhenGameObjectDestroyed(self);
                                ActionKit.OnUpdate.Register(() =>
                                {
                                    if (Play.Defaulf)
                                    {
                                        if ((Play.Defaulf.Distance2D(selfCache)) > 20)
                                        {
                                            self.DestroyGameObjGracefully();
                                        }
                                    }
                                }).UnRegisterWhenGameObjectDestroyed(self);
                            });
                    }
                }
                
            }
        }
    }
}
