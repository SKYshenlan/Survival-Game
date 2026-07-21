using UnityEngine;
using QFramework;

namespace Brotato
{
	public partial class Enemy : ViewController
	{
		private float MoveSeppd = 2f;
		void Start()
		{
			// Code Here
		}
        private void Update()
        {
            //任意一个匹配类型的对象
            //var play = FindObjectOfType<Play>();
            //向量的长度强制变成 1
            if (Play.Defaulf)
            {
                var dir = (Play.Defaulf.transform.position - transform.position).normalized;
                //敌人平滑移动
                transform.Translate(dir * Time.deltaTime * MoveSeppd);
            }
        }
    }
}
