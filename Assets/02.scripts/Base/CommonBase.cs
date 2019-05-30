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
        Debug.Log("초기화시작:" + name);

        yield return StartCoroutine(LoadData());
        yield return StartCoroutine(SetByLoadedData());
        yield return StartCoroutine(SetVariable());
        yield return StartCoroutine(GetReady());
    }



    //데이터 로드
    public virtual IEnumerator LoadData()
    {
        Debug.Log("데이터 로드:" + name );
        yield return null;
    }

    //데이터 설정
    public virtual IEnumerator SetByLoadedData()
    {
        Debug.Log("데이터 설정:" + name);
        yield return null;
    }

    public virtual IEnumerator SetVariable()
    {
        Debug.Log("변수설정:" + name);
        yield return null;
    }


    public virtual IEnumerator GetReady()
    {
        Debug.Log("준비완료:" + name);
        yield return null;
    }

}
