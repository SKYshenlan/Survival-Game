/****************************************************************************
 * 2026.8 深蓝
 ****************************************************************************/

using System;
using System.Collections.Generic;
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
            foreach (var item in this.GetSystem<CoinsUpgradeSystem>().Item)
            {
                var itemCache = item;
                //生成按钮在面板
                UpgradeButton.InstantiateWithParent(UpgradePanel).Self(self =>{
                    (self.targetGraphic as Text).text = item.Des;
                    self.onClick.AddListener(() =>
                    {
                        itemCache.Upgrade();
                    });
                }).Show();
            }
            BtnCoinsUp.Hide();
            BtnExpUp.Hide();
            BtnHpUp.Hide();
            #region 按钮
            Global.Coins.RegisterWithInitValue(_coins =>
            {
                coins.text = $"金币「{_coins}」";
                if (_coins >= 5)
                {
                    BtnCoinsUp.Show();
                    BtnExpUp.Show();
                    BtnHpUp.Show();
                }
                else
                {
                    BtnCoinsUp.Hide();
                    BtnExpUp.Hide();
                    BtnHpUp.Hide();
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            BtnCoinsUp.onClick.AddListener(() =>
            {
                if (Global.Coins.Value >= 10)
                {
                    Global.Coins.Value -= 10;
                    //增加金币概率
                    Global.CoinsPercent.Value += 0.05f;
                    Sound();
                }
            });
            BtnExpUp.onClick.AddListener(() =>
            {
                if (Global.Coins.Value >= 10)
                {
                    Global.Coins.Value -= 10;
                    //增加经验概率
                    Global.ExpPercent.Value = 0.1f;
                    Sound();
                }
            });
            BtnHpUp.onClick.AddListener(() =>
            {
                if (Global.Coins.Value >= 10)
                {
                    Global.Coins.Value -= 10;
                    //增加血包概率
                    Global.HpPercent.Value = 0.09f;
                    Sound();
                }
            });
            BtnClose.onClick.AddListener(() =>
            {
                this.Hide();
            });
            #endregion
        }
        private void Sound()
        {
            AudioKit.PlaySound("LvUp");
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