using UnityEngine;
using QFramework;
using System.Collections.Generic;
//using System;

namespace Brotato
{
    [System.Serializable]
    public class EnemyWave
    {
        public float DurationSec = 1;
        /// <summary>
        /// 敌人模型
        /// </summary>
        public GameObject EnemyPrefab;
        /// <summary>
        /// 当前时间
        /// </summary>
        public int Second = 10;
    }
	public partial class EnemyList : ViewController
	{
        /// <summary>
        /// 敌人集合
        /// </summary>
        [SerializeField] private List<EnemyWave> EnemyWave = new List<EnemyWave>();
        /// <summary>
        /// 敌人队列
        /// </summary>
        private Queue<EnemyWave> mEnemyWaveQueue = new Queue<EnemyWave>();
        private EnemyWave currentWave = null;
        /// <summary>
        /// 当前时间
        /// </summary>
        private float currentSecond = 0f;
        /// <summary>
        /// 波次时间
        /// </summary>
        private float currentWaveSecond = 0f;
        /// <summary>
        /// 当前波次
        /// </summary>
        private int WaveCount = 0;
        public bool flag => WaveCount == EnemyWave.Count;
        private void Start()
        {
            //遍历敌人集合
            foreach (var enemy in EnemyWave)
            {
                //将敌人存入队列
                mEnemyWaveQueue.Enqueue(enemy);
            }
        }
        private void Update()
        {
            if(currentWave == null)
            {
                if(mEnemyWaveQueue.Count > 0)
                {
                    WaveCount++;
                    currentWave = mEnemyWaveQueue.Dequeue();
                    currentSecond = 0;
                    currentWaveSecond = 0;
                }
            }
            if(currentWave != null)
            {
                currentSecond += Time.deltaTime;
                currentWaveSecond += Time.deltaTime;
                
                if (currentSecond >= currentWave.DurationSec)
                {
                    currentSecond = 0f;
                    //获取玩家
                    var play = Play.Defaulf;
                    if (play)
                    {
                        //随机角度
                        var randomAngle = Random.Range(0, 360f);
                        //随机半径
                        var randomRadius = randomAngle * Mathf.Deg2Rad;
                        //方向
                        var dir = new Vector3(Mathf.Cos(randomRadius), Mathf.Sin(randomRadius));
                        //位置
                        var pos = play.transform.position + dir * 10;
                        //在“pos位置”生成敌人并显示
                        currentWave.EnemyPrefab.Instantiate().Position(pos).Show();
                    }
                }
                if (currentWaveSecond >= currentWave.Second)
                {
                    currentWave = null;
                }
            }
            
        }

    }
}
