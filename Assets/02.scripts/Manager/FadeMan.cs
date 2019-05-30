using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Def.Enum;

public class FadeMan : MonoBehaviour
{
    public CanvasGroup cg_ = default;
    public static FadeMan ins_ = default;

    private bool isProcessing_ = false;

    private void Awake()
    {
        ins_ = this;
    }

    /// <summary>페이드인, 아웃 처리</summary>
    /// <param name="enumFade"></param>
    /// <param name="time"></param>
    /// <param name="onDone"></param>
    /// <returns></returns>
    public IEnumerator FadeInOut(enumFadeType enumFade, float time, Action onDone = null)
    {
        if (isProcessing_)
        {
            Debug.Log("<color=red>이미 페이드 처리중</color>");
            yield break;               
        }

        Debug.Log("<color=yellow>페이드 시작</color>");
        isProcessing_ = true;
        yield return StartCoroutine(Process(enumFade, time));
        isProcessing_ = false;
        Debug.Log("<color=green>페이드 완료</color>");

        onDone?.Invoke();
    }

    private IEnumerator Process(enumFadeType enumFade, float time)
    {
        cg_.blocksRaycasts = true;
        if (time <= 0)
        {
            Debug.LogWarning("<color=red>페이드 시간은 0보다 큰 양수여야합니다.</color>");
            switch (enumFade)
            {
                case enumFadeType.FadeIn: cg_.alpha = 0f; break;
                case enumFadeType.FadeOut: cg_.alpha = 1f; break;
            }
            yield break;
        }

        float calAlpha = cg_.alpha;

        while (calAlpha >= 0f || calAlpha <= 1f)
        {
            switch (enumFade)
            {
                case enumFadeType.FadeIn:
                    calAlpha -= Time.fixedDeltaTime / time;
                    break;

                case enumFadeType.FadeOut:
                    calAlpha += Time.fixedDeltaTime / time;
                    break;
            }

            if (calAlpha < 0f)
            {
                cg_.alpha = 0f;
                cg_.blocksRaycasts = false;
                yield break;
            }

            else if (calAlpha > 1f)
            {
                cg_.alpha = 1f;
                yield break;
            }

            else
            {
                cg_.alpha = calAlpha;
            }

            yield return null;
        }
    }

}
