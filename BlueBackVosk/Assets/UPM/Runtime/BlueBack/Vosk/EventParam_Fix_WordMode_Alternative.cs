

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief イベントパラメータ。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** EventParam_Fix_WordMode_Alternative
	*/
	public struct EventParam_Fix_WordMode_Alternative
	{
		/** confidence
		*/
		public float confidence;

		/** text
		*/
		public string text;

		/** result
		*/
		public EventParam_Fix_WordMode_Result[] result;
	}
}

