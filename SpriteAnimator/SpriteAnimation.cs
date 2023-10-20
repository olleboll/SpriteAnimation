using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpriteAnimator
{
    public class SpriteAnimation
    {
        private SpriteAnimationData m_Animation;
        private Sprite currentFrame;
        private int m_currentFrameIndex = 0;
        private float m_animationCounter;
        private bool m_running;
        public SpriteAnimation(SpriteAnimationData animation)
        {
            m_Animation = animation;
            this.Stop();
        }

        public void Update(float delta){
            if (!m_running) return;

            m_animationCounter += m_Animation.animationSpeed * delta;
            if (m_animationCounter >= 1) {
                m_animationCounter = 0;
                m_currentFrameIndex++;
            }

            if (m_currentFrameIndex >= m_Animation.animation.Count) {
                m_currentFrameIndex = 0;
            }

            currentFrame = m_Animation.animation[m_currentFrameIndex];
        }

        public Sprite GetCurrentSprite(){
            return currentFrame;
        }

        public void Stop(bool reset = true){
            m_running = false;
            if (reset) {
                m_currentFrameIndex = 0;
                m_animationCounter = 0;
            }
        }

        public void Play(){
            m_running = true;
        }

    }
}