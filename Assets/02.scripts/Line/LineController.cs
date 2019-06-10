using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LineController : MonoBehaviour
{
    public GameObject lineBase = default;
    public Transform lineParent = default;

    Dictionary<string, LineRenderController> dicLine_ = new Dictionary<string, LineRenderController>();

    /// <summary>선의 id를 검사하여, 이미 만들었으면 만든 선으로, 없으면 선을 만들어 이용한다. </summary>
    /// <param name="id_">선의 아이디</param>
    /// <param name="time">트윈 애니메이션 시간</param>
    /// <param name="fadeType">페이드 유형</param>
    /// <param name="pos1">좌표 1</param>
    /// <param name="pos2">좌표 1</param>
    public void DrawLine(string id_,Vector2 pos1, Vector2 pos2, Action onDone)
    {      
        dicLine_[id_].DrawLines(pos1, pos2, onDone);
    }

    /// <summary>
    /// 선을 준비한다.
    /// </summary>
    /// <param name="id_">아이디</param>
    /// <param name="time">트윈 애니메이션 시간</param>
    /// <param name="color">선의 색</param>
    public void SetLines(string id_, float time, string fadeType, Color color)
    {
        GameObject line;

        //만들어 둔것이 없다면 새로 만들어서 이용한다. 
        if (!dicLine_.ContainsKey(id_))
        {
            line = Instantiate(lineBase, transform);
            dicLine_[id_] = line.GetComponent<LineRenderController>();
        }
    }

    public void CleanAllLine()
    {
        foreach (KeyValuePair<string, LineRenderController> keyValuePair in dicLine_)
        {
            Destroy(keyValuePair.Value);
        }
        dicLine_.Clear();
    }
}
