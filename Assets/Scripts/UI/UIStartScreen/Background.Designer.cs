/****************************************************************************
 * 2026.8 深蓝
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	public partial class Background
	{
		[SerializeField] public UnityEngine.UI.Button BtnCoinsUp;
		[SerializeField] public UnityEngine.UI.Button UpgradeButton;
		[SerializeField] public UnityEngine.UI.Button BtnExpUp;
		[SerializeField] public UnityEngine.UI.Button BtnHpUp;
		[SerializeField] public UnityEngine.UI.Button BtnClose;
		[SerializeField] public UnityEngine.UI.Text coins;
		[SerializeField] public RectTransform UpgradePanel;

		public void Clear()
		{
			BtnCoinsUp = null;
			UpgradeButton = null;
			BtnExpUp = null;
			BtnHpUp = null;
			BtnClose = null;
			coins = null;
			UpgradePanel = null;
		}

		public override string ComponentName
		{
			get { return "Background";}
		}
	}
}
