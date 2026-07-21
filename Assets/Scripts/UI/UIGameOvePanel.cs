using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	public class UIGameOvePanelData : UIPanelData
	{
	}
	public partial class UIGameOvePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGameOvePanelData ?? new UIGameOvePanelData();
			// please add init code here
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
