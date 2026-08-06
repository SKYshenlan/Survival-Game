/****************************************************************************
 * 2026.8 深蓝
 ****************************************************************************/
using System.Linq;
using Brotato;
using QFramework;
using SurvivalGame;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public partial class Background : UIElement, IController
	{
		private void Awake()
		{
            UpgradeButton.Hide();
            #region 按钮
            Global.Coins.RegisterWithInitValue(_coins =>
            {
                coins.text = $"金币「{_coins}」";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            foreach (var item in this.GetSystem<CoinsUpgradeSystem>().Item.Where(item => !item.UpgradeFinish))
            {
                var itemCache = item;
                //生成按钮在面板
                UpgradeButton.InstantiateWithParent(UpgradePanel).Self(self => {
                    self.GetComponentInChildren<Text>().text = item.Des;
                    Debug.Log(item.Des);
                    self.onClick.AddListener(() =>
                    {
                        itemCache.Upgrade();
                        AudioKit.PlaySound("LvUp");
                    });
                    var selfBut = self;
                    item.OnChanged.Register(() =>
                    {
                        if (itemCache.ConditionCheck())
                        {
                            selfBut.Show();
                        }
                        else
                        {
                            selfBut.Hide();
                        }
                    }).UnRegisterWhenGameObjectDestroyed(selfBut);
                    if (itemCache.ConditionCheck())
                    {
                        selfBut.Show();
                    }
                    else
                    {
                        selfBut.Hide();
                    }
                    Global.Coins.RegisterWithInitValue(_coins =>
                    {
                        if (_coins >= item.Price)
                        {
                            selfBut.interactable = true;
                        }
                        else if (selfBut != null)
                        {
                            selfBut.interactable = false;
                        }
                    }).UnRegisterWhenGameObjectDestroyed(gameObject);
                });
            }
            //关闭
            BtnClose.onClick.AddListener(() =>
            {
                this.Hide();
            });
            #endregion
        }
        protected override void OnBeforeDestroy()
		{
		}

        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }
    }
}