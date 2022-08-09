

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
	#if(UNITY_EDITOR)
	[System.Serializable]
	#endif
	public sealed class Vosk : System.IDisposable
	{
		/** param
		*/
		public Param param;

		/** voskdll
		*/
		public Dll.VoskDll voskdll;

		/** execute
		*/
		public Execute_Base execute;

		/** constructor
		*/
		public Vosk(in InitParam a_initparam)
		{
			//audio
			{
				this.param.audio_device_name = a_initparam.audio_device_name;
				this.param.audio_use_channel = a_initparam.audio_use_channel;
			}

			//microphone
			{
				UnityEngine.AudioClip t_audioclip = UnityEngine.Microphone.Start(this.param.audio_device_name,true,a_initparam.audio_buffer_per_sec,a_initparam.audio_sample);

				this.param.microphone_audioclip = t_audioclip;
				this.param.microphone_position = 0;
				this.param.microphone_blockcount_multi = a_initparam.audio_blockcount * t_audioclip.channels;
				this.param.microphone_blockcount_single = a_initparam.audio_blockcount;
				this.param.microphone_buffer_float = new float[a_initparam.audio_blockcount * t_audioclip.channels];
				this.param.microphone_buffer_byte = new byte[a_initparam.audio_blockcount * 2];
			}

			//vosk
			{
				this.param.vosk_wordmode = a_initparam.wordmode;
			}

			//vosk_dll
			this.voskdll = new Dll.VoskDll(
				a_initparam.modelpath,
				a_initparam.audio_sample,
				a_initparam.alternative_max,
				a_initparam.wordmode
			);

			//execute
			this.execute = a_initparam.execute;
		}

		/** [System.IDisposable]Dispose。
		*/
		public void Dispose()
		{
		}

		/** Update
		*/
		public void Update()
		{
			if(UnityEngine.Microphone.IsRecording(this.param.audio_device_name) == false){			
				return;
			}

			if(this.voskdll.Check() == false){
				return;
			}

			{
				int t_position_new = UnityEngine.Microphone.GetPosition(this.param.audio_device_name);

				//count
				int t_count;
				{
					if(t_position_new >= this.param.microphone_position){
						t_count = t_position_new - this.param.microphone_position;
					}else{
						t_count = (this.param.microphone_audioclip.samples * this.param.microphone_audioclip.channels - (this.param.microphone_position - t_position_new));
					}
				}

				if(t_count >= this.param.microphone_blockcount_multi){
					int ii_max = t_count / this.param.microphone_blockcount_multi;
					for(int ii=0;ii<ii_max;ii++){
						//GetData
						if(this.param.microphone_audioclip.GetData(this.param.microphone_buffer_float,this.param.microphone_position) == true){
							for(int jj=0;jj<this.param.microphone_blockcount_single;jj++){
								byte[] t_byte_2 = System.BitConverter.GetBytes((short)(this.param.microphone_buffer_float[jj * this.param.microphone_audioclip.channels + this.param.audio_use_channel] * short.MaxValue));
								this.param.microphone_buffer_byte[jj * 2 + 0] = t_byte_2[0];
								this.param.microphone_buffer_byte[jj * 2 + 1] = t_byte_2[1];
							}
						}

						//microphone_position
						this.param.microphone_position = (this.param.microphone_position + this.param.microphone_blockcount_multi) % this.param.microphone_audioclip.samples * this.param.microphone_audioclip.channels;

						//Apply
						{
							(bool t_success,string t_eventparam_jsonstring) = this.voskdll.Apply(this.param.microphone_buffer_byte);
							BlueBack.JsonItem.JsonItem t_eventparam_jsonitem = BlueBack.JsonItem.Convert.JsonStringToJsonItem(BlueBack.JsonItem.Normalize.Convert(t_eventparam_jsonstring));
							this.execute.Event(t_success,t_eventparam_jsonitem);
						}
					}
				}
			}
		}
	}
}

