

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ＶＯＳＫ。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** Execute_Base
	*/
	public interface Execute_Base
	{
		/** [BlueBack.Vosk.Execute_Base]Event
		*/
		void Event(bool a_success,BlueBack.JsonItem.JsonItem a_eventparam_jsonitem);
	}
}

