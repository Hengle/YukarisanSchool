using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LineController : MonoBehaviour
{
    public GameObject objLine = default;
    public AdvCommanDataSetBase dataSet = default;   
    private List<Vector2> listVec2 = default;

    private Dictionary<string, LineRendererController> dicLine_ = new Dictionary<string, LineRendererController>();

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
            obj = Instantiate(objLine, transform);
            dicLine_[id] = obj.GetComponent<LineRendererController>();
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

    public void ClearAllLine()
    {
        Debug.Log("모든 선을 삭제한다");
        foreach (KeyValuePair<string, LineRendererController> keyValuePair in dicLine_)
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
