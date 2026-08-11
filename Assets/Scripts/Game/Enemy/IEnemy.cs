using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brotato
{
    internal interface IEnemy
    {
        public void Hide(float value, bool flag = false);
        void SetHPScale(float hPScale);
        void SetSpeedScale(float speedScale);
    }
}
