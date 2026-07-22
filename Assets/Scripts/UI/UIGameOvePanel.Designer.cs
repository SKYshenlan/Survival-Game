using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:24d1b195-e689-4f28-b0d1-4455b0f434ab
	public partial class UIGameOvePanel
	{
		public const string Name = "UIGameOvePanel";
		
		
		private UIGameOvePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public UIGameOvePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGameOvePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGameOvePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
