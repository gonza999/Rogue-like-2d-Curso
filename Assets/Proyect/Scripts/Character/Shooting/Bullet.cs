using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character.Shooting
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _bulletMoveSpeed;
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private GameObject _bulletParticles;

        private Vector2 _dir = Vector2.zero;
        public Rigidbody2D rigidbody2D;

        private void FixedUpdate()
        {
            Move();
        }
        private void Update()
        {
            Rotate();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.TakeDamage(1);
            }
            DisableBulletInstantly();
        }
        private void DisableBulletInstantly()
        {
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(Co_DisableBullet(0f));
            }
        }
        private IEnumerator Co_DisableBullet(float time)
        {
            yield return new WaitForSeconds(time);
            _trailRenderer.Clear();
            Destroy(Instantiate(_bulletParticles, transform.position, transform.rotation), 0.5f);
            if (gameObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
            }
        }
        private void Move()
        {
            if (_dir == Vector2.zero)
            {
                return;
            }
            rigidbody2D.velocity = _bulletMoveSpeed * Time.deltaTime * new Vector2(_dir.normalized.x, _dir.normalized.y);
        }

        private void Rotate()
        {
            if (_dir == Vector2.zero)
            {
                return;
            }
            transform.up = _dir;
        }

        public void SetDir(Vector2 dir) { _dir = dir; }
    }
}
