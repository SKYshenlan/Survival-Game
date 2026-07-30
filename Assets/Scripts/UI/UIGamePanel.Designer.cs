using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:7d3c9944-d881-40f5-818a-8733ac524b82
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
		public UnityEngine.UI.Text coins;
		[SerializeField]
		public UnityEngine.UI.Image Background;
		[SerializeField]
		public UnityEngine.UI.Button BinUp;
		[SerializeField]
		public UnityEngine.UI.Button attackSpeed;
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			xp = null;
			time = null;
			leve = null;
			enemyCount = null;
			atk = null;
			coins = null;
			Background = null;
			BinUp = null;
			attackSpeed = null;
			
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
