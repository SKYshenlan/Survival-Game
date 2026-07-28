using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:0cea0800-9a4f-4fa4-8042-6af893cd53ac
	public partial class UIGamePanel
	{
		public const string Name = "UIGamePanel";
		
		[SerializeField]
		public UnityEngine.UI.Text xp;
		[SerializeField]
		public UnityEngine.UI.Text leve;
		[SerializeField]
		public UnityEngine.UI.Text atk;
		[SerializeField]
		public UnityEngine.UI.Button BinUp;
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			xp = null;
			leve = null;
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
