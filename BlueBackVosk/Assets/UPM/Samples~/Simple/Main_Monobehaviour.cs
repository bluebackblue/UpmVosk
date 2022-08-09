

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

		public class VoskResult
		{
			public class Result
			{
				public float end;
				public float start;
				public string word;
			}

			public class Alternatives
			{
				public float confidence;
				public Result[] result;
				public string text;
			}

			public Alternatives[] alternatives;
		}

		/** [BlueBack.Vosk.Execute_Base]Event
		*/
		public void Event(bool a_success,BlueBack.JsonItem.JsonItem a_jsonitem)
		{
			if(a_success == false){
				if(a_jsonitem.IsExistItem("partial",JsonItem.ValueType.AssociativeArray) == true){
					string t_text = a_jsonitem.GetItem("partial").GetStringData();
					if(t_text.Length > 0){
						UnityEngine.Debug.Log(string.Format("{0}",t_text));
					}
				}
			}else{
				if(a_jsonitem.IsExistItem("alternatives",JsonItem.ValueType.AssociativeArray) == true){
					VoskResult t_result = JsonItem.Convert.JsonItemToObject<VoskResult>(a_jsonitem);

					if(t_result.alternatives.Length > 0){
						for(int ii=0;ii<t_result.alternatives.Length;ii++){
							if(t_result.alternatives[ii].text.Length > 0){
								UnityEngine.Debug.Log(string.Format("{0} : {1} : [{2}]",ii,t_result.alternatives[ii].confidence,t_result.alternatives[ii].text));
							}else{
								UnityEngine.Debug.Log(string.Format("alternatives[ii].text.Length == 0"));
							}
						}
					}else{
						UnityEngine.Debug.Log(string.Format("alternatives.Length == 0"));
					}
				}
			}
		}
	}
}
#endif

