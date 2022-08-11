

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief インストール。
*/


/** BlueBack.Vosk.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.Vosk.Editor
{
	/** InstallModel
	*/
	public static class InstallModel
	{
		/** MenuItem_Install_Small_Ja
		*/
		[UnityEditor.MenuItem("BlueBack/Vosk/InstallModel/small-ja")]
		private static void MenuItem_Install_Small_Ja()
		{
			Install("^.*small.*ja.*\\.zip$");
		}

		/** Install
		*/
		private static void Install(string a_zipfile_pattern)
		{
			//ＺＩＰファイル検索。
			string t_path_zip;
			{
				System.Collections.Generic.List<UnityEditor.PackageManager.PackageInfo>  t_list = AssetLib.Editor.CreatePackageList.Create(true,true);

				string t_path_findzip = null;
				for(int ii=0;ii<t_list.Count;ii++){
					if(t_list[ii].name == "blueback.vosk"){
						t_path_findzip = t_list[ii].resolvedPath;
					}
				}
				if(t_path_findzip == null){
					t_path_findzip = UnityEngine.Application.dataPath + "/UPM/Editor/Vosk";
				}

				UnityEngine.Debug.Log(t_path_findzip);

				t_path_zip = BlueBack.AssetLib.FindFileWithFullPath.FindFirst(t_path_findzip,"^.*$",a_zipfile_pattern);
				if(t_path_zip == null){
					UnityEngine.Debug.LogError("NotFound : zipfile");
				}
			}

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

