

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

		/** assert
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.Assert.CallBackType assert = BlueBack.Debug.Assert.Execute;
		#endif

		/** Assert
		*/
		public static void Assert(bool a_flag,System.Exception a_exception = null)
		{
			if(a_flag != true){
				#if(ASMDEF_TRUE)
				DebugTool.assert(null,a_exception);
				#endif
			}
		}

		/** Assert
		*/
		public static void Assert(bool a_flag,string a_message)
		{
			if(a_flag != true){
				#if(ASMDEF_TRUE)
				DebugTool.assert(a_message,null);
				#endif
			}
		}

		#endif

		#if(DEF_BLUEBACK_DEBUG_LOG)

		/** log
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.Log.CallBackType log = BlueBack.Debug.Log.Execute;
		#endif

		/** Log
		*/
		public static void Log(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.log(a_message);
			#endif
		}

		#endif

		#if(DEF_BLUEBACK_DEBUG_DETAIL)

		/** detail
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.Detail.CallBackType detail = BlueBack.Debug.Detail.Execute;
		#endif

		/** Detail
		*/
		public static void Detail(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.detail(a_message);
			#endif
		}

		#endif

		#if(UNITY_EDITOR)

		/** editorlog
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.Log.CallBackType editorlog = BlueBack.Debug.Log.Execute;
		#endif

		/** editorerrorlog
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.ErrorLog.CallBackType editorerrorlog = BlueBack.Debug.ErrorLog.Execute;
		#endif

		/** EditorLog
		*/
		public static void EditorLog(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.editorlog(a_message);
			#endif
		}

		/** EditorErrorLog
		*/
		public static void EditorErrorLog(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.editorerrorlog(a_message);
			#endif
		}

		#endif
	}
}

