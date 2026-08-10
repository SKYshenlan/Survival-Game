using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Brotato
{
    [CreateAssetMenu]
    public class LeveWaveConfig : ScriptableObject
    {   
        [SerializeField]//敌方波次
        public List<EnemyWaveGroup> enemy = new List<EnemyWaveGroup>();
    }
    [Serializable]
    public class EnemyWaveGroup
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 描述
        /// </summary>
        [TextArea] public string Description = string.Empty;
        [SerializeField]
        /// <summary>
        /// 敌人
        /// </summary>
        public List<EnemyWave> Waves = new List<EnemyWave>();
    }
    [Serializable]
    public class EnemyWave
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool Active = true;
        /// <summary>
        /// 生成时间
        /// </summary>
        public float DurationSec = 1;
        /// <summary>
        /// 敌人模型
        /// </summary>
        public GameObject EnemyPrefab;
        /// <summary>
        /// 当前波次时间
        /// </summary>
        public int Second = 10;
        /// <summary>
        /// 血量
        /// </summary>
        public float HPScale = 1.0f;
        /// <summary>
        /// 速度
        /// </summary>
        public float SpeedScale = 1.0f;
    }
}