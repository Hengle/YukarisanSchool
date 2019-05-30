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
        Debug.Log("<color=yellow>" + name + ":Initiate" + "</color>");
        yield return StartCoroutine(LoadData());
        yield return StartCoroutine(SetByLoadedData());
        yield return FadeMan.ins_.FadeInOut(enumFadeType.FadeIn, fadeTime_, OnFadeInDone);        
    }

    /// <summary>데이터 로드</summary>
    public override IEnumerator LoadData()
    {
        Debug.Log("<color=yellow>" + name + ":LoadData" + "</color>");
        yield return null;
    }

    /// <summary> 로드한 데이터를 이용해 세팅</summary>
    public override IEnumerator SetByLoadedData()
    {
        Debug.Log("<color=yellow>" + name + ":SetByLoadedData" + "</color>");
        yield return null;
    }

    public override IEnumerator SetVariable()
    {
        yield return null;
    }

    public override IEnumerator GetReady()
    {
        yield return null;
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
