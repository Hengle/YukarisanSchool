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
            UnityLinesSet,
            UnityLinesTween,
            UnityLinesClean,
        }
    }
}

