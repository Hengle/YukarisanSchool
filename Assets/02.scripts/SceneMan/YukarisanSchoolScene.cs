using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class YukarisanSchoolScene : SceneBase
{
    [SerializeField] private AdvEngine advEngine_ = default;

    public override IEnumerator Initiate()
    {
        yield return StartCoroutine(base.Initiate());
    }

    public override IEnumerator LoadData()
    {
        yield return StartCoroutine(base.LoadData());
    }

    public override IEnumerator SetByLoadedData()
    {
        yield return StartCoroutine(base.SetByLoadedData());
    }

    public override IEnumerator SetComponents()
    {
        yield return StartCoroutine(base.SetComponents());
        Managers.ins_.schoolMan_.advEngine_ = advEngine_;
    }

    public override IEnumerator GetReady()
    {
        yield return StartCoroutine(base.GetReady());
        Managers.ins_.schoolMan_.advEngine_
    }

}
