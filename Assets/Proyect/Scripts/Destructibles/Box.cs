using Game.Character.Shooting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Destructibles
{
    public class Box : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health;
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
