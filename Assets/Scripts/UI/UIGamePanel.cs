using UnityEngine;
using UnityEngine.UI;
using QFramework;
using SurvivalGame;

namespace GameUI
{
	public class UIGamePanelData : UIPanelData
	{
	}
	public partial class UIGamePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGamePanelData ?? new UIGamePanelData();
			// please add init code here
			//注册并执行回调
			Global.Exp.RegisterWithInitValue(exp =>
			{
				xp.text = $"经验值：{exp}";
				if (exp >= 5)
				{
					Global.Exp.Value -= 5;
					Global.Leve.Value++;
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);//gameObject被销毁或隐藏时注销事件
			//注册并执行回调
			Global.Leve.RegisterWithInitValue(Leve =>
			{
				leve.text = $"等级：{Leve}";
			}).UnRegisterWhenGameObjectDestroyed(gameObject);//gameObject被销毁或隐藏时注销事件
        }
		
		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
