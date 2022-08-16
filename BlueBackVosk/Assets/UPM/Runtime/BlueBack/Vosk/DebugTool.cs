

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
		#if(DEF_BLUEBACK_DEBUG_ASSERT)

		/** assertproc
		*/
		#if((DEF_BLUEBACK_DEBUG)&&(ASMDEF_BLUEBACK_DEBUG))
		public static BlueBack.Debug.Assert.ProcType assertproc = BlueBack.Debug.Assert.Default;
		#endif

		/** Assert
		*/
		public static void Assert(bool a_flag,System.Exception a_exception = null)
		{
			if(a_flag != true){
				#if((DEF_BLUEBACK_DEBUG)&&(ASMDEF_BLUEBACK_DEBUG))
				DebugTool.assertproc(null,a_exception);
				#endif
			}
		}

		/** Assert
		*/
		public static void Assert(bool a_flag,string a_message)
		{
			if(a_flag != true){
				#if((DEF_BLUEBACK_DEBUG)&&(ASMDEF_BLUEBACK_DEBUG))
				DebugTool.assertproc(a_message,null);
				#endif
			}
		}

		#endif

		#if(DEF_BLUEBACK_DEBUG_LOG)

		/** logproc
		*/
		#if((DEF_BLUEBACK_DEBUG)&&(ASMDEF_BLUEBACK_DEBUG))
		public static BlueBack.Debug.Log.ProcType logproc = BlueBack.Debug.Log.Default;
		#endif

		/** Log
		*/
		public static void Log(string a_message)
		{
			#if((DEF_BLUEBACK_DEBUG)&&(ASMDEF_BLUEBACK_DEBUG))
			DebugTool.logproc(a_message);
			#endif
		}

		#endif

		#if(DEF_BLUEBACK_DEBUG_DETAIL)

		/** detailproc
		*/
		#if((DEF_BLUEBACK_DEBUG)&&(ASMDEF_BLUEBACK_DEBUG))
		public static BlueBack.Debug.Detail.ProcType detailproc = BlueBack.Debug.Detail.Default;
		#endif

		/** Detail
		*/
		public static void Detail(string a_message)
		{
			#if((DEF_BLUEBACK_DEBUG)&&(ASMDEF_BLUEBACK_DEBUG))
			DebugTool.detailproc(a_message);
			#endif
		}

		#endif

		#if(UNITY_EDITOR)

		/** editorlogproc
		*/
		#if((DEF_BLUEBACK_DEBUG)&&(ASMDEF_BLUEBACK_DEBUG))
		public static BlueBack.Debug.Log.ProcType editorlogproc = BlueBack.Debug.Log.Default;
		#endif

		/** editorerrorlogproc
		*/
		#if((DEF_BLUEBACK_DEBUG)&&(ASMDEF_BLUEBACK_DEBUG))
		public static BlueBack.Debug.ErrorLog.ProcType editorerrorlogproc = BlueBack.Debug.ErrorLog.Default;
		#endif

		/** EditorLog
		*/
		public static void EditorLog(string a_message)
		{
			#if((DEF_BLUEBACK_DEBUG)&&(ASMDEF_BLUEBACK_DEBUG))
			DebugTool.editorlogproc(a_message);
			#endif
		}

		/** EditorErrorLog
		*/
		public static void EditorErrorLog(string a_message)
		{
			#if((DEF_BLUEBACK_DEBUG)&&(ASMDEF_BLUEBACK_DEBUG))
			DebugTool.editorerrorlogproc(a_message);
			#endif
		}

		#endif
	}
}

