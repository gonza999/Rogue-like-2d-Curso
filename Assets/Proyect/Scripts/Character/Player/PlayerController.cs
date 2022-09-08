using Game.Character.Camara;
using Game.Character.Shooting;
using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _fireRate;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private GameObject _bulletParticles;
        private float _horizontal;
        private float _vertical;
        private float _shootCounter;
        public Rigidbody2D rigidbody2D;
        public Transform transform;
        public CameraController cam;

        private void Start()
        {
            _shootCounter = 0f;
        }
        private void Update()
        {
            GetMoveInput();
            RotatePlayer();
            CheckShoot();
        }

        private void FixedUpdate()
        {
            ChangePlayerVelocity();
        }

        private void GetMoveInput()
        {
            _horizontal = Input.GetAxisRaw("Horizontal");
            _vertical = Input.GetAxisRaw("Vertical");
        }

        private void ChangePlayerVelocity()
        {
            rigidbody2D.velocity = new Vector2(_horizontal, _vertical) * Time.fixedDeltaTime * _moveSpeed;
        }

        private void RotatePlayer()
        {
            var dirToMouse = GetDirToMouse();
            Vector2 player = transform.up;
            float angle = Vector2.SignedAngle(player, dirToMouse);
            transform.Rotate(0f, 0f, angle);
        }

        private Vector2 GetDirToMouse()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return mousePos - transform.position;
        }
        private void CheckShoot()
        {
            _shootCounter -= Time.deltaTime;
            if (_shootCounter <= 0f)
            {
                _shootCounter = 0;
            }
            if (Input.GetMouseButton(0))
            {
                if (_shootCounter <= 0f)
                {
                    Shoot();
                }
            }
        }
        private void Shoot()
        {
            _shootCounter = _fireRate;
            GameObject bullet = BulletPoolManager.I.RequestBullet();
            bullet.transform.position = _shootPoint.position;
            bullet.GetComponent<Bullet>().SetDir(GetDirToMouse());
            cam.AnimateCamera();
            Destroy(Instantiate(_bulletParticles, _shootPoint.position, _shootPoint.rotation), 0.5f);
        }
    }
}
