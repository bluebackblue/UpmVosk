

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief VoskDll
*/


/** BlueBack.Vosk.Dll
*/
namespace BlueBack.Vosk.Dll
{
	/** VoskDll
	*/
	public sealed class VoskDll : System.IDisposable
	{
		/** model
		*/
		public global::Vosk.Model model;

		/** voskrecognizer
		*/
		public global::Vosk.VoskRecognizer voskrecognizer;

		/** method_argument_list_getcpt
		*/
		private static System.Object[] method_argument_list_getcpt = new System.Object[1]{null};

		/** Inner_ModelInstanceCheck
		*/
		private static bool Inner_ModelInstanceCheck(global::Vosk.Model a_model)
		{
			if(a_model != null){
				//methodinfo_find
				System.Reflection.MethodInfo t_methodinfo_find = null;
				{
					System.Reflection.MethodInfo[] t_methodinfo_list = typeof(global::Vosk.Model).GetMethods(System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
					if(t_methodinfo_list != null){
						t_methodinfo_find = System.Array.Find(t_methodinfo_list,(System.Reflection.MethodInfo a_a_methodinfo)=>{
							return a_a_methodinfo.Name == "getCPtr";
						});
					}
				}

				//handle
				if(t_methodinfo_find != null){
					method_argument_list_getcpt[0] = a_model;
					object t_object = t_methodinfo_find.Invoke(null,method_argument_list_getcpt);
					if(t_object != null){
						if(t_object.GetType() == typeof(System.Runtime.InteropServices.HandleRef)){
							System.Runtime.InteropServices.HandleRef t_handle = (System.Runtime.InteropServices.HandleRef)t_object;
							if(t_handle.Handle.ToInt64() != 0){
								return true;
							}
						}
					}
				}
			}

			return false;
		}

		/** constructor
		*/
		public VoskDll(string a_modelpath)
		{
			//model
			this.model = new global::Vosk.Model(a_modelpath);
			if(Inner_ModelInstanceCheck(this.model) == false){
				if(this.model != null){
					this.model.Dispose();
					this.model = null;
				}

				#if(DEF_BLUEBACK_ASSERT)
				{
					UnityEngine.Debug.LogError("VoskDll.constructor : error");
				}
				#endif
			}

			//voskrecognizer
			this.voskrecognizer = null;
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
			//voskrecognizer
			if(this.voskrecognizer != null){
				this.voskrecognizer.Dispose();
				this.voskrecognizer = null;
			}

			//model
			if(this.model != null){
				this.model.Dispose();
				this.model = null;
			}
		}

		/** 作成。Recognizer。
		*/
		public void CreateRecognizer(int a_samplerate)
		{
			//voskrecognizer
			if(this.model != null){
				if(a_samplerate >= 8000){
					this.voskrecognizer = new global::Vosk.VoskRecognizer(this.model,a_samplerate);
				}else{
					#if(DEF_BLUEBACK_ASSERT)
					{
						UnityEngine.Debug.LogError("CreateRecognizer : error");
					}
					#endif
				}
			}
		}

		/** SetWordMode
		*/
		public void SetWordMode(bool a_wordmode_fix,bool a_wordmode_partial)
		{
			//voskrecognizer
			if(this.voskrecognizer != null){
				this.voskrecognizer.SetWords(a_wordmode_fix);
				this.voskrecognizer.SetPartialWords(a_wordmode_partial);
			}
		}

		/** SetAlternative
		*/
		public void SetAlternative(int a_alternative)
		{
			if(this.voskrecognizer != null){
				this.voskrecognizer.SetMaxAlternatives(a_alternative);
			}
		}

		/** 削除。Recognizer。
		*/
		public void DeleteRecognizer()
		{
			//voskrecognizer
			if(this.voskrecognizer != null){
				this.voskrecognizer.Dispose();
				this.voskrecognizer = null;
			}
		}

		/** RecognizerUpdate

			return == true  : fix
			return == false : partial

		*/
		public bool RecognizerUpdate(short[] a_buffer)
		{
			if(this.voskrecognizer != null){
				return this.voskrecognizer.AcceptWaveform(a_buffer,a_buffer.Length);
			}
			return false;
		}

		/** GetRecognizerResultFix
		*/
		public string GetRecognizerResultFix()
		{
			if(this.voskrecognizer != null){
				return this.voskrecognizer.Result();
			}
			return null;
		}

		/** GetRecognizerResultPartial
		*/
		public string GetRecognizerResultPartial()
		{
			if(this.voskrecognizer != null){
				return this.voskrecognizer.PartialResult();
			}
			return null;
		}
	}
}

