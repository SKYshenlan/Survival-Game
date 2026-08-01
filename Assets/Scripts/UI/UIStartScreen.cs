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
                }
				else
				{
					BtnCoinsUp.Hide();
					BtnExpUp.Hide();
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			StartGame.onClick.AddListener(() =>
			{
				this.CloseSelf();
                //切换场景
                SceneManager.LoadScene("SampleScene");
            });
			Open.onClick.AddListener(() =>
			{
				Background.Show();
			});
			BtnCoinsUp.onClick.AddListener(() =>
			{
				Global.CoinsPercent.Value += 0.05f;
			});
			BtnExpUp.onClick.AddListener(() =>
			{
                Global.ExpPercent.Value += 0.1f;
            });
            BtnClose.onClick.AddListener(() =>
			{
				Background.Hide();
			});
            #endregion
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
