using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvent : MonoBehaviour
{
    public static string KEY_ANIM_EVENT_FUNCTION = "AnimKey";

    public Action<string> OnAnimKey;
    public void AnimKey(string key)
    {
        if (OnAnimKey != null) OnAnimKey(key);
    }
}
