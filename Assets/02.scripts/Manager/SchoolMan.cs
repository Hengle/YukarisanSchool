using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using Def.Enum;

public class SchoolMan : UguiView
{
    public AdvEngine advEngine_ = default;

    //ロードするセーブデータ
    protected AdvSaveData loadData;

    protected bool isInit = false;


    /// <summary>起動するシナリオラベル</summary>
    protected string scenarioLabel;

    //起動タイプ
    protected enum BootType
    {
        Default,
        Start,
        Load,
        SceneGallery,
        StartLabel,
    };
    protected BootType bootType;

    public void StartEngine()
    {
        Debug.Log("시작");
        advEngine_.StartGame();
    }

    /// <summary>
    /// 画面を閉じる
    /// </summary>
    public override void Close()
    {
        base.Close();
        advEngine_.UiManager.Close();
        advEngine_.Config.IsSkip = false;
    }

    //起動データをクリア
    protected virtual void ClearBootData()
    {
        bootType = BootType.Default;
        isInit = false;
        loadData = null;
    }

    /// <summary>
    /// ゲームをはじめから開始
    /// </summary>
    public virtual void OpenStartGame()
    {
        ClearBootData();
        bootType = BootType.Start;
        Open();
    }

    /// <summary>
	/// 指定ラベルからゲーム開始
	/// </summary>
	public virtual void OpenStartLabel(string label)
    {
        ClearBootData();
        bootType = BootType.StartLabel;
        this.scenarioLabel = label;
        Open();
    }

    /// <summary>
    /// セーブデータをロードしてゲーム再開
    /// </summary>
    /// <param name="loadData">ロードするセーブデータ</param>
    public virtual void OpenLoadGame(AdvSaveData loadData)
    {
        ClearBootData();
        bootType = BootType.Load;
        this.loadData = loadData;
        Open();
    }

    /// <summary>
    /// シーン回想としてシーンを開始
    /// </summary>
    /// <param name="scenarioLabel">シーンラベル</param>
    public virtual void OpenSceneGallery(string scenarioLabel)
    {
        ClearBootData();
        bootType = BootType.SceneGallery;
        this.scenarioLabel = scenarioLabel;
        Open();
    }


    /// <summary>
	/// オープンしたときに呼ばれる
	/// </summary>
	protected virtual void OnOpen()
    {
        //スクショをクリア
        if (advEngine_.SaveManager.Type != AdvSaveManager.SaveType.SavePoint)
        {
            advEngine_.SaveManager.ClearCaptureTexture();
        }
        StartCoroutine(CoWaitOpen());
    }


    //起動待ちしてから開く
    protected virtual IEnumerator CoWaitOpen()
    {
        while (advEngine_.IsWaitBootLoading) yield return null;

        switch (bootType)
        {
            case BootType.Default:
                advEngine_.UiManager.Open();
                break;
            case BootType.Start:
                advEngine_.StartGame();
                break;
            case BootType.Load:
                advEngine_.OpenLoadGame(loadData);
                break;
            case BootType.SceneGallery:
                advEngine_.StartSceneGallery(scenarioLabel);
                break;
            case BootType.StartLabel:
                advEngine_.StartGame(scenarioLabel);
                break;
        }
        ClearBootData();
        loadData = null;
        advEngine_.Config.IsSkip = false;
        isInit = true;
    }



    private void LateUpdate()
    {
        if (!isInit) return;

        //ローディングアイコンを表示
        if (SystemUi.GetInstance())
        {
            if (advEngine_.IsLoading)
            {
                SystemUi.GetInstance().StartIndicator(this);
            }
            else
            {
                SystemUi.GetInstance().StopIndicator(this);
            }
        }


        if (advEngine_.IsEndScenario)
        {
            StartCoroutine(FadeMan.ins_.FadeInOut(enumFadeType.FadeOut, 2.0f, () => {
                //                Close();


                advEngine_.StartGame();
                FadeMan.ins_.FadeInOut(enumFadeType.FadeIn, 2.0f);
            }));
            
            //シナリオ終了したのでタイトルへ
            //            title.Open(this);


        }
    }
}
    
