using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character.Camara
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _smoothSpeed = 5f;
        [SerializeField] private float _zOffSet = -10f;
        [SerializeField] private float _screenShakeTime = 0.1f;
        [SerializeField] private float _cameraMaxMoveLimit = 0.05f;
        public Transform player;
        private float _screenShakeTimeCounter;
        private Transform _t;

        private void Awake()
        {
            _t = GetComponent<Transform>();
        }

        private void Update()
        {
            CalculateCamPos();
        }
        private void CalculateCamPos()
        {
            Vector2 playerPos = player.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mousePos - playerPos;
            Vector2 newPos = playerPos + (dir / 2);
            Vector2 smoothPos = Vector2.Lerp(_t.position, newPos, _smoothSpeed * Time.deltaTime);

            _t.position = new Vector3(smoothPos.x, smoothPos.y, _zOffSet);
        }

        public void AnimateCamera()
        {
            StartCoroutine(nameof(Co_ScreenShake));
        }

        private IEnumerator Co_ScreenShake()
        {
            _screenShakeTimeCounter = _screenShakeTime;
            while (_screenShakeTimeCounter > 0f)
            {
                float newRandomX = Random.Range(-_cameraMaxMoveLimit, _cameraMaxMoveLimit);
                float newRandomY = Random.Range(_cameraMaxMoveLimit, _cameraMaxMoveLimit);
                _t.position = new Vector3(newRandomX, newRandomY, -10f);
                _screenShakeTimeCounter -= Time.deltaTime;

                yield return null;
            }
        }
    }
}
