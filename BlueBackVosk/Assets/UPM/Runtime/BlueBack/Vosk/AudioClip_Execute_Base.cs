

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＶＯＳＫ。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** AudioClip_Execute_Base
	*/
	public interface AudioClip_Execute_Base
	{
		/** [BlueBack.Vosk.AudioClip_Execute_Base]開始。
		*/
		void Start();

		/** [BlueBack.Vosk.AudioClip_Execute_Base]終了。
		*/
		void End();

		/** [BlueBack.Vosk.AudioClip_Execute_Base]サンプルレート。取得。
		*/
		int GetSampleRate();

		/** [BlueBack.Vosk.AudioClip_Execute_Base]チャンネル数。取得。
		*/
		int GetChannel();

		/** [BlueBack.Vosk.AudioClip_Execute_Base]位置。取得。
		*/
		int GetPosition();

		/** [BlueBack.Vosk.AudioClip_Execute_Base]更新。

			return != null : データあり。

		*/
		short[] Update();
	}
}

