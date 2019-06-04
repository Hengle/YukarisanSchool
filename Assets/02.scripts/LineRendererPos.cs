using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererPos : MonoBehaviour
{
    public LineRenderController lineRendererCtrl_ = default;
    public Collider col_ = default;
    public RectTransform rectTransform_ = default;

    private void Awake()
    {
        col_ = GetComponent<Collider>();
        col_.isTrigger = true;
    }

    private void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter()");
    }

    private void OnMouseDrag()
    {
        Debug.Log("anchoredPosition;" + rectTransform_.anchoredPosition);
        Debug.Log("마우스:" + Input.mousePosition);
        rectTransform_.anchoredPosition = Input.mousePosition;


    }
}
