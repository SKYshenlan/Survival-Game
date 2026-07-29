using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:10984fc6-61d9-485e-9f56-afb5abd0d25a
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
		public UnityEngine.UI.Text enemyCount;
		[SerializeField]
		public UnityEngine.UI.Text atk;
		[SerializeField]
		public UnityEngine.UI.Button BinUp;
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			xp = null;
			time = null;
			leve = null;
			enemyCount = null;
			atk = null;
			BinUp = null;
			
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
