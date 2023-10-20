using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpriteAnimator
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField] private List<SpriteAnimationData> m_AnimationData;
        private SpriteRenderer spriteRenderer;
        private SpriteAnimation currentAnimation;
        private Dictionary<string, SpriteAnimation> m_Animations;
        private Func<float> m_timeModifierGetter;

        void Start(){
            // Default?
            foreach (SpriteAnimationData animation in m_AnimationData)
            {
                PlayAnimation(animation.key);
                break;
            }
        }

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            m_Animations = new Dictionary<string, SpriteAnimation>();
            foreach (SpriteAnimationData animation in m_AnimationData)
            {
                m_Animations.Add(animation.key, new SpriteAnimation(animation));
            }
        }
        void Update()
        {
            currentAnimation.Update(getTimeModifier());
            spriteRenderer.sprite = currentAnimation.GetCurrentSprite();
        }

        public void RegisterAnimation(SpriteAnimationData animation)
        {
            m_AnimationData.Add(animation);
        }

        public void PlayAnimation(string key, bool reset = true)
        {
            currentAnimation?.Stop(reset);
            if (m_Animations.TryGetValue(key, out currentAnimation)) {
                currentAnimation.Play();
            }
        }

        public void RegisterTimeModifierCallback(Func<float> callback){
            m_timeModifierGetter = callback;
        }

        private float getTimeModifier(){
            if (m_timeModifierGetter != null) {
                return m_timeModifierGetter();
            }
            return Time.deltaTime;
        }
    }
}