using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:f98d0e80-d247-4cad-a58c-95610c60791b
	public partial class UIStartScreen
	{
		public const string Name = "UIStartScreen";
		
		[SerializeField]
		public UnityEngine.UI.Button Open;
		[SerializeField]
		public UnityEngine.UI.Image Background;
		[SerializeField]
		public UnityEngine.UI.Button BtnCoinsUp;
		[SerializeField]
		public UnityEngine.UI.Button BtnExpUp;
		[SerializeField]
		public UnityEngine.UI.Button BtnClose;
		
		private UIStartScreenData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Open = null;
			Background = null;
			BtnCoinsUp = null;
			BtnExpUp = null;
			BtnClose = null;
			
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
