

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＶＯＳＫ。
*/


/** BlueBack.Vosk
*/
#if(UNITY_EDITOR)
namespace BlueBack.Vosk
{
	/** DebugView_MonoBehaviour
	*/
	#if(DEF_BLUEBACK_VOSK_DEBUGVIEW)
	public class DebugView_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** Mode
		*/
		public enum Mode
		{
			/** 読み込み。
			*/
			Read,

			/** 書き込み。
			*/
			Write,

			/** なし。
			*/
			None,
		}

		/** mode
		*/
		public Mode mode;

		/** vosk
		*/
		public BlueBack.Vosk.Vosk vosk;

		/** samplerate
		*/
		public int samplerate;

		/** channel
		*/
		public int channel;

		/** position
		*/
		public int position;

		/** Awake
		*/
		public void Awake()
		{
			//mode
			this.mode = Mode.Read;

			//vosk
			this.vosk = null;
		}

		/** Update
		*/
		public void Update()
		{
			#if(UNITY_EDITOR)
			if(UnityEditor.Selection.activeGameObject == this.gameObject){
				switch(this.mode){
				case Mode.Read:
					{
						//samplerate
						this.samplerate = this.vosk.audioclip_execute.GetSampleRate();

						//channel
						this.channel = this.vosk.audioclip_execute.GetChannel();

						//position
						this.position = this.vosk.audioclip_execute.GetPosition();
					}break;
				case Mode.Write:
					{
					}break;
				}
			}else{
				this.mode = Mode.Read;
			}
			#endif
		}
	}
	#endif
}
#endif

