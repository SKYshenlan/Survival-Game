using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:acb3fc50-94f6-48f8-860e-dcae640f24fd
	public partial class UIStartScreen
	{
		public const string Name = "UIStartScreen";
		
		[SerializeField]
		public UnityEngine.UI.Button Open;
		[SerializeField]
		public UnityEngine.UI.Button StartGame;
		[SerializeField]
		public Background Background;
		
		private UIStartScreenData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Open = null;
			StartGame = null;
			Background = null;
			
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
