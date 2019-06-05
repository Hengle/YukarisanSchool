using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using System;
using Def.Enum;

public class UtageSendMessage : MonoBehaviour
{
    public LineRenderController lineRenderController_;
    private enumUtageSendMessage enumUtageSendMessage_;
    private bool isDone_ = false;

    //SendMessageコマンドが実行されたタイミング
    private void OnDoCommand(AdvCommandSendMessage command)
    {
        Enum.TryParse(command.Name, out enumUtageSendMessage_);
        isDone_ = false;

        switch (enumUtageSendMessage_)
        {
            case enumUtageSendMessage.UnityFadeIn:
                StartCoroutine(FadeMan.ins_.FadeInOut(enumFadeType.FadeIn, float.Parse(command.Arg2), () => { isDone_ = true; }));
                break;
            case enumUtageSendMessage.UnityFadeOut:
                StartCoroutine(FadeMan.ins_.FadeInOut(enumFadeType.FadeOut, float.Parse(command.Arg2), () => { isDone_ = true; }));
                break;

            case enumUtageSendMessage.UnityTweenLines:
                Vector2 pos01;
                Vector2 pos02;
                float tweenTime;
                string tmp = string.Empty;

                pos01 = ConvertStringToVec2(command.Arg2);
                pos02 = ConvertStringToVec2(command.Arg3);
                tweenTime = float.Parse(command.Arg4);

                TweenLines(pos01, pos02, tweenTime);

                break;

            default:
                Debug.Log("<color=red>존재하지 않는 메소드:" + command.Name + "</color>");
                break;
        }
    }

    //SendMessageコマンドの処理待ちタイミング
    private void OnWait(AdvCommandSendMessage command)
    {
        Enum.TryParse(command.Name, out enumUtageSendMessage_);
        switch (enumUtageSendMessage_)
        {
            case enumUtageSendMessage.UnityFadeIn:
                command.IsWait = isDone_;
                break;
            case enumUtageSendMessage.UnityFadeOut:
                command.IsWait = isDone_;
                break;

            case enumUtageSendMessage.UnityTweenLines:
                command.IsWait = isDone_;
                break;

            default:
                Debug.Log("<color=red>존재하지 않는 메소드:" + command.Name + "</color>");
                command.IsWait = false;
                break;
        }       
    }

    /// <summary> 두 점을 이동이켜 선을 만든다.</summary>
    /// <param name="pos01">첫번째 점의 위치</param>
    /// <param name="pos02">두번째 점의 위치</param>
    /// <param name="time">트윈 시간</param>
    private void TweenLines(Vector2 pos01, Vector2 pos02, float time)
    {
        lineRenderController_.TwennLines(pos01, pos02, time, () => { isDone_ = true; });
    }

    private Vector2 ConvertStringToVec2(string str)
    {
        if (str.StartsWith("(") && str.EndsWith(")"))
        {
            str = str.Remove(0, 1);
            str = str.Remove(str.ToCharArray().Length - 1);
        }
        return new Vector2(float.Parse(str.Split(',')[0]), float.Parse(str.Split(',')[1]));
    }
}
