

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

		/** enable
		*/
		public bool enable;

		/** wordmode
		*/
		public bool wordmode;

		/** alternative
		*/
		public int alternative;

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
				t_initparam.modelpath = UnityEngine.Application.streamingAssetsPath + "/Vosk/" + "vosk-model-small-ja-0.22";
				t_initparam.execute = this;
			}
			this.vosk = new BlueBack.Vosk.Vosk(in t_initparam);

			//audioclip_execute
			{
				string t_devicename = UnityEngine.Microphone.devices[0];
				UnityEngine.Microphone.GetDeviceCaps(t_devicename,out int t_samplerate_min,out int t_samplerate_max);
				UnityEngine.Debug.Log(string.Format("device = {0} : samplerate min = {1} : samplerate max {2}",t_devicename,t_samplerate_min,t_samplerate_max));

				BlueBack.Vosk.AudioClip_Execute_Default t_audioclip_execute = t_initparam.audioclip_execute as BlueBack.Vosk.AudioClip_Execute_Default;
				t_audioclip_execute.SetDevice(t_devicename);
				t_audioclip_execute.SetSampleRate(t_samplerate_max);
				t_audioclip_execute.SetUseChannel(0);
			}
		}

		/** OnDestroy
		*/
		private void OnDestroy()
		{
			if(this.vosk != null){
				this.vosk.Dispose();
				this.vosk = null;
			}
		}

		/** Update
		*/
		private void Update()
		{
			if(this.enable == true){
				//Start
				if(this.vosk.IsEnable() == false){
					this.vosk.SetWordModeFix(this.wordmode,this.wordmode);
					this.vosk.SetAlternative(this.alternative);
					this.vosk.Start();
				}

				//Update
				this.vosk.Update();
			}else{
				//End
				if(this.vosk.IsEnable() == true){
					this.vosk.End();
				}
			}
		}

		/** [BlueBack.Vosk.Execute_Base]Event
		*/
		public void Event(BlueBack.Vosk.EventParam_Fix_WordMode a_eventparam)
		{
			if(a_eventparam.text != null){
				if(a_eventparam.text.Length > 0){
					UnityEngine.Debug.Log(string.Format("fix wordmode : text = {0}",a_eventparam.text));
				}
			}

			if(a_eventparam.result != null){
				for(int ii=0;ii<a_eventparam.result.Length;ii++){
					UnityEngine.Debug.Log(string.Format("fix wordmode[{0}] : conf = {1} : word = {2}",ii,a_eventparam.result[ii].conf,a_eventparam.result[ii].word));
				}
			}

			if(a_eventparam.alternatives != null){
				for(int ii=0;ii<a_eventparam.alternatives.Length;ii++){
					if(a_eventparam.alternatives[ii].text != null){
						if(a_eventparam.alternatives[ii].text.Length > 0){
							UnityEngine.Debug.Log(string.Format("fix wordmode[{0}] : confidence = {1} : text = [{2}]",ii,a_eventparam.alternatives[ii].confidence,a_eventparam.alternatives[ii].text));
							for(int jj=0;jj<a_eventparam.alternatives[ii].result.Length;jj++){
								UnityEngine.Debug.Log(string.Format("fix wordmode[{0}] : word = {1}",jj,a_eventparam.alternatives[ii].result[jj].word));
							}
						}
					}
				}
			}
		}

		/** [BlueBack.Vosk.Execute_Base]Event
		*/
		public void Event(BlueBack.Vosk.EventParam_Fix a_eventparam)
		{
			if(a_eventparam.text != null){
				if(a_eventparam.text.Length > 0){
					UnityEngine.Debug.Log(string.Format("fix : text = {0}",a_eventparam.text));
				}
			}

			if(a_eventparam.alternatives != null){
				for(int ii=0;ii<a_eventparam.alternatives.Length;ii++){
					if(a_eventparam.alternatives[ii].text != null){
						if(a_eventparam.alternatives[ii].text.Length > 0){
							UnityEngine.Debug.Log(string.Format("fix[{0}] : confidence = {1} : text = [{2}]",ii,a_eventparam.alternatives[ii].confidence,a_eventparam.alternatives[ii].text));
						}
					}
				}
			}
		}

		/** [BlueBack.Vosk.Execute_Base]Event
		*/
		public void Event(BlueBack.Vosk.EventParam_Partial_WordMode a_eventparam)
		{
			if(a_eventparam.partial != null){
				if(a_eventparam.partial.Length > 0){
					UnityEngine.Debug.Log(string.Format("partial wordmode : partial = {0}",a_eventparam.partial));
				}

			}

			if(a_eventparam.partial_result != null){
				for(int ii=0;ii<a_eventparam.partial_result.Length;ii++){
					UnityEngine.Debug.Log(string.Format("partial wordmode[{0}] : conf = {1} : word = {2}",ii,a_eventparam.partial_result[ii].conf,a_eventparam.partial_result[ii].word));
				}
			}
		}

		/** [BlueBack.Vosk.Execute_Base]Event
		*/
		public void Event(BlueBack.Vosk.EventParam_Partial a_eventparam)
		{
			if(a_eventparam.partial != null){
				if(a_eventparam.partial.Length > 0){
					UnityEngine.Debug.Log(string.Format("partial : partial = {0}",a_eventparam.partial));
				}
			}
		}
	}
}
#endif

