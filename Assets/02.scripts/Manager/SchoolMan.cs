using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class SchoolMan : CommonBase
{
   public AdvEngine advEngine_ = default;


    public void StartEngine()
    {
        Debug.Log("시작");
        advEngine_.StartGame();
    }
    
}
