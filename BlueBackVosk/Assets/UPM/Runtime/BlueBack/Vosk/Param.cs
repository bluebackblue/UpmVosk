

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 初期化パラメータ。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** Param
	*/
	#if(UNITY_EDITOR)
	[System.Serializable]
	#endif
	public struct Param
	{
		/** audio
		*/
		public string audio_device_name;
		public int audio_use_channel;

		/** microphone
		*/
		public UnityEngine.AudioClip microphone_audioclip;
		public int microphone_position;
		public float[] microphone_buffer_float;
		public byte[] microphone_buffer_byte;
		public int microphone_blockcount_multi;
		public int microphone_blockcount_single;

		/** vosk
		*/
		public bool vosk_wordmode;
	}
}

