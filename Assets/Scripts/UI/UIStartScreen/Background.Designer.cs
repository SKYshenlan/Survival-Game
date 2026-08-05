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
		[SerializeField] public UnityEngine.UI.Button UpgradeButton;
		[SerializeField] public UnityEngine.UI.Button BtnClose;
		[SerializeField] public UnityEngine.UI.Text coins;
		[SerializeField] public RectTransform UpgradePanel;

		public void Clear()
		{
			UpgradeButton = null;
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
