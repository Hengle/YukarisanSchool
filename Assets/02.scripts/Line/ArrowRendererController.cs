using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ArrowRendererController : MonoBehaviour
{
    [SerializeField] private Text txt = default;
    public bool isEditMode_ = false;

    private Sequence seqPosition_ = default;
    private Sequence seqColor_ = default;

    public void SetArrows(Vector2 Vec2, float round,Color32 color32)
    {
        txt.color = color32;

        ((RectTransform)transform).anchoredPosition = Vec2;
        //        ((RectTransform)transform).localRotation.eulerAngles.Set(0,0, round);
        ((RectTransform)transform).localRotation = Quaternion.Euler(0, 0, round);
    }

    /// <summary> 트윈 애니메이션을 추가한다.</summary>
    public void AddTweenPositionArrows(Vector2 Vec2Target, float round, float duration)
    {
        seqPosition_.Append(((RectTransform)transform).DOAnchorPos(Vec2Target, duration));
        seqPosition_.Join(((RectTransform)transform).DOLocalRotate(new Vector3(0, 0, round), duration, RotateMode.FastBeyond360));
    }

    /// <summary> 트윈 애니메이션을 추가한다.</summary>
    public void AddTweenColorArrows(Color32 color32, float duration)
    {
        seqColor_.Append(txt.DOColor(color32, duration));
    }

    public void PlayTweenAnimation()
    {
        if (seqPosition_ != null)
            seqPosition_.Play();

        if (seqColor_ != null)
            seqColor_.Play();
    }


    private void OnMouseDrag()
    {
        if (isEditMode_)
        {
            ((RectTransform)transform).anchoredPosition = Input.mousePosition;
        }
    }
}
