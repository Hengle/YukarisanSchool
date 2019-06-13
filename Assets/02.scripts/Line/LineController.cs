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
    /// <param name="fadeType">페이드 유형</param>
    /// <param name="pos1">좌표 1</param>
    /// <param name="pos2">좌표 1</param>
    public void DrawLine(string id_, string fadeType, Vector2 pos1, Vector2 pos2, Action onDone)
    {      
        dicLine_[id_].DrawLines(fadeType, pos1, pos2, onDone);
    }

    /// <summary> 선을 준비한다.</summary>
    /// <param name="id_">아이디</param>
    /// <param name="time">트윈 애니메이션 시간</param>
    /// <param name="color">선의 색</param>
    ///  <param name="pos01">첫번째 점의 위치</param>
    /// <param name="pos02">두번째 점의 위치</param>
    public void SetLines(string id, float time, Color32 color, Vector2 pos01, Vector2 pos02)
    {
        GameObject line;

        //만들어 둔것이 없다면 새로 만들어서 이용한다. 
        if (!dicLine_.ContainsKey(id))
        {
            line = Instantiate(lineBase, transform);
            dicLine_[id] = line.GetComponent<LineRenderController>();
        }
        dicLine_[id].SetLines(time, color, pos01, pos02);
    }

    public void CleanAllLine()
    {
        Debug.Log("모든 선을 삭제한다");
        foreach (KeyValuePair<string, LineRenderController> keyValuePair in dicLine_)
        {
            Destroy(keyValuePair.Value.gameObject);
        }
        dicLine_.Clear();
    }
}
