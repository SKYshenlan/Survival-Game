using System.Collections;
using System.Collections.Generic;
using Brotato;
using QFramework;
using UnityEngine;

namespace SurvivalGame
{
    public class Global
    {
        /// <summary>
        /// 经验 主动通知UI发生改变的响应式数据容器
        /// </summary>
        public static BindableProperty<int> Exp = new BindableProperty<int>(0);
        /// <summary>
        /// 等级
        /// </summary>
        public static BindableProperty<int> Leve = new BindableProperty<int>(1);
        /// <summary>
        /// 攻击力
        /// </summary>
        public static BindableProperty<float> Atk = new BindableProperty<float>(1);
        /// <summary>
        /// 倒计时秒
        /// </summary>
        public static BindableProperty<float> Second = new BindableProperty<float>(0);
        /// <summary>
        /// 倒计时分
        /// </summary>
        public static BindableProperty<float> minutes = new BindableProperty<float>(0);
        /// <summary>
        /// 攻击速度
        /// </summary>
        public static BindableProperty<float> AtkSpeed = new BindableProperty<float>(1);
        /// <summary>
        /// 金币
        /// </summary>
        public static BindableProperty<int> Coins = new BindableProperty<int>(0);
        /// <summary>
        /// 经验概率
        /// </summary>
        public static BindableProperty<float> ExpPercent = new BindableProperty<float>(0.3f);
        /// <summary>
        /// 金币概率
        /// </summary>
        public static BindableProperty<float> CoinsPercent = new BindableProperty<float>(0.05f);
        public static void AutoInit()
        {
            Global.Coins.Value = PlayerPrefs.GetInt(nameof(Coins), 0);
            Global.ExpPercent.Value = PlayerPrefs.GetFloat(nameof(ExpPercent), 0.3f);
            Global.CoinsPercent.Value = PlayerPrefs.GetFloat(nameof(CoinsPercent), 0.05f);
            Global.Coins.Register(_coins =>
            {
                PlayerPrefs.GetInt(nameof(Coins), _coins);
            });
            Global.ExpPercent.Register(_expPercent =>
            {
                PlayerPrefs.SetFloat(nameof(ExpPercent), _expPercent);
            });
            Global.CoinsPercent.Register(_coinsPercent =>
            {
                PlayerPrefs.SetFloat(nameof(CoinsPercent), _coinsPercent);
            });
        }
        public static int GetExp()
        {
            return Leve.Value * 5;
        }
        public static void Drop(GameObject go)
        {
            //掉落概率
            var DropRate = Random.Range(0, 1f);
            if (DropRate <= ExpPercent.Value)
            {
                //生成经验         
                DropManager.Default.Exp.Instantiate().Position(go.Position()).Show();
            }
            DropRate = Random.Range(0, 1f);
            if(DropRate <= CoinsPercent.Value)
            {
                //生成金币
                DropManager.Default.Coins.Instantiate().Position(go.Position()).Show();
            }
        }
        public static void ResetData()
        {
            Exp.Value = 0;
            Leve.Value = 1;
            Atk.Value = 1;
            Second.Value = 0;
            minutes.Value = 0;
            AtkSpeed.Value = 1;
            EnemyList.EnemyCount.Value = 0;
        }
    }
}
