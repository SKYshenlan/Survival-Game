using UnityEngine;
using QFramework;
using SurvivalGame;

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
			if( Second >= Global.AtkSpeed.Value)
			{
				Second = 0;
                //查找满足条件的对象并返回数组         只查找激活状态             不进行排序
                var enemy = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude,FindObjectsSortMode.None);
                foreach (var item in enemy)
                {
                    var dir = (Play.Defaulf.transform.position - item.transform.position).magnitude;
                    if (dir <= 5)
                    {
                        item.Hide(Global.Atk.Value);
                    }
                }
            }
        }
    }
}
