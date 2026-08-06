/****************************************************************************
 * 2026.8 深蓝
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	public partial class ExpUpgradePanel
	{
		[SerializeField] public UnityEngine.UI.Image Background;
		[SerializeField] public UnityEngine.UI.Button BinUp;

		public void Clear()
		{
			Background = null;
			BinUp = null;
		}

		public override string ComponentName
		{
			get { return "ExpUpgradePanel";}
		}
	}
}
