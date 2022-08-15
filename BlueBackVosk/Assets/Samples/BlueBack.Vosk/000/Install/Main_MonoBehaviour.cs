

/** BlueBack.Vosk.Samples.Install
*/
#if(!DEF_BLUEBACK_VOSK_SAMPLES_DISABLE)
namespace BlueBack.Vosk.Samples.Install
{
	/** Main_MonoBehaviour
	*/
	public sealed class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** status
		*/
		public BlueBack.Vosk.ModelListStatus status;

		/** modellist_textasset
		*/
		public UnityEngine.TextAsset modellist_textasset;

		/** Step
		*/
		public enum Step
		{
			None,
			Init,

			DownLoadModelList_Start,
			DownLoadModelList_Wait,

			DownLoadZip_Start,
			DownLoadZip_Wait,
		}
		public Step step;

		/** Awake
		*/
		private void Awake()
		{
		}

		/** Start
		*/
		private void Start()
		{
			//status
			this.status = new ModelListStatus();

			//step
			this.step = Step.Init;

		}

		/** OnDestroy
		*/
		private void OnDestroy()
		{
		}

		/** Update
		*/
		private void Update()
		{
			switch(this.step){
			case Step.Init:
				{
					this.step = Step.DownLoadModelList_Start;
				}break;
			case Step.DownLoadModelList_Start:
				{
					//StartCoroutine
					this.StartCoroutine(BlueBack.Vosk.ModelTool.DownLoadModelList(this.status,this.modellist_textasset.text));
					this.step = Step.DownLoadModelList_Wait;
				}break;
			case Step.DownLoadModelList_Wait:
				{
					if(this.status != null){
						if(this.status.fix == true){
							/*
							int ii_max = this.status.list.Count;
							for(int ii=0;ii<ii_max;ii++){
								ModelListItem t_item = this.status.list[ii];
								UnityEngine.Debug.Log(string.Format("name = [{0}]\n  url = [{1}]\n size = [{2}]\n license = [{3}]\n rate = [{4}]\n note = [{5}]\n",
									t_item.name,t_item.url,t_item.size,t_item.license,t_item.rate,t_item.note));
							}
							*/
							this.step = Step.DownLoadZip_Start;
						}else if(this.status.error == true){
							UnityEngine.Debug.Log("error");
							this.status = null;
							this.step = Step.None;
						}
					}
				}break;
			case Step.DownLoadZip_Start:
				{
					this.step = Step.None;
					for(int ii=0;ii<this.status.list.Count;ii++){
						if(this.status.list[ii].name == "vosk-model-small-ja-0.22"){
							UnityEngine.Debug.Log(this.status.list[ii].name);

							this.StartCoroutine(BlueBack.Vosk.ModelTool.DownLoadZip(this.status.list[ii]));
							this.step = Step.DownLoadZip_Wait;
							break;
						}
					}
				}break;
			case Step.DownLoadZip_Wait:
				{

				}break;
			}


		}
	}
}
#endif

