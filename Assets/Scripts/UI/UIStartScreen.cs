using QFramework;
using SurvivalGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameUI
{
	public class UIStartScreenData : UIPanelData
	{
	}
	public partial class UIStartScreen : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIStartScreenData ?? new UIStartScreenData();
			// please add init code here
			#region 按钮
			Global.Coins.RegisterWithInitValue(_coins =>
			{
				coins.text = $"金币「{_coins}」";
				if (_coins >= 5)
				{
					BtnCoinsUp.Show();
					BtnExpUp.Show();
                    BtnHpUp.Show();
                }
				else
				{
					BtnCoinsUp.Hide();
					BtnExpUp.Hide();
                    BtnHpUp.Hide();
                }
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			StartGame.onClick.AddListener(() =>
			{
				this.CloseSelf();
                //切换场景
                SceneManager.LoadScene("Game");
            });
			Open.onClick.AddListener(() =>
			{
				Background.Show();
			});
			BtnCoinsUp.onClick.AddListener(() =>
			{
				if (Global.Coins.Value >= 10)
				{
					Global.Coins.Value -= 10;
					//增加金币概率
                    Global.CoinsPercent.Value += 0.05f;
					Sound();
                }
            });
			BtnExpUp.onClick.AddListener(() =>
			{
                if(Global.Coins.Value >= 10)
				{
                    Global.Coins.Value -= 10;
                    //增加经验概率
                    Global.ExpPercent.Value = 0.1f;
					Sound();
                }
            });
            BtnHpUp.onClick.AddListener(() =>
			{
                if(Global.Coins.Value >= 10)
				{
                    Global.Coins.Value -= 10;
                    //增加血包概率
                    Global.HpPercent.Value = 0.09f;
					Sound();
                }
            });
            BtnClose.onClick.AddListener(() =>
			{
				Background.Hide();
			});
            #endregion
        }
		private void Sound()
		{
			AudioKit.PlaySound("LvUp");
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
