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
            AddTweenColorLines,
            AddTweenPositionLines,
            PlayTweenLines,

            SetArrows,      
            AddTweenColorArrows,
            AddTweenPositionArrows,
            PlayTweenArrows,

            SetRect,
            AddTweenColorRect,
            AddTweenPositionRect,
            PlayTweenRect,

            ClearAll,
        }
    }
}

