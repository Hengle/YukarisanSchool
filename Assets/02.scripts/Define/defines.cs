namespace Def
{
    namespace Enum
    {
        //씬 
        public enum enumSceneName
        {
            Home,
            YukarisanSchool
        }

        //페이드
        public enum enumFadeType
        {
            None,
            FadeIn,
            FadeOut,
        }

        //우타게에서 보내는 CustomCommand
        public enum enumCustomCommand
        {            
            UnityFadeOut,
            UnityFadeIn,

            SetLines,
            SetTweenColorLines,
            SetTweenPositionLines,
            AddTweenColorLines,
            AddTweenPositionLines,
            PlayTweenLines,

            SetArrows,
            SetTweenColorArrows,
            SetTweenPositionArrows,            
            AddTweenColorArrows,
            AddTweenPositionArrows,
            PlayTweenArrows,

            SetRect,
            SetTweenColorRect,
            SetTweenPositionRect,
            AddTweenColorRect,
            AddTweenPositionRect,
            PlayTweenRect,


            ClearAll,
        }
    }
}

