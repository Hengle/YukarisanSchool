using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererPos : MonoBehaviour
{
    public LineRendererController lineRendererCtrl_ = default;
    public Collider col_ = default;
    public RectTransform rectTransform_ = default;

    private void Awake()
    {
        col_ = GetComponent<Collider>();
        col_.isTrigger = true;
    }

    private void OnMouseEnter()
    {
        Debug.Log("anchoredPosition;" + rectTransform_.anchoredPosition);
    }

    private void OnMouseDrag()
    {
        if (lineRendererCtrl_.isEditMode_)
        {
            rectTransform_.anchoredPosition = Input.mousePosition;
        }
    }
}
