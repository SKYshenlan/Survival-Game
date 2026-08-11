using QFramework;
using SurvivalGame;
using UnityEngine;

namespace Brotato
{
    public partial class EnemyBoos : ViewController, IEnemy
    {
        public float HP = 3;
        private float MoveSeppd = 2f;
        private bool _flag = false;
        FSM<States> FSM = new FSM<States>();
        public enum States
        {
            MovePlay,//向玩家移动
            Warning,//警戒
            Dash,//冲撞
            Wait,//等待
        }

        void Start()
		{
            //添加状态
			FSM.State(States.MovePlay)
                .OnFixedUpdate(() =>
                {
                    //向量的长度强制变成 1
                    if (Play.Defaulf)
                    {
                        var dir = (Play.Defaulf.transform.position - transform.position).normalized;
                        //敌人平滑移动
                        SelfRigidbody2D.velocity = dir * MoveSeppd;
                        Debug.Log("a");
                        //计算距离切换状态
                        if ((Play.Defaulf.transform.Position() - transform.Position()).magnitude <= 12)
                        {
                            FSM.ChangeState(States.Warning);
                        }
                    }
                    else
                    {
                        SelfRigidbody2D.velocity = Vector2.zero;
                    }
                });
            FSM.State(States.Warning)
                .OnEnter(() =>
                {
                    SelfRigidbody2D.velocity = Vector2.zero;
                })
               .OnUpdate(() =>
               {
                   var frames = 3 + (60 * 3 - FSM.FrameCountOfCurrentState) / 10;
                   if(FSM.FrameCountOfCurrentState / frames %2 == 0)
                   {
                       Triangle.color = Color.red;
                   }
                   else
                   {
                       Triangle.color = Color.white;
                   }
                   if (FSM.FrameCountOfCurrentState >= 60 * 2)
                   {
                       FSM.ChangeState(States.Dash);
                   }
               })
               .OnEnter(() =>
               {
                   Triangle.color = Color.white;
               });
            var das = Vector3.zero;
            var dasPlay = 0f;
            FSM.State(States.Dash)
                .OnEnter(() =>
                {
                    var dir = (Play.Defaulf.transform.Position()-transform.Position()).normalized;
                    SelfRigidbody2D.velocity = (dir * 20);
                    das = transform.Position();
                    dasPlay = (Play.Defaulf.transform.Position() - transform.Position()).magnitude;
                })
                .OnUpdate(() =>
                {
                    var dir = (transform.Position() - das).magnitude;
                    if(dir >= dasPlay + 5f)
                    {
                        FSM.ChangeState(States.Wait);
                    }
                });
            FSM.State(States.Wait)
                .OnEnter(() =>
                {
                    SelfRigidbody2D.velocity = Vector2.zero;
                })
                .OnUpdate(() =>
                {
                    if (FSM.FrameCountOfCurrentState >= 30)
                    {

                        FSM.ChangeState(States.MovePlay);
                    }
                });
            FSM.StartState(States.MovePlay);
            
		}
        private void FixedUpdate()
        {
            FSM.FixedUpdate();
            
        }
        private void Update()
        {
            FSM.Update();
            if (HP <= 0)
            {
                HP = 0;
                EnemyList.EnemyCount.Value--;
                //生产经验
                Global.Drop(gameObject);
                //消除对象
                this.DestroyGameObjGracefully();
            }
        }
        public void Hide(float value, bool flag = false)
        {
            if (_flag) return;
            //更改敌人颜色表示受伤
            Triangle.color = Color.red;
            FloatingTextController.Play(transform.position + Vector3.up, value);
            HP -= value;
            AudioKit.PlaySound("hit");
            //静态管理器 延迟任务注册到全局生命周期
            ActionKit.Delay(0.2f, () =>
            {
                //改变源颜色
                Triangle.color = Color.white;
                _flag = false;

            }).Start(this);//Start() 添加到当前物体生命周期中
        }

        public void SetHPScale(float hPScale)
        {
            HP *= hPScale;
        }

        public void SetSpeedScale(float speedScale)
        {
            MoveSeppd *= speedScale;
        }
    }
}
