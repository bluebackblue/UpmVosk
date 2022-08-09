

/** BlueBack.Vosk.Samples.Simple
*/
#if(!DEF_BLUEBACK_VOSK_SAMPLES_DISABLE)
namespace BlueBack.Vosk.Samples.Simple
{
	/** Main_Monobehaviour
	*/
	public sealed class Main_Monobehaviour : UnityEngine.MonoBehaviour , BlueBack.Vosk.Execute_Base
	{
		/** vosk
		*/
		public BlueBack.Vosk.Vosk vosk;

		/** jsonstring
		*/
		public string jsonstring;

		/** Awake
		*/
		private void Awake()
		{
		}

		/** Start
		*/
		private void Start()
		{
			BlueBack.Vosk.InitParam t_initparam = BlueBack.Vosk.InitParam.CreateDefault();
			{
				t_initparam.modelpath = UnityEngine.Application.streamingAssetsPath + "/" + "vosk-model-small-ja-0.22";
				t_initparam.audio_device_name = UnityEngine.Microphone.devices[0];
				t_initparam.execute = this;
				t_initparam.wordmode = false;

				UnityEngine.Debug.Log(t_initparam.audio_device_name);
			}
			this.vosk = new BlueBack.Vosk.Vosk(in t_initparam);
		}

		/** Update
		*/
		private void Update()
		{
			this.vosk.Update();
		}

		/** [BlueBack.Vosk.Execute_Base]Event
		*/
		public void Event(bool a_success,BlueBack.JsonItem.JsonItem a_eventparam_jsonitem)
		{
			//jsonstring
			this.jsonstring = a_eventparam_jsonitem.ConvertToJsonString();

			//eventparam_jsonitem
			if(a_success == true){
				if(this.vosk.param.vosk_wordmode == true){
					BlueBack.Vosk.EventParam_WordMode t_eventparam = JsonItem.Convert.JsonItemToObject<BlueBack.Vosk.EventParam_WordMode>(a_eventparam_jsonitem);
					if(t_eventparam.alternatives != null){
						if(t_eventparam.alternatives.Length > 0){
							for(int ii=0;ii<t_eventparam.alternatives.Length;ii++){
								if(t_eventparam.alternatives[ii].text != null){
									if(t_eventparam.alternatives[ii].text.Length > 0){
										UnityEngine.Debug.Log(string.Format("{0} : {1} : [{2}] word = {3}",ii,t_eventparam.alternatives[ii].confidence,t_eventparam.alternatives[ii].text,t_eventparam.alternatives[ii].result.Length));
									}
								}
							}
						}
					}
				}else{
					BlueBack.Vosk.EventParam t_eventparam = JsonItem.Convert.JsonItemToObject<BlueBack.Vosk.EventParam>(a_eventparam_jsonitem);
					if(t_eventparam.alternatives != null){
						if(t_eventparam.alternatives.Length > 0){
							for(int ii=0;ii<t_eventparam.alternatives.Length;ii++){
								if(t_eventparam.alternatives[ii].text != null){
									if(t_eventparam.alternatives[ii].text.Length > 0){
										UnityEngine.Debug.Log(string.Format("{0} : {1} : [{2}]",ii,t_eventparam.alternatives[ii].confidence,t_eventparam.alternatives[ii].text));
									}
								}
							}
						}
					}
				}
			}else{
				BlueBack.Vosk.EventParam_Partial t_eventparam = JsonItem.Convert.JsonItemToObject<BlueBack.Vosk.EventParam_Partial>(a_eventparam_jsonitem);
				if(t_eventparam.partial != null){
					if(t_eventparam.partial.Length > 0){
						UnityEngine.Debug.Log(string.Format("{0}",t_eventparam.partial));
					}
				}
			}
		}
	}
}
#endif

