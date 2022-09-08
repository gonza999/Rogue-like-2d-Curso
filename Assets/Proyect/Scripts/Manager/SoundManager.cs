using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Managers
{
    public enum SoundType
    {
        playerWalk,
        playerShoot,
        enemyHit
    }
    public class SoundManager : Singleton<SoundManager>
    {

        public void PlaySoud(SoundType st, float newVolume)
        {

        }
    }
}
