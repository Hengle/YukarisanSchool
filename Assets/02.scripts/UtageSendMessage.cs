using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using System;
using Def.Enum;
using System.Linq;

public class UtageSendMessage : MonoBehaviour
{
    public LineController lineController_;
         
    public LineRenderController lineRenderController_;
    private enumCustomCommand enumUtageSendMessage_;
    private bool isWaite_ = true;

    //SendMessageコマンドが実行されたタイミング
    private void OnDoCommand(AdvCommandSendMessage command)
    {
        Enum.TryParse(command.Name, out enumUtageSendMessage_);
        string lineId = string.Empty;
        string fadeType = string.Empty;
        float tweenTime = 0f;
        Color32 color32; 
        Vector2 pos01;
        Vector2 pos02;
        isWaite_ = true;
        
        switch (enumUtageSendMessage_)
        {
            case enumCustomCommand.UnityFadeIn:
                StartCoroutine(FadeMan.ins_.FadeInOut(enumFadeType.FadeIn, float.Parse(command.Arg2), () => { isWaite_ = false; }));
                break;

            case enumCustomCommand.UnityFadeOut:
                StartCoroutine(FadeMan.ins_.FadeInOut(enumFadeType.FadeOut, float.Parse(command.Arg2), () => { isWaite_ = false; }));
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
            case enumCustomCommand.UnityFadeIn:
                command.IsWait = isWaite_;
                break;
            case enumCustomCommand.UnityFadeOut:
                command.IsWait = isWaite_;
                break;

            default:
                Debug.Log("<color=red>존재하지 않는 메소드:" + command.Name + "</color>");
                command.IsWait = false;
                break;
        }       
    }

    /// <summary> 두 점을 이동이켜 선을 만든다.</summary>
    /// <param name="id">통제용 아이디</param>
    /// <param name="pos01">첫번째 점의 위치</param>
    /// <param name="pos02">두번째 점의 위치</param>
    private void DrawLines(string id, string fadeType, Vector2 pos01, Vector2 pos02)
    {
        lineController_.TweenLine(id, fadeType, pos01, pos02, () => { isWaite_ = false; });
    }

    /// <summary> 두 점을 준비한다.</summary>
    /// <param name="id">통제용 아이디</param>
    /// <param name="time">트윈 시간</param>
    /// <param name="color">선의 색</param>
    /// <param name="pos01">첫번째 점의 위치</param>
    /// <param name="pos02">두번째 점의 위치</param>
    private void SetLines(string id, float time, Color32 color, Vector2 pos01, Vector2 pos02)
    {
       
    }


    /// <summary>string에서 color32로</summary>
    /// <param name="str">string</param>
    private Color32 ConvertStringToColor32(string str)
    {
        string[] strColor;
        byte[] byteColor = new byte[4];
        Color32 color;

        str = str.Replace("(", string.Empty);
        str = str.Replace(")", string.Empty);
        strColor = str.Split(',');

        for (int index = 0; index < strColor.Length; index++) 
        {
            byteColor[index] = byte.Parse(strColor[index]);
        }

        return color = new Color32(byteColor[0], byteColor[1], byteColor[2], byteColor[3]);
    }


    private void ConvertStringToVec2(string str, out Vector2 pos01, out Vector2 pos02)
    {
        string[] pos;
        str = str.Replace("(", string.Empty);
        str = str.Replace(")", string.Empty);
        pos = str.Split('/');
        pos01 = new Vector2(float.Parse(pos[0].Split(',')[0]), float.Parse(pos[0].Split(',')[1]));
        pos02 = new Vector2(float.Parse(pos[1].Split(',')[0]), float.Parse(pos[1].Split(',')[1]));
    }
}
