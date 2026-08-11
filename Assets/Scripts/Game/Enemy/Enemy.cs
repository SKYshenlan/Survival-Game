using QFramework;
using SurvivalGame;
using UnityEngine;

namespace Brotato
{
    public partial class Enemy : ViewController, IEnemy
    {
        public float HP = 3;
		public float MoveSeppd = 2f;
        private bool _flag = false;
        public Color DissolveColor = Color.yellow;
		void Start()
		{
            // Code Here
            EnemyList.EnemyCount.Value++;

        }
        private void FixedUpdate()
        {
            //向量的长度强制变成 1
            if (Play.Defaulf)
            {
                var dir = (Play.Defaulf.transform.position - transform.position).normalized;
                //敌人平滑移动
                SelfRigidbody2D.velocity = dir * MoveSeppd;
            }
            else
            {
                SelfRigidbody2D.velocity = Vector2.zero;
            }
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
        private void Update()
        {
            if (HP <= 0)
            {
                Global.Drop(gameObject);
                FxController.Play(Triangle, DissolveColor);
                //消除对象
                this.DestroyGameObjGracefully();
            }
        }
        /// <summary>
        /// 掉血逻辑
        /// </summary>
        public void Hide(float value,bool flag =false)
        {
            if (_flag) return;
            //更改敌人颜色表示受伤
            Triangle.color = Color.red;
            FloatingTextController.Play(transform.position+Vector3.up,value);
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
