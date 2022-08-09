

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

		/** modelpath
		*/
		public string modelpath;

		/** wordmode
		*/
		public bool wordmode;

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

		/** CreateDefault
		*/
		public static InitParam CreateDefault()
		{
			return new InitParam(){
				execute = null,
				modelpath = "",
				wordmode = true,
				alternative_max = 2,
				audio_blockcount = 1024,
				audio_sample = 16000,
				audio_buffer_per_sec = 1,
				audio_device_name = "",
				audio_use_channel = 0,
			};
		}
	}
}

