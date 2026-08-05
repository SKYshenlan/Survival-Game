/****************************************************************************
 * 2026.8 深蓝
 ****************************************************************************/
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
            this.GetSystem<CoinsUpgradeSystem>().Say();
            //UpgradeButton.Hide();
            foreach (var item in this.GetSystem<CoinsUpgradeSystem>().Item)
            {
                var itemCache = item;
                //生成按钮在面板
                UpgradeButton.InstantiateWithParent(UpgradePanel).Self(self =>{
                    self.GetComponentInChildren<Text>().text = item.Des;
                    Debug.Log(item.Des);
                    self.onClick.AddListener(() =>
                    {
                        itemCache.Upgrade();
                        AudioKit.PlaySound("LvUp");
                    });
                    var selfBut = self;
                    Global.Coins.RegisterWithInitValue(_coins =>
                    {
                        if(_coins >= item.Price)
                        {
                            selfBut.interactable = true;
                        }
                        else
                        {
                            selfBut.interactable = false;
                        }
                    }).UnRegisterWhenGameObjectDestroyed(gameObject);
                }).Show();
            }
            #region 按钮
            Global.Coins.RegisterWithInitValue(_coins =>
            {
                coins.text = $"金币「{_coins}」";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
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