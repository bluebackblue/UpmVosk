

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 初期化パラメータ。
*/


/** BlueBack.Vosk
*/
namespace BlueBack.Vosk
{
	/** ModelTool
	*/
	public static class ModelTool
	{
		/** DownLoadModelList
		*/
		public static System.Collections.IEnumerator DownLoadModelList(ModelListStatus a_status,string a_html_text)
		{
			a_status.error = false;
			a_status.fix = false;
			a_status.list = null;

			//UnityWebRequest
			string t_html = null;
			if(a_html_text == null){
				using(UnityEngine.Networking.UnityWebRequest t_unitywebrequest = UnityEngine.Networking.UnityWebRequest.Get("https://alphacephei.com/vosk/models")){
					UnityEngine.Networking.UnityWebRequestAsyncOperation t_async = t_unitywebrequest.SendWebRequest();
					while(true){
						yield return null;
						if(t_async.isDone == true){
							if(t_unitywebrequest.error != null){
								#if(DEF_BLUEBACK_DEBUG_LOG)
								DebugTool.Log(string.Format("UnityWebRequest : error :{0}",t_unitywebrequest.error));
								#endif
							}else{
								t_html = t_unitywebrequest.downloadHandler.text;
								break;
							}
						}
					}
					t_unitywebrequest.Dispose();
				}
			}else{
				t_html = a_html_text;
			}

			if(t_html != null){
				DownLoadModelList_Work t_work = new DownLoadModelList_Work();
				Inner_DownLoadModelList_Html(t_work,t_html);
				a_status.list = t_work.model_list;
				a_status.fix = true;
			}else{
				a_status.error = true;
			}

			yield break;
		}

		/** DownLoadZip
		*/
		public static System.Collections.IEnumerator DownLoadZip(ModelListItem a_item)
		{
			UnityEngine.Debug.Log(a_item.url);

			byte[] t_data = null;
			{
				using(UnityEngine.Networking.UnityWebRequest t_unitywebrequest = UnityEngine.Networking.UnityWebRequest.Get(a_item.url)){
					UnityEngine.Networking.UnityWebRequestAsyncOperation t_async = t_unitywebrequest.SendWebRequest();
					while(true){
						yield return null;
						if(t_async.isDone == true){
							if(t_unitywebrequest.error != null){
								#if(DEF_BLUEBACK_DEBUG_LOG)
								DebugTool.Log(string.Format("UnityWebRequest : error :{0}",t_unitywebrequest.error));
								#endif
							}else{
								t_data = t_unitywebrequest.downloadHandler.data;
								break;
							}
						}else{
							UnityEngine.Debug.Log(string.Format("{0}",t_async.progress));
						}
					}
					t_unitywebrequest.Dispose();
				}
			}

			UnityEngine.Debug.Log(t_data.Length.ToString());

			if(t_data != null){
				DownLoadZip_Work t_work = new DownLoadZip_Work();
				{
					t_work.zip_download_path = UnityEngine.Application.persistentDataPath + "/model.zip";
					t_work.zip_output_path = UnityEngine.Application.persistentDataPath;
					t_work.zipbinary = t_data;
				}

				System.Threading.Thread t_thread = new System.Threading.Thread((System.Object a_a_object)=>{
					DownLoadZip_Work t_t_work = (DownLoadZip_Work)a_a_object;

					//保存。
					if(BlueBack.AssetLib.SaveBinaryWithFullPath.TrySave(t_t_work.zipbinary,t_t_work.zip_download_path) == false){
						UnityEngine.Debug.Log("error");
					}

					//解凍。
					System.IO.Compression.ZipFile.ExtractToDirectory(t_t_work.zip_download_path,t_t_work.zip_output_path,System.Text.Encoding.UTF8,true);
				});

				t_thread.Start(t_work);

				t_thread.Join();
				t_thread.Abort();
			}
		}

		/** DownLoadZip_Work
		*/
		private class DownLoadZip_Work
		{
			/** zip_download_path
			*/
			public string zip_download_path;

			/** zip_output_path
			*/
			public string zip_output_path;

			/** zipbinary
			*/
			public byte[] zipbinary;
		}

		/** DownLoadModelList_Work
		*/
		private class DownLoadModelList_Work
		{
			/** label_list
			*/
			public System.Collections.Generic.List<string> label_list;

			/** model_list
			*/
			public System.Collections.Generic.List<ModelListItem> model_list;

			/** constructor
			*/
			public DownLoadModelList_Work()
			{
				//label_list
				this.label_list = new System.Collections.Generic.List<string>();

				//model_list
				this.model_list = new System.Collections.Generic.List<ModelListItem>();
			}
		}

		/** 「html」の解析。
		*/
		private static void Inner_DownLoadModelList_Html(DownLoadModelList_Work a_work,string a_text)
		{
			string t_pattern = string.Format("<table{1}>{0}<thead>{2}</thead>{0}<tbody>{3}</tbody>{0}</table>","[\\s\\t\\r\\n]*","(?<table>[\\d\\D]*?)","(?<thead>[\\d\\D]*?)","(?<tbody>[\\d\\D]*?)");
			System.Text.RegularExpressions.MatchCollection t_matchcollection = System.Text.RegularExpressions.Regex.Matches(a_text,t_pattern,System.Text.RegularExpressions.RegexOptions.Multiline);
			int ii_max = t_matchcollection.Count;
			for(int ii=0;ii<ii_max;ii++){
				System.Text.RegularExpressions.Match t_match = t_matchcollection[ii];
				if(t_match.Success == true){
					Inner_DownLoadModelList_Thead(a_work,t_match.Groups["thead"].Value);
					Inner_DownLoadModelList_Tbody(a_work,t_match.Groups["tbody"].Value);
				}
			}
		}

		/** 「thead」の解析。
		*/
		private static void Inner_DownLoadModelList_Thead(DownLoadModelList_Work a_work,string a_text)
		{
			a_work.label_list.Clear();

			string t_pattern = string.Format("<th>{0}{1}{0}</th>","[\\s\\t\\r\\n]*","(?<th>[\\d\\D]*?)");
			System.Text.RegularExpressions.MatchCollection t_matchcollection = System.Text.RegularExpressions.Regex.Matches(a_text,t_pattern,System.Text.RegularExpressions.RegexOptions.Multiline);
			int ii_max = t_matchcollection.Count;
			for(int ii=0;ii<ii_max;ii++){
				System.Text.RegularExpressions.Match t_match = t_matchcollection[ii];
				if(t_match.Success == true){
					a_work.label_list.Add(t_match.Groups["th"].Value);
					#if(DEF_BLUEBACK_DEBUG_LOG)
					DebugTool.Log(string.Format("Label {0} : {1}",ii,a_work.label_list[ii]));
					#endif
				}
			}
		}

		/** 「tbody」の解析。
		*/
		private static void Inner_DownLoadModelList_Tbody(DownLoadModelList_Work a_work,string a_text)
		{
			string t_pattern = string.Format("<tr>{0}{1}{0}</tr>","[\\s\\t\\r\\n]*","(?<tr>[\\d\\D]*?)");
			System.Text.RegularExpressions.MatchCollection t_matchcollection = System.Text.RegularExpressions.Regex.Matches(a_text,t_pattern,System.Text.RegularExpressions.RegexOptions.Multiline);
			int ii_max = t_matchcollection.Count;
			for(int ii=0;ii<ii_max;ii++){
				System.Text.RegularExpressions.Match t_match = t_matchcollection[ii];
				if(t_match.Success == true){
					Inner_DownLoadModelList_Tr(a_work,t_match.Groups["tr"].Value);
				}
			}
		}

		/** 「tr」の解析。
		*/
		private static void Inner_DownLoadModelList_Tr(DownLoadModelList_Work a_work,string a_text)
		{
			string t_pattern = string.Format("<td>{0}{1}{0}</td>","[\\s\\t\\r\\n]*","(?<td>[\\d\\D]*?)");
			System.Text.RegularExpressions.MatchCollection t_matchcollection = System.Text.RegularExpressions.Regex.Matches(a_text,t_pattern,System.Text.RegularExpressions.RegexOptions.Multiline);
			int ii_max = t_matchcollection.Count;
			ModelListItem t_item = new ModelListItem();
			for(int ii=0;ii<ii_max;ii++){
				System.Text.RegularExpressions.Match t_match = t_matchcollection[ii];
				if(t_match.Success == true){
					switch(a_work.label_list[ii]){
					case "Model":
						{
							Inner_DownLoadModeList_Model(ref t_item,t_match.Groups["td"].Value);
						}break;
					case "Size":
						{
							t_item.size = t_match.Groups["td"].Value;
						}break;
					case "Word error rate/Speed":
						{
							t_item.rate = t_match.Groups["td"].Value;
						}break;
					case "Notes":
						{
							t_item.note = t_match.Groups["td"].Value;
						}break;
					case "License":
						{
							t_item.license = t_match.Groups["td"].Value;
						}break;
					default:
						{
							#if(DEF_BLUEBACK_DEBUG_LOG)
							DebugTool.Assert(false,string.Format("{0} : {1}",ii,a_work.label_list[ii]));
							#endif
						}break;
					}
				}
			}

			if((t_item.url != null)&&(t_item.name != null)){
				if((t_item.url.Length > 0)&&(t_item.name.Length > 0)){
					a_work.model_list.Add(t_item);
				}
			}
		}

		/** Inner_DownLoadModeList_Model
		*/
		private static void Inner_DownLoadModeList_Model(ref ModelListItem a_item,string a_text)
		{
			string t_pattern = string.Format("<a{0}href{0}\\={0}\\\"{1}\\\"{0}>{2}</a>","[\\s\\t\\r\\n]*","(?<a_url>[\\d\\D]*?)","(?<a_name>[\\d\\D]*?)");
			System.Text.RegularExpressions.Match t_match = System.Text.RegularExpressions.Regex.Match(a_text,t_pattern,System.Text.RegularExpressions.RegexOptions.Multiline);
			if(t_match.Success == true){
				a_item.url = t_match.Groups["a_url"].Value;
				a_item.name = t_match.Groups["a_name"].Value;
			}else{
				a_item.url = null;
				a_item.name = null;
			}
		}
	}
}

