using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using System;
using Def.Enum;     

public class CustomCommand : AdvCustomCommandManager
{
    private enumCustomCommand customCommand;

    public override void OnBootInit()
    {
        Utage.AdvCommandParser.OnCreateCustomCommandFromID += CreateCustomCommand;
    }

    //AdvEnginのクリア処理のときに呼ばれる
    public override void OnClear()
    {
    }

    //カスタムコマンドの作成用コールバック
    public void CreateCustomCommand(string id, StringGridRow row, AdvSettingDataManager dataManager, ref AdvCommand command)
    {
        if (Enum.TryParse(id, out customCommand))
        {
            switch (customCommand)
            {
                case enumCustomCommand.SetLines:
                    command = new AdvCommandSetLines(row);
                    break;

                case enumCustomCommand.SetTweenColorLines:
                    command = new AdvCommandSetTweenColorLines(row);
                    break;

                case enumCustomCommand.SetTweenPositionLines:
                    Debug.Log(enumCustomCommand.SetTweenPositionLines);
                    break;

                case enumCustomCommand.AddTweenColorLines:
                    Debug.Log(enumCustomCommand.AddTweenColorLines);
                    break;

                case enumCustomCommand.AddTweenPositionLines:
                    Debug.Log(enumCustomCommand.AddTweenPositionLines);
                    break;

                case enumCustomCommand.PlayTweenLines:
                    Debug.Log(enumCustomCommand.PlayTweenLines);
                    break;
            }
        }        
    }
}

public class AdvCommandSetLines : AdvCommand
{
    string id;

    public AdvCommandSetLines(StringGridRow row) : base(row)
    {
        id = ParseCell<string>(AdvColumnName.Arg1);
    }

    public override void DoCommand(AdvEngine engine)
    {
        Debug.Log("선 준비:" + id);
    }
}

public class AdvCommandSetTweenColorLines : AdvCommand
{
    string id;

    public AdvCommandSetTweenColorLines(StringGridRow row) : base(row)
    {
        id = ParseCell<string>(AdvColumnName.Arg1);
    }

    public override void DoCommand(AdvEngine engine)
    {
        Debug.Log("TweenColor:" + id);
    }
}
