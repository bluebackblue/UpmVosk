

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief イベントパラメータ。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** EventParam_Partial_WordMode
	*/
	public struct EventParam_Partial_WordMode
	{
		/** partial
		*/
		public string partial;

		/** partial_result
		*/
		public EventParam_Partial_WordMode_Result[] partial_result;
	}
}

