using UnityEngine;
using QFramework;

namespace Brotato
{
    /// <summary>
    /// 掉落物管理
    /// </summary>
	public partial class DropManager : ViewController
	{
		public static DropManager Default;
        private void Awake()
        {
			Default = this;
        }
        private void OnDestroy()
        {
            Default = null;
        }
        void Start()
		{
			// Code Here
		}
	}
}
