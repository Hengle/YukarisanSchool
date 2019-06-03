using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using System;
using Def.Enum;

public class UtageSendMessage : MonoBehaviour
{
    private enumUtageSendMessage enumUtageSendMessage_;
    private bool isDone_ = false;

    //SendMessageコマンドが実行されたタイミング
    void OnDoCommand(AdvCommandSendMessage command)
    {
        Enum.TryParse(command.Name, out enumUtageSendMessage_);

        switch (enumUtageSendMessage_)
        {
            case enumUtageSendMessage.UnityFadeIn:
                StartCoroutine(FadeMan.ins_.FadeInOut(enumFadeType.FadeIn, float.Parse(command.Arg2), () => { isDone_ = true; }));
                break;
            case enumUtageSendMessage.UnityFadeOut:
                StartCoroutine(FadeMan.ins_.FadeInOut(enumFadeType.FadeOut, float.Parse(command.Arg2), () => { isDone_ = true; }));
                break;

            default:
                Debug.Log("<color=red>존재하지 않는 메소드:" + command.Name + "</color>");
                break;
        }
    }

    //SendMessageコマンドの処理待ちタイミング
    void OnWait(AdvCommandSendMessage command)
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

            default:
                Debug.Log("<color=red>존재하지 않는 메소드:" + command.Name + "</color>");
                command.IsWait = false;
                break;
        }
       
    }

}
