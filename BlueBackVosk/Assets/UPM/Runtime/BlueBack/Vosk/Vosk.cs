

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＶＯＳＫ。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** Vosk
	*/
	public sealed class Vosk : System.IDisposable
	{
		/** voskdll
		*/
		public Dll.VoskDll voskdll;
		public bool voskdll_wordmode_fix;
		public bool voskdll_wordmode_partial;
		public int voskdll_alternative;
		public bool voskdll_enable;

		/** execute
		*/
		public Execute_Base execute;

		/** audioclip_execute
		*/
		public AudioClip_Execute_Base audioclip_execute;

		/** debugview
		*/
		#if(DEF_BLUEBACK_VOSK_DEBUGVIEW)
		public DebugView_MonoBehaviour debugview_monobehaviour;
		#endif

		/** constructor
		*/
		public Vosk(in InitParam a_initparam)
		{
			//execute
			this.execute = a_initparam.execute;

			//audioclip_execute
			this.audioclip_execute = a_initparam.audioclip_execute;

			//vosk_dll
			this.voskdll = new Dll.VoskDll(a_initparam.modelpath);
			this.voskdll_wordmode_fix = false;
			this.voskdll_wordmode_partial = false;
			this.voskdll_alternative = 1;
			this.voskdll_enable = false;

			//debugview
			#if(DEF_BLUEBACK_VOSK_DEBUGVIEW)
			{
				this.debugview_monobehaviour = new UnityEngine.GameObject("vosk_debugview").AddComponent<DebugView_MonoBehaviour>();
				this.debugview_monobehaviour.vosk = this;
				UnityEngine.GameObject.DontDestroyOnLoad(this.debugview_monobehaviour.gameObject);
			}
			#endif
		}

		/** [System.IDisposable]Dispose。
		*/
		public void Dispose()
		{
			//debugview
			#if(DEF_BLUEBACK_VOSK_DEBUGVIEW)
			{
				if(this.debugview_monobehaviour != null){
					UnityEngine.GameObject.Destroy(this.debugview_monobehaviour.gameObject);
					this.debugview_monobehaviour = null;
				}
			}
			#endif

			//audioclip_execute
			if(this.audioclip_execute != null){
				this.audioclip_execute.End();
				this.audioclip_execute = null;
			}

			//voskdll
			if(this.voskdll != null){
				this.voskdll.Dispose();
				this.voskdll = null;
			}
		}

		/** 開始。
		*/
		public void Start()
		{
			#if(DEF_BLUEBACK_LOG)
			DebugTool.Log("BlueBack.Vosk.Start");
			#endif

			int t_samplerate;

			//audioclip_execute.Start
			try{
				this.audioclip_execute.Start();
				t_samplerate = this.audioclip_execute.GetSampleRate();
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSERT)
				BlueBack.Vosk.DebugTool.Assert(false,t_exception);
				#endif

				t_samplerate = 0;
			}

			//voskdll
			if((this.voskdll != null)&&(this.audioclip_execute != null)){
				this.voskdll.CreateRecognizer(t_samplerate);
				this.voskdll.SetWordMode(this.voskdll_wordmode_fix,this.voskdll_wordmode_partial);
				this.voskdll.SetAlternative(this.voskdll_alternative);
			}

			//voskdall_enable
			this.voskdll_enable = true;
		}

		/** 終了。
		*/
		public void End()
		{
			#if(DEF_BLUEBACK_LOG)
			DebugTool.Log("BlueBack.Vosk.End");
			#endif

			//audioclip_execute
			try{
				if(this.audioclip_execute != null){
					this.audioclip_execute.End();
				}
			}catch(System.Exception t_exception){
				#if(DEF_BLUEBACK_ASSERT)
				BlueBack.Vosk.DebugTool.Assert(false,t_exception);
				#endif
			}

			//voskdll
			if(this.voskdll != null){
				this.voskdll.DeleteRecognizer();
			}
		}

		/** IsEnable
		*/
		public bool IsEnable()
		{
			if(this.voskdll.voskrecognizer == null){
				return false;
			}else{
				return true;
			}
		}

		/** SetWordModeFix
		*/
		public void SetWordModeFix(bool a_wordmode_fix,bool a_wordmode_partial)
		{
			//SetWordMode
			this.voskdll_wordmode_fix = a_wordmode_fix;
			this.voskdll_wordmode_partial = a_wordmode_partial;
			this.voskdll.SetWordMode(a_wordmode_fix,a_wordmode_partial);
		}

		/** SetAlternative
		*/
		public void SetAlternative(int a_voskdll_alternative)
		{
			//SetAlternative
			this.voskdll_alternative = a_voskdll_alternative;
			this.voskdll.SetAlternative(a_voskdll_alternative);
		}

		/** Update
		*/
		public void Update()
		{
			if(this.voskdll != null){
				if(this.voskdll.voskrecognizer != null){
					short[] t_buffer = this.audioclip_execute.Update();
					if(t_buffer != null){
						//データあり。
						
						if(this.voskdll.RecognizerUpdate(t_buffer) == true){
							//fix
							string t_eventparam_jsonstring = this.voskdll.GetRecognizerResultFix();
							if(t_eventparam_jsonstring != null){
								BlueBack.JsonItem.JsonItem t_eventparam_jsonitem = BlueBack.JsonItem.Convert.JsonStringToJsonItem(BlueBack.JsonItem.Normalize.Convert(t_eventparam_jsonstring));
								if(this.voskdll_wordmode_fix == true){
									BlueBack.Vosk.EventParam_Fix_WordMode t_eventparam = JsonItem.Convert.JsonItemToObject<BlueBack.Vosk.EventParam_Fix_WordMode>(t_eventparam_jsonitem);
									this.execute.Event(t_eventparam);
								}else{
									BlueBack.Vosk.EventParam_Fix t_eventparam = JsonItem.Convert.JsonItemToObject<BlueBack.Vosk.EventParam_Fix>(t_eventparam_jsonitem);
									this.execute.Event(t_eventparam);
								}
							}
						}else{
							//partial
							string t_eventparam_jsonstring = this.voskdll.GetRecognizerResultPartial();
							if(t_eventparam_jsonstring != null){
								BlueBack.JsonItem.JsonItem t_eventparam_jsonitem = BlueBack.JsonItem.Convert.JsonStringToJsonItem(BlueBack.JsonItem.Normalize.Convert(t_eventparam_jsonstring));
								if(this.voskdll_wordmode_partial == true){
									BlueBack.Vosk.EventParam_Partial_WordMode t_eventparam = JsonItem.Convert.JsonItemToObject<BlueBack.Vosk.EventParam_Partial_WordMode>(t_eventparam_jsonitem);
									this.execute.Event(t_eventparam);
								}else{
									BlueBack.Vosk.EventParam_Partial t_eventparam = JsonItem.Convert.JsonItemToObject<BlueBack.Vosk.EventParam_Partial>(t_eventparam_jsonitem);
									this.execute.Event(t_eventparam);
								}
							}
						}
					}
				}else{
					#if(DEF_BLUEBACK_LOG)
					DebugTool.Assert(false,"voskrecognizer == null");
					#endif
				}
			}else{
				#if(DEF_BLUEBACK_LOG)
				DebugTool.Assert(false,"voskdll == null");
				#endif
			}
		}
	}
}

