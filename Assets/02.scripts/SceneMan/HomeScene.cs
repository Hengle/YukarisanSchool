using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Def.Enum;


public class HomeScene : SceneBase
{

    public override IEnumerator LoadData()
    {
        return base.LoadData();
    }

    public override IEnumerator Initiate()
    {
        return base.Initiate();
    }

    public override void OnFadeInDone()
    {
        base.OnFadeInDone();
        Invoke("GotoSchool", 3f);
    }

    private void GotoSchool()
    {
        StartCoroutine(FadeMan.ins_.FadeInOut(enumFadeType.FadeOut, fadeTime_,
            () => { SceneMan.ins.PushScene(enumSceneName.YukarisanSchool, LoadSceneMode.Single); }
            ));
    }
}
