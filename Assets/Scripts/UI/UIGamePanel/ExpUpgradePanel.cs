/****************************************************************************
 * 2026.8 深蓝
 ****************************************************************************/

using System;
using System.Collections.Generic;
using Brotato;
using QFramework;
using SurvivalGame;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public partial class ExpUpgradePanel : UIElement, IController
	{
		private void Awake()
		{
            var expUpgradeSystem = this.GetSystem<ExpUpgradeSystem>();
            foreach (var item in expUpgradeSystem.Item)
            {
                //生成按钮在面板
                BinUp.InstantiateWithParent(Background).Self(self => {
                    var itemCache = item;
                    self.GetComponentInChildren<Text>().text = item.Des;
                    self.onClick.AddListener(() =>
                    {
                        itemCache.Upgrade();
                        Time.timeScale = 1;
                        this.Hide();
                        AudioKit.PlaySound("LvUp");
                    });
                    var selfBut = self;
                    itemCache.Visible.RegisterWithInitValue(visible =>
                    {
                        if (visible)
                        {
                            selfBut.Show();
                        }
                        else
                        {
                            selfBut.Hide();
                        }

                    }).UnRegisterWhenGameObjectDestroyed(selfBut);
                });
            }
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