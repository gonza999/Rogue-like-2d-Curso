using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character.Shooting
{
    public interface IDamageable
    {
        public void TakeDamage(int damage);
    }
}
