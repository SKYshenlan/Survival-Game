using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:fafba994-b523-47a0-9878-a4c57302db37
	public partial class UIStartScreen
	{
		public const string Name = "UIStartScreen";
		
		[SerializeField]
		public UnityEngine.UI.Button Open;
		[SerializeField]
		public UnityEngine.UI.Button StartGame;
		[SerializeField]
		public UnityEngine.UI.Image Background;
		[SerializeField]
		public UnityEngine.UI.Button BtnCoinsUp;
		[SerializeField]
		public UnityEngine.UI.Button BtnExpUp;
		[SerializeField]
		public UnityEngine.UI.Button BtnHpUp;
		[SerializeField]
		public UnityEngine.UI.Button BtnClose;
		[SerializeField]
		public UnityEngine.UI.Text coins;
		
		private UIStartScreenData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Open = null;
			StartGame = null;
			Background = null;
			BtnCoinsUp = null;
			BtnExpUp = null;
			BtnHpUp = null;
			BtnClose = null;
			coins = null;
			
			mData = null;
		}
		
		public UIStartScreenData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIStartScreenData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIStartScreenData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
