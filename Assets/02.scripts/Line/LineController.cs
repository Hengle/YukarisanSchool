using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LineController : MonoBehaviour
{
    public GameObject objToDraw = default;
    public AdvCommanDataSetBase dataSet = default;   
    private List<Vector2> listVec2 = default;

    private Dictionary<string, LineRenderController> dicLine_ = new Dictionary<string, LineRenderController>();

    private void Awake()
    {
        dataSet = new AdvCommanDataSetBase();
    }

    /// <summary> 선을 준비한다.</summary>
    /// <param name="id_">아이디</param>
    /// <param name="listVec2">좌표</param>
    /// <param name="color">선의 색</param>
    public void SetLines(string id, List<Vector2> listVec2, Color32 color)
    {
        GameObject obj;

        //만들어 둔것이 없다면 새로 만들어서 이용한다. 
        if (!dicLine_.ContainsKey(id))
        {
            obj = Instantiate(objToDraw, transform);
            dicLine_[id] = obj.GetComponent<LineRenderController>();
        }
        dicLine_[id].SetLines(listVec2, color);
    }

    /// <summary> 선의 트윈애니메이션을 추가</summary>
    public void AddTweenPositionLines(string id, List<Vector2> listVec2, float duration)
    {        
        if (!dicLine_.ContainsKey(id))
        {
            Debug.Log("MissingNo.:" + id);
        }

        else
        {
            dicLine_[id].AddTweenPositionLines(listVec2, duration);
        }
    }

    /// <summary> 선의 트윈애니메이션을 추가</summary>
    public void AddTweenColorLines(string id, Color32 color32, float duration)
    {
        if (!dicLine_.ContainsKey(id))
        {
            Debug.Log("MissingNo.:" + id);
        }

        else
        {
            dicLine_[id].AddTweenColorLines(color32, duration);
        }
    }

    /// <summary>트윈 애니메이션 재생</summary>
    /// <param name="id"></param>
    public void PlayTweenLines(string id)
    {
        if (!dicLine_.ContainsKey(id))
        {
            Debug.Log("MissingNo.:" + id);
        }

        else
        {
            dicLine_[id].PlayTweenAnimation();
        }
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

public class AdvCommanDataSetBase
{
    public string id;
    public List<Vector2> listVec2;
    public Color32 color32;

    public AdvCommanDataSetBase()
    {
        id = string.Empty;
        listVec2 = new List<Vector2>();
        color32 = new Color32();
    }
}
