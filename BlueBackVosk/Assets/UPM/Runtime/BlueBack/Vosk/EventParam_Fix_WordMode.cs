

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief イベントパラメータ。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** EventParam_Fix_WordMode
	*/
	public struct EventParam_Fix_WordMode
	{
		/** alternatives
		*/
		public EventParam_Fix_WordMode_Alternative[] alternatives;

		/** text

			「alternatives == 0」の場合。

		*/
		public string text;

		/** result

			「alternatives == 0」の場合。

		*/
		public EventParam_Fix_WordMode_NoAlternative_Result[] result;
	}
}

