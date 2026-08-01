using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:4683a4d4-5d8b-4ea0-b812-24823cda74b2
	public partial class UIGameOvePanel
	{
		public const string Name = "UIGameOvePanel";
		
		[SerializeField]
		public UnityEngine.UI.Button btn_Back;
		
		private UIGameOvePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			btn_Back = null;
			
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
