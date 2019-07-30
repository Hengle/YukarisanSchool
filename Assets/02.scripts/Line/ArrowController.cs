using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject objArrow = default;
    private Dictionary<string, ArrowRendererController> dicArrow_ = new Dictionary<string, ArrowRendererController>();

    /// <param name="id_">아이디</param>
    /// <param name="Vec2">좌표</param>
    /// <param name="round">각</param>
    /// <param name="color">선의 색</param>
    public void SetArrow(string id, Vector2 Vec2, float round, Color32 color)
    {
        GameObject obj;
        if (!dicArrow_.ContainsKey(id))
        {
            obj = Instantiate(objArrow, transform);
            dicArrow_[id] = obj.GetComponent<ArrowRendererController>();
        }

        dicArrow_[id].SetArrows(Vec2, round, color);
    }

    /// <param name="id_">아이디</param>
    /// <param name="Vec2">칼라</param>
    public void AddTweenColorArrows(string id, Color32 color32, float duration)
    {
        dicArrow_[id].AddTweenColorArrows(color32, duration);
    }

    /// <param name="id_">아이디</param>
    /// <param name="Vec2">좌표</param>
    /// <param name="round">각</param>
    public void AddTweenPositionArrows(string id, Vector2 Vec2, float round, float duration)
    {
        dicArrow_[id].AddTweenPositionArrows(Vec2, round, duration);
    }

    /// <param name="id_">아이디</param>
    public void PlayTweenArrows(string id)
    {
        dicArrow_[id].PlayTweenAnimation();
    }

    public void ClearAllArrows()
    {
        foreach (KeyValuePair<string, ArrowRendererController> keyValuePair in dicArrow_)
        {
            Destroy(keyValuePair.Value.gameObject);
        }
        dicArrow_.Clear();
    }
}
