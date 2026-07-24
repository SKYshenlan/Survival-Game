using UnityEngine;
using QFramework;

namespace Brotato
{
	public partial class EnemyList : ViewController
	{
		private float Second = 0f;
        private void Update()
        {
            Second += Time.deltaTime;
            if(Second >= 1)
            {
                Second = 0f;
                //获取玩家
                var play = Play.Defaulf;
                //随机角度
                var randomAngle = Random.Range(0, 360f);
                //随机半径
                var randomRadius = randomAngle * Mathf.Deg2Rad;
                //方向
                var dir = new Vector3(Mathf.Cos(randomRadius),Mathf.Sin(randomRadius));
                //位置
                var pos = play.transform.position + dir * 10;
                //在“pos位置”生成敌人并显示
                Enemy.Instantiate().Position(pos).Show();  
            }
        }

    }
}
