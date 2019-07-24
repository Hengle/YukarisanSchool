using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using System;
using Def.Enum;     

public  class CustomCommand : AdvCustomCommandManager
{
    public LineController lineController;

    public static CustomCommand ins;
    private enumCustomCommand customCommand;

    public void Awake()
    {
        ins = this;
    }

    public override void OnBootInit()
    {
        Utage.AdvCommandParser.OnCreateCustomCommandFromID += CreateCustomCommand;
    }

    //AdvEnginのクリア処理のときに呼ばれる
    public override void OnClear()
    {
    }

    public Vector2 StringToVec2(string str)
    {
        string[] result;

        str = str.Replace("(", "");
        str = str.Replace(")", "");
        result = str.Split(',');

        return new Vector2(float.Parse(result[0]), float.Parse(result[1]));
    }

    public Color32 StringToColor(string str)
    {
        string[] result;
        str = str.Replace("(", "");
        str = str.Replace(")", "");
        str = str.Replace(" ", "");
        result = str.Split(',');
        return new Color32(byte.Parse(result[0]), byte.Parse(result[1]), byte.Parse(result[2]), byte.Parse(result[3]));
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
                    command = new AdvCommandAddTweenColorLines(row);
                    break;

                case enumCustomCommand.AddTweenPositionLines:
                    Debug.Log(enumCustomCommand.AddTweenPositionLines);
                    command = new AdvCommandAddTweenPositionLines(row);

                    break;

                case enumCustomCommand.PlayTweenLines:
                    Debug.Log(enumCustomCommand.PlayTweenLines);
                    command = new AdvCommandPlayTweenLines(row);
                    break;

                case enumCustomCommand.ClearAll:
                    command = new AdvCommandClearAll(row);
                    Debug.Log(enumCustomCommand.ClearAll);
                    break;
            }
        }        
    }
}

/// <summary>선을 만든다</summary>
public class AdvCommandSetLines : AdvCommand
{
    public AdvCommandSetLines(StringGridRow row) : base(row)
    {
        //Debug.Log(CustomCommand.ins.lineController.dataSet.color32);
    }

    public override void DoCommand(AdvEngine engine)
    {
        CustomCommand.ins.lineController.dataSet.id = ParseCell<string>(AdvColumnName.Arg1);
        CustomCommand.ins.lineController.dataSet.listVec2.Add(CustomCommand.ins.StringToVec2(ParseCell<string>(AdvColumnName.Arg2)));
        CustomCommand.ins.lineController.dataSet.listVec2.Add(CustomCommand.ins.StringToVec2(ParseCell<string>(AdvColumnName.Arg3)));
        CustomCommand.ins.lineController.dataSet.color32 = CustomCommand.ins.StringToColor(ParseCell<string>(AdvColumnName.Arg4));

        CustomCommand.ins.lineController.SetLines(
            CustomCommand.ins.lineController.dataSet.id,
            CustomCommand.ins.lineController.dataSet.listVec2,
            CustomCommand.ins.lineController.dataSet.color32);
    }    
}

/// <summary>트윈 애니메이션을 만든다. Position전용</summary>
public class AdvCommandAddTweenPositionLines : AdvCommand
{
    public AdvCommandAddTweenPositionLines(StringGridRow row) : base(row)
    {

    }

    public override void DoCommand(AdvEngine engine)
    {
        CustomCommand.ins.lineController.AddTweenPositionLines(
            ParseCell<string>(AdvColumnName.Arg1),
            new List<Vector2> { CustomCommand.ins.StringToVec2(ParseCell<string>(AdvColumnName.Arg2)), CustomCommand.ins.StringToVec2(ParseCell<string>(AdvColumnName.Arg3))},
            ParseCell<float>(AdvColumnName.Arg6)
            );
    }
}

/// <summary>트윈 애니메이션을 만든다. Position전용</summary>
public class AdvCommandAddTweenColorLines : AdvCommand
{
    public AdvCommandAddTweenColorLines(StringGridRow row) : base(row)
    {

    }

    public override void DoCommand(AdvEngine engine)
    {
        CustomCommand.ins.lineController.AddTweenColorLines(
            ParseCell<string>(AdvColumnName.Arg1),
            CustomCommand.ins.StringToColor(ParseCell<string>(AdvColumnName.Arg4)),
            ParseCell<float>(AdvColumnName.Arg6)
            );
    }
}



/// <summary>트윈 애니메이션 재생</summary>
public class AdvCommandPlayTweenLines : AdvCommand
{
    public AdvCommandPlayTweenLines(StringGridRow row) : base(row)
    {

    }

    public override void DoCommand(AdvEngine engine)
    {
        CustomCommand.ins.lineController.PlayTweenLines(
            ParseCell<string>(AdvColumnName.Arg1)
            );
    }
}




/// <summary>트윈 애니메이션을 만든다. 칼라전용</summary>
public class AdvCommandSetTweenColorLines : AdvCommand
{
    public AdvCommandSetTweenColorLines(StringGridRow row) : base(row)
    {

    }

    public override void DoCommand(AdvEngine engine)
    {
        CustomCommand.ins.lineController.dataSet.id = ParseCell<string>(AdvColumnName.Arg1);
        CustomCommand.ins.lineController.dataSet.listVec2.Add(CustomCommand.ins.StringToVec2(ParseCell<string>(AdvColumnName.Arg2)));
        CustomCommand.ins.lineController.dataSet.listVec2.Add(CustomCommand.ins.StringToVec2(ParseCell<string>(AdvColumnName.Arg3)));
        CustomCommand.ins.lineController.dataSet.color32 = CustomCommand.ins.StringToColor(ParseCell<string>(AdvColumnName.Arg4));
    }
}


/// <summary> 모든 선을 지운다. </summary>
public class AdvCommandClearAll : AdvCommand
{
    public AdvCommandClearAll(StringGridRow row) : base(row)
    {

    }

    public override void DoCommand(AdvEngine engine)
    {
        CustomCommand.ins.lineController.CleanAllLine();
    }
}





