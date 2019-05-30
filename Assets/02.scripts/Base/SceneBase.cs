using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Def.Enum;
using UnityEngine.SceneManagement;

public class SceneBase : CommonBase
{
    public string nowScene_;
    protected float fadeTime_ = 1f;

    /// <summary> 초기화 시작</summary>
    public override  IEnumerator Initiate()
    {
        yield return StartCoroutine(base.Initiate());
        yield return FadeMan.ins_.FadeInOut(enumFadeType.FadeIn, fadeTime_, OnFadeInDone);        
    }

    /// <summary>데이터 로드</summary>
    public override IEnumerator LoadData()
    {
        yield return StartCoroutine(base.LoadData());
    }

    /// <summary> 로드한 데이터를 이용해 세팅</summary>
    public override IEnumerator SetByLoadedData()
    {
        yield return StartCoroutine(base.SetByLoadedData());
    }

    public override IEnumerator SetComponents()
    {
        yield return StartCoroutine(base.SetComponents());
    }

    public override IEnumerator GetReady()
    {
        yield return StartCoroutine(base.GetReady());
    }

    public virtual void OnFadeOutDone()
    {
        Debug.Log("<color=yellow>" + name + ":OnFadeOutDone" + "</color>");
    }

    public virtual void OnFadeInDone()
    {
        Debug.Log("<color=yellow>" + name + ":OnFadeInDone" + "</color>");
    }



}
