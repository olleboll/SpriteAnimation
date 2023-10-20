using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SpriteAnimator
{
    [CustomEditor(typeof(SpriteAnimationData))]

    public class SpriteAnimationDataEditor : Editor
    {
        SpriteAnimationData animation;

        private void OnEnable()
        {
            //target is by default available for you
            //because we inherite Editor
            animation = target as SpriteAnimationData;

            if (animation.key == "") {
                animation.key = animation.name;
            }
        }

        //Here is the meat of the script
        public override void OnInspectorGUI()
        {
            //Draw whatever we already have in SO definition
            base.OnInspectorGUI();
            if (animation?.animation == null || animation.animation.Count < 1)
            {
                return;
            }

            foreach (Sprite sprite in animation.animation)
            {
                //Convert the weaponSprite (see SO script) to Texture
                Texture2D texture = AssetPreview.GetAssetPreview(sprite);
                //We crate empty space 80x80 (you may need to tweak it to scale better your sprite
                //This allows us to place the image JUST UNDER our default inspector
                GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
                //Draws the texture where we have defined our Label (empty space)
                GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
            }
        }

    }

}