using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Managers
{
    public class BulletPoolManager : Singleton<BulletPoolManager>
    {
        [SerializeField] private int _initialNumberOfBullets;
        [SerializeField] private Transform _bulletsParent;

        public GameObject bulletPrefab;
        private List<GameObject> bulletPool = new List<GameObject>();

        private void Start()
        {
            bulletPool = GenerateBullets(_initialNumberOfBullets);
        }
        private List<GameObject> GenerateBullets(int amountBullets)
        {
            for (int i = 0; i < amountBullets; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, _bulletsParent);
                bullet.SetActive(false);
                bulletPool.Add(bullet);
            }
            return bulletPool;
        }

        public GameObject RequestBullet()
        {
            foreach (GameObject b in bulletPool)
            {
                if (!b.activeInHierarchy)
                {
                    b.SetActive(true);
                    return b;
                }
            }
            bulletPool = GenerateBullets(1);
            return RequestBullet();
        }
    }
}
