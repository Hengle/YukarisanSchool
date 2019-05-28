using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBase : MonoBehaviour
{

    //데이터 로드
    public virtual void LoadData()
    {
        Debug.Log("데이터 로드:" + name );
    }

    //데이터 설정
    public virtual void SetByLoadedData()
    {
        Debug.Log("데이터 설정:" + name);
    }

    /*
    //버튼 설정
    public virtual void SetBtns()
    {
        Debug.Log("버튼 설정:" + name);
    }*/

    //초기화
    public virtual void Initiate()
    {
        Debug.Log("초기화:" + name);
    }
     


}
