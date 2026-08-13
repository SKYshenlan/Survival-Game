using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:9d56c0d0-fa77-4b28-ae83-fd387e00a068
	public partial class UIGamePanel
	{
		public const string Name = "UIGamePanel";
		
		[SerializeField]
		public UnityEngine.UI.Text time;
		[SerializeField]
		public UnityEngine.UI.Text leve;
		[SerializeField]
		public UnityEngine.UI.Text enemyCount;
		[SerializeField]
		public UnityEngine.UI.Text coins;
		[SerializeField]
		public ExpUpgradePanel ExpUpgrade;
		[SerializeField]
		public UnityEngine.UI.Image ExpBgValue;
		[SerializeField]
		public UnityEngine.UI.Image ScreenColor;
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			time = null;
			leve = null;
			enemyCount = null;
			coins = null;
			ExpUpgrade = null;
			ExpBgValue = null;
			ScreenColor = null;
			
			mData = null;
		}
		
		public UIGamePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGamePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGamePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
