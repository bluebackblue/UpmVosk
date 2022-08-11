

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
		void Event(BlueBack.Vosk.EventParam_Fix_WordMode a_eventparam);

		/** [BlueBack.Vosk.Execute_Base]Event
		*/
		void Event(BlueBack.Vosk.EventParam_Fix a_eventparam);

		/** [BlueBack.Vosk.Execute_Base]Event
		*/
		void Event(BlueBack.Vosk.EventParam_Partial_WordMode a_eventparam);

		/** [BlueBack.Vosk.Execute_Base]Event
		*/
		void Event(BlueBack.Vosk.EventParam_Partial a_eventparam);
	}
}

