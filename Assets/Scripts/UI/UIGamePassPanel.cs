using QFramework;
using SurvivalGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameUI
{
	public class UIGamePassPanelData : UIPanelData
	{
	}
	public partial class UIGamePassPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGamePassPanelData ?? new UIGamePassPanelData();
            // please add init code here
            //静态管理器 每帧执行管理器的全局队列
            Time.timeScale = 0;
            ActionKit.OnUpdate.Register(() =>
            {
                //监听空格
                if (Input.GetKeyDown(KeyCode.Space))
                {
					Global.ResetData();
                    this.CloseSelf();
                    //切换场景
                    SceneManager.LoadScene("Game");
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);//gameObject被销毁或隐藏时注销事件
            btn_Back.onClick.AddListener(() =>
            {
                Global.ResetData();
                SceneManager.LoadScene("GameStart");
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
