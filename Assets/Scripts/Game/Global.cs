using System.Collections;
using System.Collections.Generic;
using Brotato;
using QFramework;
using UnityEngine;

namespace SurvivalGame
{
    public class Global : Architecture<Global>
    {
        #region Model
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
        /// <summary>
        /// 炸弹概率
        /// </summary>
        public static BindableProperty<float> BombPercent = new BindableProperty<float>(0.1f);
        /// <summary>
        /// 血包概率
        /// </summary>
        public static BindableProperty<float> HpPercent = new BindableProperty<float>(0.3f);
        /// <summary>
        /// 磁铁概率
        /// </summary>
        public static BindableProperty<float> MagnetPercent = new BindableProperty<float>(0.3f);
        /// <summary>
        /// 生命值
        /// </summary>
        public static BindableProperty<int> HP = new BindableProperty<int>(3);
        /// <summary>
        /// 最大生命值
        /// </summary>
        public static BindableProperty<int> MaxHp = new BindableProperty<int>(3);

        #endregion
        ///启动时自动执行
        [RuntimeInitializeOnLoadMethod]
        public static void AutoInit()
        {
            ResKit.Init();
            UIKit.Root.SetResolution(1920, 1080, 1);
            Coins.Value = PlayerPrefs.GetInt(nameof(Coins), 0);
            MaxHp.Value = PlayerPrefs.GetInt(nameof(MaxHp), 3);
            ExpPercent.Value = PlayerPrefs.GetFloat(nameof(ExpPercent), 0.3f);
            CoinsPercent.Value = PlayerPrefs.GetFloat(nameof(CoinsPercent), 0.05f);
            HpPercent.Value = PlayerPrefs.GetFloat(nameof(HpPercent), 0.15f);
            MagnetPercent.Value = PlayerPrefs.GetFloat(nameof(MagnetPercent), 0.15f);
            BombPercent.Value = PlayerPrefs.GetFloat(nameof(BombPercent), 0.1f);
            HP.Value = MaxHp.Value;
            MaxHp.Register(_hp =>
            {
                PlayerPrefs.SetInt(nameof(MaxHp), _hp);
            });
            Coins.Register(_coins =>
            {
                PlayerPrefs.SetInt(nameof(Coins), _coins);
            });
            ExpPercent.Register(_expPercent =>
            {
                PlayerPrefs.SetFloat(nameof(ExpPercent), _expPercent);
            });
            CoinsPercent.Register(_coinsPercent =>
            {
                PlayerPrefs.SetFloat(nameof(CoinsPercent), _coinsPercent);
            });
            HpPercent.Register(_hpPercent =>
            {
                PlayerPrefs.SetFloat(nameof(HpPercent), _hpPercent);
            });
            MagnetPercent.Register(_magnetPercent =>
            {
                PlayerPrefs.SetFloat(nameof(MagnetPercent), _magnetPercent);
            });
            BombPercent.Register(_bombPercent =>
            {
                PlayerPrefs.SetFloat(nameof(BombPercent), _bombPercent);
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
                return;
            }
            DropRate = Random.Range(0, 1f);
            if(DropRate <= CoinsPercent.Value)
            {
                //生成金币
                DropManager.Default.Coins.Instantiate().Position(go.Position()).Show();
                return;
            }
            DropRate = Random.Range(0, 1f);
            if(DropRate <= HpPercent.Value)
            {
                //生成血包
                DropManager.Default.Hp.Instantiate().Position(go.Position()).Show();
                return;
            }
            DropRate = Random.Range(0, 1f);
            if (DropRate <= BombPercent.Value)
            {
                //生成炸弹
                DropManager.Default.Bomb.Instantiate().Position(go.Position()).Show();
                return;
            }
            DropRate = Random.Range(0, 1f);
            if (DropRate <= MagnetPercent.Value)
            {
                //生成磁铁
                DropManager.Default.GetAllExp.Instantiate().Position(go.Position()).Show();
                return;
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
            HP.Value = MaxHp.Value;
            EnemyList.EnemyCount.Value = 0;
        }
        /// <summary>
        /// 重置
        /// </summary>
        public static void Reset()
        {
            Coins.Value = 0;
            ExpPercent.Value = 0.3f;//30%
            CoinsPercent.Value = 0.05f;//5%
            BombPercent.Value = 0.1f;//10%
            HpPercent.Value = 0.15f;//15%
            MagnetPercent.Value = 0.15f;//15%

        }

        protected override void Init()
        {
            //注册模块
            this.RegisterSystem(new SaveSystem());
            this.RegisterSystem(new CoinsUpgradeSystem());
        }
    }
}
