

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief VoskDll
*/


/** BlueBack.Vosk.Dll
*/
namespace BlueBack.Vosk.Dll
{
	/** VoskDll
	*/
	public sealed class VoskDll
	{
		/** vosk
		*/
		public global::Vosk.Model model;

		/** voskrecognizer
		*/
		public global::Vosk.VoskRecognizer voskrecognizer;

		/** constructor
		*/
		public VoskDll(string a_modelpath,int a_sample,int a_alternative_max,bool a_wordmode)
		{
			this.model = new global::Vosk.Model(a_modelpath);
			this.voskrecognizer = new global::Vosk.VoskRecognizer(this.model,a_sample);
			{
				this.voskrecognizer.SetMaxAlternatives(a_alternative_max);
				this.voskrecognizer.SetWords(a_wordmode);
			}
		}

		/** Check
		*/
		public bool Check()
		{
			//model
			if(this.model == null){
				return false;
			}

			//voskrecognizer
			if(this.voskrecognizer == null){
				return false;
			}

			return true;
		}

		/** Apply

			return(bool success,string jsonstring)
				success == true		: 成功
				jsonstring			: JSON。

		*/
		public System.ValueTuple<bool,string> Apply(byte[] a_buffer)
		{
			if(this.voskrecognizer.AcceptWaveform(a_buffer,a_buffer.Length) == true){
				return (true,this.voskrecognizer.Result());
			}else{
				return (false,this.voskrecognizer.PartialResult());
			}
		}
	}
}

