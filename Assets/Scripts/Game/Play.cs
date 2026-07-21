using UnityEngine;
using QFramework;

namespace Brotato
{
	public partial class Play : ViewController
	{
		private float MoveSpeed = 5f;
		private float x, y;
		void Start()
		{
			// Code Here
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
