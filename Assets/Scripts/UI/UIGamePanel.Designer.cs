using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:75107f8f-aabb-427f-b41e-3f3daf224dab
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
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			time = null;
			leve = null;
			enemyCount = null;
			coins = null;
			ExpUpgrade = null;
			ExpBgValue = null;
			
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
