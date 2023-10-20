using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpriteAnimator
{
    [CreateAssetMenu(menuName = "SpriteAnimator/SpriteAnimationData")]
    public class SpriteAnimationData : ScriptableObject
    {
        public string key;
        public float animationSpeed = 1;
        public List<Sprite> animation;
    }
}