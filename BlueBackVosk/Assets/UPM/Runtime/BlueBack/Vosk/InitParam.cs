

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 初期化パラメータ。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** InitParam
	*/
	public struct InitParam
	{
		/** execute
		*/
		public Execute_Base execute;

		/** audioclip_execute
		*/
		public AudioClip_Execute_Base audioclip_execute;

		/** modelpath
		*/
		public string modelpath;



		#if(false)


		/** wordmode
		*/
		public bool wordmode;

		/** partial_wordmode
		*/
		public bool partial_wordmode;

		/** alternative_max
		*/
		public int alternative_max;

		/** audio_blockcount
		*/
		public int audio_blockcount;

		/** audio_sample
		*/
		public int audio_sample;

		/** audio_buffer_per_sec
		*/
		public int audio_buffer_per_sec;

		/** audio_device_name
		*/
		public string audio_device_name;

		/** audio_use_channel
		*/
		public int audio_use_channel;

		#endif

		/** CreateDefault
		*/
		public static InitParam CreateDefault()
		{
			return new InitParam(){
				execute = null,
				audioclip_execute = new BlueBack.Vosk.AudioClip_Execute_Default(),
				modelpath = "",

				/*
				wordmode = true,
				partial_wordmode = false,
				alternative_max = 2,
				audio_blockcount = 1024,
				audio_sample = 16000,
				audio_buffer_per_sec = 1,
				audio_device_name = "",
				audio_use_channel = 0,
				*/
			};
		}
	}
}

