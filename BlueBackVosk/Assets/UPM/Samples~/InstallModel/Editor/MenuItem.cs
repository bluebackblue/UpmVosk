

/** BlueBack.Vosk.Samples.InstallModel.Editor
*/
#if(!DEF_BLUEBACK_VOSK_SAMPLES_DISABLE)
namespace BlueBack.Vosk.Samples.InstallModel.Editor
{
	/** MenuItem
	*/
	public static class MenuItem
	{
		/** MenuItem_InstallModel_Jp
		*/
		[UnityEditor.MenuItem("Samples/BlueBack.Vosk/InstallModel/Jp")]
		private static void MenuItem_InstallModel_Jp()
		{
			string t_path_output_root = UnityEngine.Application.streamingAssetsPath + "/Vosk";
			string t_path_output_model = UnityEngine.Application.streamingAssetsPath + "/Vosk/vosk-model-small-ja-0.22";
			string t_meta_output_model = UnityEngine.Application.streamingAssetsPath + "/Vosk/vosk-model-small-ja-0.22.meta";

			//ディレクトリの削除。
			if(BlueBack.AssetLib.ExistDirectoryWithFullPath.Check(t_path_output_model) == true){
				if(BlueBack.AssetLib.DeleteDirectoryWithFullPath.TryDelete(t_path_output_model) == true){
					UnityEngine.Debug.Log(string.Format("Delete : {0}",t_path_output_model));
				}else{
					UnityEngine.Debug.LogError(string.Format("Delete : ERROR : {0}",t_path_output_model));
				}

				if(BlueBack.AssetLib.DeleteFileWithFullPath.TryDelete(t_meta_output_model) == true){
					UnityEngine.Debug.Log(string.Format("Delete : {0}",t_meta_output_model));
				}else{
					UnityEngine.Debug.LogError(string.Format("Delete : ERROR : {0}",t_meta_output_model));
				}
			}

			//Refresh
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();

			#if(USERDEF_BLUEBACK_VOSK)
			string t_path_zip = UnityEngine.Application.dataPath + "/UPM/Editor/Vosk/vosk-model-small-ja-0.22.zip";
			#else
			string t_path_zip = UnityEngine.Application.dataPath + "/UPM/Editor/Vosk/vosk-model-small-ja-0.22.zip";
			#endif

			//解凍。
			{
				System.IO.Compression.ZipFile.ExtractToDirectory(t_path_zip,t_path_output_root,System.Text.Encoding.UTF8,true);
			}

			//Refresh
			BlueBack.AssetLib.Editor.RefreshAssetDatabase.Refresh();
		}
	}
}
#endif

