

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief デバッグツール。自動生成。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_DEBUG||USERDEF_BLUEBACK_DEBUG))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


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
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.Assert.ProcType assertproc = BlueBack.Debug.Assert.Default;
		#endif

		/** Assert
		*/
		public static void Assert(bool a_flag,System.Exception a_exception = null)
		{
			if(a_flag != true){
				#if(ASMDEF_TRUE)
				DebugTool.assertproc(null,a_exception);
				#endif
			}
		}

		/** Assert
		*/
		public static void Assert(bool a_flag,string a_message)
		{
			if(a_flag != true){
				#if(ASMDEF_TRUE)
				DebugTool.assertproc(a_message,null);
				#endif
			}
		}

		#endif

		#if(DEF_BLUEBACK_DEBUG_LOG)

		/** logproc
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.Log.ProcType logproc = BlueBack.Debug.Log.Default;
		#endif

		/** Log
		*/
		public static void Log(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.logproc(a_message);
			#endif
		}

		#endif

		#if(DEF_BLUEBACK_DEBUG_DETAIL)

		/** detailproc
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.Detail.ProcType detailproc = BlueBack.Debug.Detail.Default;
		#endif

		/** Detail
		*/
		public static void Detail(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.detailproc(a_message);
			#endif
		}

		#endif

		#if(UNITY_EDITOR)

		/** editorlogproc
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.Log.ProcType editorlogproc = BlueBack.Debug.Log.Default;
		#endif

		/** editorerrorlogproc
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.ErrorLog.ProcType editorerrorlogproc = BlueBack.Debug.ErrorLog.Default;
		#endif

		/** EditorLog
		*/
		public static void EditorLog(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.editorlogproc(a_message);
			#endif
		}

		/** EditorErrorLog
		*/
		public static void EditorErrorLog(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.editorerrorlogproc(a_message);
			#endif
		}

		#endif
	}
}

