using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBase : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Initiate());
    }

    //초기화
    public virtual IEnumerator Initiate()
    {
        Debug.Log("<color=yellow>" + name + ":Initiate" + "</color>");

        yield return StartCoroutine(LoadData());
        yield return StartCoroutine(SetByLoadedData());
        yield return StartCoroutine(SetComponents());
        yield return StartCoroutine(GetReady());
    }

    //데이터 로드
    public virtual IEnumerator LoadData()
    {
        Debug.Log("<color=yellow>" + name + ":LoadData" + "</color>");
        yield return null;
    }

    //데이터 설정
    public virtual IEnumerator SetByLoadedData()
    {
        Debug.Log("<color=yellow>" + name + ":SetByLoadedData" + "</color>");
        yield return null;
    }

    public virtual IEnumerator SetComponents()
    {
        Debug.Log("<color=yellow>" + name + ":SetComponents" + "</color>");
        yield return null;
    }

    public virtual IEnumerator GetReady()
    {
        Debug.Log("<color=Green>" + name + ":GetReady" + "</color>");
        yield return null;
    }

}
