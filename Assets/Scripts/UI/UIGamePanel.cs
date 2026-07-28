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
            TextAtk();
            //注册并执行回调
            Global.Exp.RegisterWithInitValue(exp =>
			{
				xp.text = $"经验值「{exp}」";
				if (exp >= 5)
				{
					int LV = Global.Leve.Value;
					Global.Exp.Value -= 5;
					Global.Leve.Value++;
					if (LV != Global.Leve.Value)
					{
						Time.timeScale = 0;
						BinUp.Show();
					}
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);//gameObject被销毁或隐藏时注销事件
			//注册并执行回调
			Global.Leve.RegisterWithInitValue(Leve =>
			{
				leve.text = $"等级「{Leve}」";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);//gameObject被销毁或隐藏时注销事件
			BinUp.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                //记录当前等级攻击力
                float _atk = Global.Atk.Value;
                //提升15%的攻击
                Global.Atk.Value += _atk * 0.15f;
                TextAtk();
                BinUp.Hide();
            });
        }

        private void TextAtk()
        {
            atk.text = $"攻击「{Global.Atk.Value.ToString("0.##")}」";
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
