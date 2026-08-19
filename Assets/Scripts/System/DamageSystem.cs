using SurvivalGame;
using UnityEngine;

namespace Brotato
{
    internal class DamageSystem
    {
        public static void CalculateDamage(float baseDamage,IEnemy enemy,int maxDamage=2,float DamageTime = 5)
        {
            if (Random.Range(0,1.0f) < Global.Damage.Value)
            {
                enemy.Hide(baseDamage * Random.Range(2f, DamageTime), false, true);
            }
            else
            {
                enemy.Hide(baseDamage);
            }
        }
    }
}
