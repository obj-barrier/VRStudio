using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimationController : MonoBehaviour
{
    public PlayableDirector uChanAnimation;

    void Update()
    {
        if (Time.frameCount >= 10)
        {
            uChanAnimation.Pause();
        }
    }
}
