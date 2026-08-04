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
