using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
     

public class LineRenderController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer_ = default;
    [SerializeField] private List<RectTransform> listPos_ = default;
    public bool isEditMode_ = false;
    public float width_ = 0.2f;

    
    private void LateUpdate()
    {
        SetLineRenderer();
    }


    public void SetLineRenderer()
    {
        lineRenderer_.startWidth = width_; 
        lineRenderer_.endWidth = width_;

        for (int index = 0; index < listPos_.Count; index++)
        {
            lineRenderer_.SetPosition(index, listPos_[index].position);
        }
    }

    public void TwennLines(Vector2 pos01, Vector2 pos02, float time, Action onDone )
    {

        listPos_[0].DOAnchorPos(pos01, time).OnComplete(() => {
            onDone?.Invoke();
        });

        listPos_[1].DOAnchorPos(pos02, time).OnComplete(() => {
            onDone?.Invoke();
        });

        /*
        listPos_[0].DOMove(pos01, time).OnComplete( () => {
            onDone?.Invoke();
        });
        */

    }

}
