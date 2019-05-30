using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukarisanSchoolScene : SceneBase
{
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

         




}
