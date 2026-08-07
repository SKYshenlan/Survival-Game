using System.Linq;
using QFramework;
using SurvivalGame;
using UnityEngine;
using static UnityEditor.Progress;

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
            if (Second >= 1)
            {
                Second = 0;
                //查找满足条件的对象并返回数组         只查找激活状态             不进行排序
                var enemy = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
                var en = enemy.OrderBy(enemy => (Play.Defaulf.transform.position - enemy.transform.position).magnitude).FirstOrDefault();
                if (en)
                {
                    Knife.Instantiate()
                        .Position(this.Position())
                        .Show()
                        .Self(self =>
                        {
                            //获取刚体
                            var rigidbody2D = self.GetComponent<Rigidbody2D>();
                            var dir = (en.Position() - Play.Defaulf.Position()).normalized;
                            //设置一个瞬间的绝对速度
                            rigidbody2D.velocity = dir * 10;
                            self.OnTriggerEnter2DEvent(call =>
                            {
                                var Box = call.GetComponent<HurtBox>();
                                if (Box)
                                {
                                    if (Box.Owner.CompareTag("Enemy"))
                                    {
                                        Box.Owner.GetComponent<Enemy>().Hide(Global.Atk.Value);
                                        self.DestroyGameObjGracefully();
                                    }
                                }
                            }).UnRegisterWhenGameObjectDestroyed(self);
                            ActionKit.OnUpdate.Register(() =>
                            {
                                if (Play.Defaulf)
                                {
                                    if ((Play.Defaulf.Position() - self.Position()).magnitude > 20)
                                    {
                                        self.DestroyGameObjGracefully();
                                    }
                                }
                            }).UnRegisterWhenGameObjectDestroyed(self);
                        });
                    en.Hide(Global.Atk.Value);
                }
            }
        }
    }
}
