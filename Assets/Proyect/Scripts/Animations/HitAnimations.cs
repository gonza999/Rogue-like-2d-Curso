using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character.Animations
{
    [System.Serializable]
    public class HitAnimations
    {
        public Color agentColor = new Color(1f, 1f, 1f);
        [SerializeField] private Color _hitColor = new Color(1f, 0f, 0f);
        [SerializeField] private Color _invencibilityColor = new Color(0f, 1f, 0f);

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _timeToWaitForColorChange = 0.05f;

        public IEnumerator Co_HitColorChange(bool makeInvencible, float invencibilityTime)
        {
            _spriteRenderer.color = _hitColor;
            yield return new WaitForSeconds(_timeToWaitForColorChange);
            _spriteRenderer.color = agentColor;
            if (makeInvencible)
                yield return (Co_SetInviciblityColor(invencibilityTime));
        }
        private IEnumerator Co_SetInviciblityColor(float invenciblityTime)
        {
            _spriteRenderer.color = _invencibilityColor;
            yield return new WaitForSeconds(invenciblityTime);
            _spriteRenderer.color = agentColor;
        }
    }
}
