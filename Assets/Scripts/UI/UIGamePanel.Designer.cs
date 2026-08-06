using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:eb7e8c09-3c76-44bf-ab37-c4bf2ce1629a
	public partial class UIGamePanel
	{
		public const string Name = "UIGamePanel";
		
		[SerializeField]
		public UnityEngine.UI.Text xp;
		[SerializeField]
		public UnityEngine.UI.Text time;
		[SerializeField]
		public UnityEngine.UI.Text leve;
		[SerializeField]
		public UnityEngine.UI.Text HP;
		[SerializeField]
		public UnityEngine.UI.Text enemyCount;
		[SerializeField]
		public UnityEngine.UI.Text atk;
		[SerializeField]
		public UnityEngine.UI.Text coins;
		[SerializeField]
		public ExpUpgradePanel ExpUpgrade;
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			xp = null;
			time = null;
			leve = null;
			HP = null;
			enemyCount = null;
			atk = null;
			coins = null;
			ExpUpgrade = null;
			
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
