using UnityEngine;

namespace Runner.Assistance
{
    public static class DebugLogger
    {
        private static bool _enabled = true;

        public static void WriteToLog(object message)
        {
#if UNITY_EDITOR
            if (_enabled)
            {
                Debug.Log(message);
            }
#endif
        }
    }
}
