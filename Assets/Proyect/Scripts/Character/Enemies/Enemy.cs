using Game.Character.Animations;
using Game.Character.Shooting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character.Enemies
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health;

        [Header("HitAnimation")]
        [SerializeField] private HitAnimations _hitAnimation;

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
            StartCoroutine(_hitAnimation.Co_HitColorChange(false, 0));
        }
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
