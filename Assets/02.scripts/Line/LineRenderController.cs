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

    public float time_ = 0f;
    private Color color_ = default;
    private enumFadeType enumFade;


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

    public void DrawLines(Vector2 pos01, Vector2 pos02, Action onDone )
    {

        Color tmpColor = color_;
        tmpColor.a = 0;

        Sequence sequence;
        sequence = DOTween.Sequence();
        sequence.OnStart( () => listPos_[0].DOAnchorPos(pos01, time_));

        switch (enumFade)
        {
            case enumFadeType.None:
                break;

            case enumFadeType.FadeIn:
                sequence.Join( mat_.DOColor(color_, time_));
                break;

            case enumFadeType.FadeOut:
                sequence.Join(mat_.DOColor(tmpColor, time_));
                break;
        }

        sequence.Join(listPos_[1].DOAnchorPos(pos02, time_));
        sequence.OnComplete(() => { onDone?.Invoke(); });        
    }

    public void SetLines(float time, string fade, )
    {
        time_ = time;
        Enum.TryParse(fade, out enumFade);
    }


}
