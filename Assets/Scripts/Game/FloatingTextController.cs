using UnityEngine;
using QFramework;
using UnityEngine.UI;
using System;

namespace Brotato
{
	public partial class FloatingTextController : ViewController
	{
		private static FloatingTextController mDefault;
        private void Awake()
        {
            mDefault = this;
        }
        void Start()
		{
			FloatingText.Hide();

		}
        public static void Play(Vector2 pos,float text)
        {
            //生成伤害文字
            mDefault.FloatingText.InstantiateWithParent(mDefault.transform).Position(pos.x,pos.y).Self(f =>
            {
                var posY = pos.y;
                //查找文本
                var atk = f.transform.Find("atk");
                //获取文本组件
                var atkComp = atk.GetComponent<Text>();
                //显示伤害
                atkComp.text = text.ToString("0.##");
                //0.5秒后删除
                ActionKit.Sequence()
                .Lerp(0, 0.5f, 0.5f, (p) =>
                {
                    //设置字体y轴移动
                    f.PositionY(posY + p * 0.5f);
                    //将X轴限制在0-1之间
                    atkComp.LocalPositionX(Mathf.Clamp01( p * 4));
                    //将Y轴限制在0-1之间
                    atkComp.LocalPositionY(Mathf.Clamp01( p * 4));
                })
                .Delay(0.5f)//延迟0.5秒
                .Lerp(1.0f, 0, 0.3f, (p) =>
                {
                    //设置文本透明度1-0
                    atkComp.ColorAlpha(p);
                }, () =>
                {
                    //销毁
                    atk.DestroyGameObjGracefully();
                })
                .Start(atkComp);//执行并绑定生命周期

            }).Show();
        }
        private void OnDestroy()
        {
            mDefault = null;
        }
    }
}
