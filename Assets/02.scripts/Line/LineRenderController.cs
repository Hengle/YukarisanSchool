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
    private Color baseColor_ = default;
    private Color targetColor_ = default;
    private enumFadeType enumFade;


    private void Awake()
    {
        mat_ = lineRenderer_.material;
    }

    public void Update()
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

    public void DrawLines(string fadeType, Vector2 pos01, Vector2 pos02, Action onDone )
    {
        //투명화를 위한 임시 color
        Color tmpColor = mat_.color;

        Enum.TryParse(fadeType, out enumFade);

        Sequence sequence;
        sequence = DOTween.Sequence();
        sequence.OnStart( () => listPos_[0].DOAnchorPos(pos01, time_));    
        sequence.Join(listPos_[1].DOAnchorPos(pos02, time_));
        switch (enumFade)
        {
            case enumFadeType.None:
                break;

            case enumFadeType.FadeIn:
                mat_.color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, 0);
                sequence.Join(mat_.DOColor(tmpColor, time_));
                break;
            case enumFadeType.FadeOut:
                tmpColor.a = 0f;
                sequence.Join(mat_.DOColor(tmpColor, time_));
                break;
        }
        sequence.OnComplete(() => { onDone?.Invoke(); });        
    }

    public void SetLines(float time, Color32 color32, Vector2 pos01, Vector2 pos02)
    {
        time_ = time;
        targetColor_ = color32;
        mat_.color = color32;

        listPos_[0].anchoredPosition = pos01;
        listPos_[1].anchoredPosition = pos02;
    }
}
