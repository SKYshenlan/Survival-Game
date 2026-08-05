using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:3828986f-b61f-4772-bda1-10ad368d32bd
	public partial class UIStartScreen
	{
		public const string Name = "UIStartScreen";
		
		[SerializeField]
		public UnityEngine.UI.Button Open;
		[SerializeField]
		public UnityEngine.UI.Button StartGame;
		[SerializeField]
		public UnityEngine.UI.Button Reset;
		[SerializeField]
		public Background Background;
		
		private UIStartScreenData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Open = null;
			StartGame = null;
			Reset = null;
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
