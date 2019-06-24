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

        //우타게에서 보내는 SendMessage
        public enum enumUtageSendMessage
        {
            UnityFadeOut,
            UnityFadeIn,

            UnityLinesCreate,
            UnityLinesSetColor,
            UnityLinesSetPosition,
            UnityLinesSetTweenColor,
            UnityLinesSetTweenPosition,
            UnityLinesAddTweenColor,
            UnityLinesAddTweenPosition,
            UnityLinesTweenPlay,
            UnityLinesClean,

            UnityArrowsCreate,
            UnityArrowsSetColor,
            UnityArrowsSetPosition,
            UnityArrowsSetTweenColor,
            UnityArrowsSetTweenPosition,
            UnityArrowsAddTweenColor,
            UnityArrowsAddTweenPosition,
            UnityArrowsTweenPlay,
            UnityArrowsClean
        }
    }
}

