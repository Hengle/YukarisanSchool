using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LineController : MonoBehaviour
{
    public GameObject lineBase = default;
    private List<Vector2> listVec2 = default;
    //    public Transform lineParent = default;

    private Dictionary<string, LineRenderController> dicLine_ = new Dictionary<string, LineRenderController>();


    public void CreateLine(string id_, Vector2 pos01, Vector2 pos02)
    {

    }



    /// <summary>선의 id를 검사하여, 이미 만들었으면 만든 선으로, 없으면 선을 만들어 이용한다. </summary>
    /// <param name="id_">선의 아이디</param>
    /// <param name="fadeType">페이드 유형</param>
    /// <param name="pos01">좌표 1</param>
    /// <param name="pos02">좌표 2</param>
    /// <param name="onDone">이 선의 트윈 애니메이션이 끝났을 때 할 일</param>
    public void TweenLine(string id_, string fadeType, Vector2 pos01, Vector2 pos02, Action onDone)
    {
        listVec2 = new List<Vector2>() { pos01, pos02 };
        dicLine_[id_].TweenLines(fadeType, listVec2, onDone);
    }

    /// <summary> 선을 준비한다.</summary>
    /// <param name="id_">아이디</param>
    /// <param name="time">트윈 애니메이션 시간</param>
    /// <param name="color">선의 색</param>
    /// <param name="pos01">좌표 1</param>
    /// <param name="pos02">좌표 2</param>
    public void SetLines(string id, float time, Color32 color, Vector2 pos01, Vector2 pos02)
    {
        GameObject line;
        listVec2 = new List<Vector2>() { pos01, pos02 };

        //만들어 둔것이 없다면 새로 만들어서 이용한다. 
        if (!dicLine_.ContainsKey(id))
        {
            line = Instantiate(lineBase, transform);
            dicLine_[id] = line.GetComponent<LineRenderController>();
        }
        dicLine_[id].SetLines(time, color, listVec2);
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
