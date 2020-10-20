using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Callable Functions/Shoot")]
    public class ShootCaller : ScriptableObject
    {
        public PoolingManager poolingManager;

        public void WakeInPool(ShootBehavior shoot)=> poolingManager.WakeInPool(shoot);
    }
}

