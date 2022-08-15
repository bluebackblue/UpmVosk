

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 初期化パラメータ。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** ModelListStatus
	*/
	public sealed class ModelListStatus
	{
		/** fix
		*/
		public bool fix;

		/** error
		*/
		public bool error;

		/** list
		*/
		public System.Collections.Generic.List<ModelListItem> list;

		/** constructor
		*/
		public ModelListStatus()
		{
			//fix
			this.fix = false;

			//error
			this.error = false;

			//list
			this.list = new System.Collections.Generic.List<ModelListItem>();
		}
	}
}

