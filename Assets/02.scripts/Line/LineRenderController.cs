using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Def.Enum;
     

public class LineRenderController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer_ = default;
    [SerializeField] private List<RectTransform> listPos_ = default;
    [SerializeField] private Material mat_ = default;

    public bool isEditMode_ = false;
    public float width_ = 0.2f;


    private Color color_ = default;

    private void Awake()
    {
        mat_ = lineRenderer_.material;
        color_ = mat_.color;
    }

    public void Update()
    {
        SetLineRenderer();
    }

    private void LateUpdate()
    {
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

    public void DrawLines(float time, string fade, Vector2 pos01, Vector2 pos02, Action onDone )
    {
        enumFadeType enumFade;
        Enum.TryParse(fade, out enumFade);
        Color tmpColor = color_;
        tmpColor.a = 0;

        Sequence sequence;
        sequence = DOTween.Sequence();
        sequence.OnStart( () => listPos_[0].DOAnchorPos(pos01, time));

        switch (enumFade)
        {
            case enumFadeType.None:
                break;

            case enumFadeType.FadeIn:
                sequence.Join( mat_.DOColor(color_, time));
                break;

            case enumFadeType.FadeOut:
                sequence.Join(mat_.DOColor(tmpColor, time));
                break;
        }

        sequence.Join(listPos_[1].DOAnchorPos(pos02, time));

        sequence.OnComplete(() => { onDone?.Invoke(); });

        /*

        listPos_[0].DOAnchorPos(pos01, time).OnComplete(() => {
            onDone?.Invoke();
        });

        listPos_[1].DOAnchorPos(pos02, time).OnComplete(() => {
            onDone?.Invoke();
        });
        */
    }

}
