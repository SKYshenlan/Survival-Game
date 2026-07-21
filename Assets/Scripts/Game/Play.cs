using UnityEngine;
using QFramework;
using GameUI;

namespace Brotato
{
	public partial class Play : ViewController
	{
		private float MoveSpeed = 5f;
		private float x, y;
        public static Play Defaulf;
        #region 测试代码
        private void Awake()
        {
            Defaulf = this;
        }
        private void OnDestroy()
        {
            Defaulf = null;
        }
        #endregion
        void Start()
		{
            // Code Here
            //碰撞事件注册
            HurtBox.OnTriggerEnter2DEvent(coll =>
			{
                //销毁
                this.DestroyGameObjGracefully();
                //打开面板
                UIKit.OpenPanel<UIGameOvePanel>();
			}).UnRegisterWhenDisabled(gameObject);//gameObject被销毁或隐藏时注销事件
        }
        private void Update()
        {
			//移动
			x = Input.GetAxis("Horizontal");
			y = Input.GetAxis("Vertical");
            //向量的长度强制变成 1
            var dir = new Vector2(x,y).normalized;
            //计算好的速度值赋给刚体
            DelfRigidbody2D.velocity = dir * MoveSpeed;
        }
    }
}
