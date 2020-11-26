using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AniEventManager : MonoBehaviour
{
    private AnimatorEvent aniEvent;
    [Button]
    public void InitAniFun(Animator ani)
    {
        if (ani.gameObject.GetComponent<AnimatorEvent>() == null)
        {
            aniEvent = ani.gameObject.AddComponent<AnimatorEvent>();
        }
        aniEvent.OnAnimKey += AniFun;
    }

    private void AddAnimationEvent(AnimationClip Clip, string functionName, string Parameter, float TimePre)
    {
        AnimationEvent OnExitColliderEvent = new AnimationEvent();
        OnExitColliderEvent.functionName = functionName;
        OnExitColliderEvent.stringParameter = Parameter;
        OnExitColliderEvent.time = TimePre / 100f * Clip.length;
        Clip.AddEvent(OnExitColliderEvent);
    }

    private void Start()
    {

    }

    private void AniFun(string obj)
    {
        Debug.LogError(obj);
    }
    public Animator m_Animator;
    [Button]
    public void DoAction()
    {
        var dic = m_Animator.runtimeAnimatorController.animationClips.ToDictionary(a => a.name, a => a);
        foreach (var item in dic)
        {
            AddAnimationEvent(item.Value, AnimatorEvent.KEY_ANIM_EVENT_FUNCTION, "isGo", 0.5f);
        }
    }
}
