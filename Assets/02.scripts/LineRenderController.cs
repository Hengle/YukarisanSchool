using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer_ = default;
    [SerializeField] private List<Transform> listPos_ = default;
    public bool isEditMode_ = false;
    public float width_ = 0.2f;

    private void Awake()
    {
        foreach (Transform tr in listPos_)
        {
            tr.gameObject.GetComponent<LineRendererPos>().lineRendererCtrl_ = this;
        }
    }

    private void LateUpdate()
    {
        SetLineRender();
    }


    public void SetLineRender()
    {
        lineRenderer_.startWidth = width_; 
        lineRenderer_.endWidth = width_;


        for (int index = 0; index < listPos_.Count; index++)
        {
            lineRenderer_.SetPosition(index, listPos_[index].position);
        }
    }

}
