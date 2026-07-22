using QFramework;
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
            ActionKit.OnUpdate.Register(() =>
            {
                //监听空格
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    this.CloseSelf();
                    //切换场景
                    SceneManager.LoadScene("SampleScene");
                }
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
