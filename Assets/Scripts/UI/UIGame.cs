using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	public class UIGameData : UIPanelData
	{
	}
	public partial class UIGame : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGameData ?? new UIGameData();
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
