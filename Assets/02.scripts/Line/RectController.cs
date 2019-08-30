using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectController : MonoBehaviour
{
    public GameObject rectBase = default;
    public AdvCommanDataSetBase dataSet = default;
    private Dictionary<string, LineRendererController> dicRect_ = new Dictionary<string, LineRendererController>();

    private void Awake()
    {
        dataSet = new AdvCommanDataSetBase();
    }


    public void SetRect(string id, List<Vector2> listVec2, Color32 color)
    {
        GameObject obj;

        //만들어 둔것이 없다면 새로 만들어서 이용한다. 
        if (!dicRect_.ContainsKey(id))
        {
            obj = Instantiate(rectBase, transform);
            dicRect_[id] = obj.GetComponent<LineRendererController>();
        }

        List<Vector2> listvec = new List<Vector2>();

        listvec.Add(listVec2[0]);
        listvec.Add(new Vector2(listVec2[1].x, listVec2[0].y));
        listvec.Add(listVec2[1]);
        listvec.Add(new Vector2(listVec2[0].x, listVec2[1].y));

        dicRect_[id].SetLines(listvec, color);

    }

    /// <summary> 선의 트윈애니메이션을 추가</summary>
    public void AddTweenPositionLines(string id, List<Vector2> listVec2, float duration)
    {
        if (!dicRect_.ContainsKey(id))
        {
            Debug.Log("MissingNo.:" + id);
        }

        else
        {
            List<Vector2> listvec = new List<Vector2>();

            listvec.Add(listVec2[0]);
            listvec.Add(new Vector2(listVec2[1].x, listVec2[0].y));
            listvec.Add(listVec2[1]);
            listvec.Add(new Vector2(listVec2[0].x, listVec2[1].y));

            dicRect_[id].AddTweenPositionLines(listvec, duration);
        }
    }

    /// <summary> 선의 트윈애니메이션을 추가</summary>
    public void AddTweenColorLines(string id, Color32 color32, float duration)
    {
        if (!dicRect_.ContainsKey(id))
        {
            Debug.Log("MissingNo.:" + id);
        }

        else
        {
            dicRect_[id].AddTweenColorLines(color32, duration);
        }
    }

    /// <summary>트윈 애니메이션 재생</summary>
    /// <param name="id"></param>
    public void PlayTweenLines(string id)
    {
        if (!dicRect_.ContainsKey(id))
        {
            Debug.Log("MissingNo.:" + id);
        }

        else
        {
            dicRect_[id].PlayTweenAnimation();
        }
    }

    public void ClearAllLine()
    {
        Debug.Log("모든 선을 삭제한다");
        foreach (KeyValuePair<string, LineRendererController> keyValuePair in dicRect_)
        {
            Destroy(keyValuePair.Value.gameObject);
        }
        dicRect_.Clear();
    }
}
