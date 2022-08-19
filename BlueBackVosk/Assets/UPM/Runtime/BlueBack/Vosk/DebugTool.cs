

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief デバッグツール。自動生成。
*/


/** define
*/
#if(ASMDEF_BLUEBACK_DEBUG)
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

		/** callback_assert
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.Assert.CallBackType callback_assert = BlueBack.Debug.Assert.Execute;
		#endif

		/** Assert
		*/
		public static void Assert(bool a_flag,string a_message = null,System.Exception a_exception = null)
		{
			if(a_flag != true){
				#if(ASMDEF_TRUE)
				DebugTool.callback_assert(a_message,a_exception);
				#endif
			}
		}

		/** Assert
		*/
		public static void Assert(bool a_flag,string a_message)
		{
			if(a_flag != true){
				#if(ASMDEF_TRUE)
				DebugTool.callback_assert(a_message,null);
				#endif
			}
		}

		/** Assert
		*/
		public static void Assert(bool a_flag,System.Exception a_exception)
		{
			if(a_flag != true){
				#if(ASMDEF_TRUE)
				DebugTool.callback_assert(null,a_exception);
				#endif
			}
		}

		#endif

		#if(DEF_BLUEBACK_DEBUG_LOG)

		/** callback_log
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.Log.CallBackType callback_log = BlueBack.Debug.Log.Execute;
		#endif

		/** Log
		*/
		public static void Log(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.callback_log(a_message);
			#endif
		}

		#endif

		#if(DEF_BLUEBACK_DEBUG_DETAIL)

		/** callback_detail
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.Detail.CallBackType callback_detail = BlueBack.Debug.Detail.Execute;
		#endif

		/** Detail
		*/
		public static void Detail(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.callback_detail(a_message);
			#endif
		}

		#endif

		#if(UNITY_EDITOR)

		/** callback_editorlog
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.EditorLog.CallBackType callback_editorlog = BlueBack.Debug.EditorLog.Execute;
		#endif

		/** callback_editorerrorlog
		*/
		#if(ASMDEF_TRUE)
		public static BlueBack.Debug.EditorErrorLog.CallBackType callback_editorerrorlog = BlueBack.Debug.EditorErrorLog.Execute;
		#endif

		/** EditorLog
		*/
		public static void EditorLog(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.callback_editorlog(a_message);
			#endif
		}

		/** EditorErrorLog
		*/
		public static void EditorErrorLog(string a_message)
		{
			#if(ASMDEF_TRUE)
			DebugTool.callback_editorerrorlog(a_message);
			#endif
		}

		#endif
	}
}

