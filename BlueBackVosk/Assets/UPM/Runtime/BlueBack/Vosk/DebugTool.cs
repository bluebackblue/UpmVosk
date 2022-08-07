

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief デバッグツール。自動生成。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** DebugTool
	*/
	public static class DebugTool
	{
		/** assertproc
		*/
		#if(DEF_BLUEBACK_ASSERT)
		public static void DefaultAssertProc(System.Exception a_exception,string a_message)
		{
			if(a_message != null){
				UnityEngine.Debug.LogError(a_message);
			}

			if(a_exception != null){
				UnityEngine.Debug.LogError(a_exception.ToString());
			}

			UnityEngine.Debug.Assert(false);
		}
		public delegate void AssertProcType(System.Exception a_exception,string a_message);
		public static AssertProcType assertproc = DefaultAssertProc;
		#endif

		/** logproc
		*/
		#if(DEF_BLUEBACK_LOG)
		public static void DefaultLogProc(string a_message)
		{
			UnityEngine.Debug.Log(a_message);
		}
		public delegate void LogProcType(string a_message);
		public static LogProcType logproc = DebugTool.DefaultLogProc;
		#endif

		/** Assert
		*/
		#if(DEF_BLUEBACK_ASSERT)
		public static void Assert(bool a_flag,System.Exception a_exception = null)
		{
			if(a_flag != true){
				DebugTool.assertproc(a_exception,null);
			}
		}
		#endif

		/** Assert
		*/
		#if(DEF_BLUEBACK_ASSERT)
		public static void Assert(bool a_flag,string a_message)
		{
			if(a_flag != true){
				DebugTool.assertproc(null,a_message);
			}
		}
		#endif

		#if(DEF_BLUEBACK_LOG)
		public static void Log(string a_message)
		{
			DebugTool.logproc(a_message);
		}
		#endif

		/** EditorLog
		*/
		#if(UNITY_EDITOR)
		public static void EditorLog(string a_text)
		{
			UnityEngine.Debug.Log(a_text);
		}
		#endif

		/** EditorLogError
		*/
		#if(UNITY_EDITOR)
		public static void EditorLogError(string a_text)
		{
			UnityEngine.Debug.LogError(a_text);
		}
		#endif
	}
}

