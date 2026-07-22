using UnityEngine;
using QFramework;

namespace Brotato
{
	public partial class Simple_Ability : ViewController
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
			if( Second >= 1f)
			{
				Second = 0;
                //查找满足条件的对象并返回数组         只查找激活状态             不进行排序
                var enemy = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude,FindObjectsSortMode.None);
                foreach (var item in enemy)
                {
					var dir = (Play.Defaulf.transform.position - item.transform.position).magnitude;
					if (dir <= 5)
					{
						//更改敌人颜色表示受伤
						item.Triangle.color = Color.red;
                        item.HP--;
                        //静态管理器 延迟任务注册到全局生命周期
                        ActionKit.Delay(0.3f,() =>
						{
							//改变源颜色
							item.Triangle.color = Color.white;
							
						}).Start(item);//Start() 添加到当前物体生命周期中
                    }
                }
            }
        }
    }
}
