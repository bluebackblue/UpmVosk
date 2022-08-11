

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＶＯＳＫ。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** AudioClip_Execute_Default
	*/
	public sealed class AudioClip_Execute_Default : AudioClip_Execute_Base
	{
		/** devicename
		*/
		private string devicename;

		/** BLOCK_MAX
		*/
		private const int BLOCK_MAX = 1024;

		/** audioclip
		*/
		public UnityEngine.AudioClip audioclip;

		/** position
		*/
		private int position;

		/** buffer
		*/
		private float[] buffer_raw;
		private short[] buffer_short;

		/** usechannel
		*/
		public int usechannel;

		/** samplerate
		*/
		public int samplerate;

		/** bufferlength_sec
		*/
		public int bufferlength_sec;

		/** constructor
		*/
		public AudioClip_Execute_Default()
		{
			//devicename
			this.devicename = null;

			//audioclip
			this.audioclip = null;

			//usechannel
			this.usechannel = 0;

			//samplerate
			this.samplerate = 48000;

			//bufferlength_sec
			this.bufferlength_sec = 2;
		}

		/** SetDevice
		*/
		public void SetDevice(string a_devicename)
		{
			this.devicename = a_devicename;
		}

		/** SetUseChannel
		*/
		public void SetUseChannel(int a_usechannel)
		{
			this.usechannel = a_usechannel;
		}

		/** SetSampleRate
		*/
		public void SetSampleRate(int a_samplerate)
		{
			this.samplerate = a_samplerate;
		}

		/** [BlueBack.Vosk.AudioClip_Execute_Base]開始。
		*/
		public void Start()
		{
			this.audioclip = UnityEngine.Microphone.Start(this.devicename,true,this.bufferlength_sec,this.samplerate);
			if(this.audioclip != null){
				this.position = 0;
				this.buffer_raw = new float[BLOCK_MAX * this.audioclip.channels];
				this.buffer_short = new short[BLOCK_MAX];
			}
		}

		/** [BlueBack.Vosk.AudioClip_Execute_Base]終了。
		*/
		public void End()
		{
			UnityEngine.Microphone.End(this.devicename);
		}

		/** [BlueBack.Vosk.AudioClip_Execute_Base]サンプルレート。取得。
		*/
		public int GetSampleRate()
		{
			return this.audioclip.frequency;
		}

		/** [BlueBack.Vosk.AudioClip_Execute_Base]チャンネル数。取得。
		*/
		public int GetChannel()
		{
			return this.audioclip.channels;
		}

		/** [BlueBack.Vosk.AudioClip_Execute_Base]位置。取得。
		*/
		public int GetPosition()
		{
			return this.position;
		}

		/** [BlueBack.Vosk.AudioClip_Execute_Base]更新。

			return != null : データあり。

		*/
		public short[] Update()
		{
			if(UnityEngine.Microphone.IsRecording(this.devicename) == true){	
				//position_new
				int t_position_new = UnityEngine.Microphone.GetPosition(this.devicename);

				//audioclip_cannel
				int t_audioclip_cannel = this.audioclip.channels;

				//usechancel
				int t_usechancel = UnityEngine.Mathf.Clamp(this.usechannel,0,t_audioclip_cannel);

				//audioclip_position_max
				int t_audioclip_position_max = this.audioclip.samples * t_audioclip_cannel;

				//blocksize
				int t_blocksize;
				{
					if(t_position_new >= this.position){
						t_blocksize = (t_position_new - this.position) / t_audioclip_cannel;
					}else{
						t_blocksize = ((t_audioclip_position_max * t_audioclip_cannel - (this.position - t_position_new))) / t_audioclip_cannel;
					}
				}
				
				if(t_blocksize >= BLOCK_MAX){
					if(this.audioclip.GetData(this.buffer_raw,this.position) == true){
						//position
						this.position = (this.position + BLOCK_MAX * t_audioclip_cannel) % (t_audioclip_position_max * t_audioclip_cannel);

						//GetData
						for(int ii=0;ii<BLOCK_MAX;ii++){
							this.buffer_short[ii] = (short)(UnityEngine.Mathf.Floor(this.buffer_raw[ii * t_audioclip_cannel + t_usechancel] * short.MaxValue));
						}
						return this.buffer_short;
					}
				}
			}

			return null;
		}
	}
}

