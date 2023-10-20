# SpriteAnimation
Unity Scripts to improve the handling of sprites and sprite animations. Removing the need for the Unity Animator.

### Functionality

These scripts does not aim to provide the same functionality as the Unity Animator component. Rather it simplifies the functionality since many of the feature in the built in animator is overkill when you only want some simple sprite animations.

- Define `SpriteAnimationData` from sprites. Import assets as you normally would but create `SpriteAnimationData` Assets (Scriptable Objects) for each animation. 
- Attach a `SpriteAnimator` on the GameObject you want to animate.
- Add all the `SpriteAnimationData` assets you want the GameObject to be able to animate.
- Call `PlayAnimation(string key)` where the key is defined on the `SpriteAnimationData`Asset.

WIP