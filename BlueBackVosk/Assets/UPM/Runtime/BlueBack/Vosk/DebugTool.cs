

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
		#if(DEF_BLUEBACK_ASSERT)

		/** DefaultAssertProc
		*/
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

		/** AssertProcType
		*/
		public delegate void AssertProcType(System.Exception a_exception,string a_message);

		/** assertproc
		*/
		public static AssertProcType assertproc = DefaultAssertProc;

		/** Assert
		*/
		public static void Assert(bool a_flag,System.Exception a_exception = null)
		{
			if(a_flag != true){
				DebugTool.assertproc(a_exception,null);
			}
		}

		/** Assert
		*/
		public static void Assert(bool a_flag,string a_message)
		{
			if(a_flag != true){
				DebugTool.assertproc(null,a_message);
			}
		}

		#endif

		#if(DEF_BLUEBACK_LOG)

		/** DefaultLogProc
		*/
		public static void DefaultLogProc(string a_message)
		{
			UnityEngine.Debug.Log(a_message);
		}

		/** LogProcType
		*/
		public delegate void LogProcType(string a_message);

		/** logproc
		*/
		public static LogProcType logproc = DebugTool.DefaultLogProc;

		/** Log
		*/
		public static void Log(string a_message)
		{
			DebugTool.logproc(a_message);
		}

		#endif

		#if(DEF_BLUEBACK_DETAIL)

		/** DefaultDetailProc
		*/
		public static void DefaultDetailProc(string a_message)
		{
			UnityEngine.Debug.Log(a_message);
		}

		/** DetailProcType
		*/
		public delegate void DetailProcType(string a_message);

		/** detailproc
		*/
		public static DetailProcType detailproc = DebugTool.DefaultDetailProc;

		/** Detail
		*/
		public static void Detail(string a_message)
		{
			DebugTool.detailproc(a_message);
		}

		#endif

		#if(UNITY_EDITOR)

		/** DefaultEditorLogProc
		*/
		public static void DefaultEditorLogProc(string a_message_log,string a_message_logerror)
		{
			if(a_message_log != null){
				UnityEngine.Debug.Log(a_message_log);
			}

			if(a_message_logerror != null){
				UnityEngine.Debug.Log(a_message_logerror);
			}
		}

		/** EditorLogProcType
		*/
		public delegate void EditorLogProcType(string a_message_log,string a_message_logerror);

		/** editorlogproc
		*/
		public static EditorLogProcType editorlogproc = DebugTool.DefaultEditorLogProc;

		/** EditorLog
		*/
		public static void EditorLog(string a_message)
		{
			DebugTool.editorlogproc(a_message,null);
		}

		/** EditorLogError
		*/
		public static void EditorLogError(string a_message)
		{
			DebugTool.editorlogproc(null,a_message);
		}

		#endif
	}
}

