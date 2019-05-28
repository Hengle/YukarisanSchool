using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class SchoolMan : CommonBase
{
    [SerializeField] private TitleMan titleMan_ = default;
    [SerializeField] private TitleMan ClassMan_ = default;
    [SerializeField] private AdvEngineStarter advEngineStarter_ = default;


    private void Awake()
    {
        
    }

    public override void LoadData()
    {
        base.LoadData();
    }

    public override void SetByLoadedData()
    {
        base.SetByLoadedData();
    }

    public override void Initiate()
    {
        base.Initiate();
    }


}
