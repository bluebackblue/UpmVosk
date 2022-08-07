

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 設定。
*/


/** define
*/
#if((ASMDEF_BLUEBACK_VERSIONMANAGER)||(USERDEF_BLUEBACK_VERSIONMANAGER))
#define ASMDEF_TRUE
#else
#warning "ASMDEF_TRUE"
#endif


/** Editor
*/
#if(UNITY_EDITOR)
namespace Editor
{
	/** VersionManagerSetting
	*/
	[UnityEditor.InitializeOnLoad]
	public static class VersionManagerSetting
	{
		/** VersionManagerSetting
		*/
		static VersionManagerSetting()
		#if(ASMDEF_TRUE)
		{
			//Object_RootUssUxml
			BlueBack.VersionManager.Editor.Object_RootUssUxml.Save(false);

			//projectparam
			BlueBack.VersionManager.Editor.Object_Setting.projectparam = BlueBack.VersionManager.Editor.ProjectParam.Load();

			//object_root_readme_md
			BlueBack.VersionManager.Editor.Object_Setting.object_root_readme_md = new BlueBack.VersionManager.Editor.Object_Setting.Creator_Type[]{

				//概要。
				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
					t_list.Add("# " + BlueBack.VersionManager.Editor.Object_Setting.projectparam.namespace_author + "." + BlueBack.VersionManager.Editor.Object_Setting.projectparam.namespace_package);
					t_list.AddRange(BlueBack.VersionManager.Editor.Object_Setting.Create_RootReadMd_Overview(a_argument));
					return t_list.ToArray();
				},

				//ライセンス。
				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					return new string[]{
						"## ライセンス",
						"MIT License",
						"* " + BlueBack.VersionManager.Editor.Object_Setting.projectparam.git_url + "/blob/main/LICENSE",
					};
				},

				//依存。
				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
					t_list.Add("## 依存 / 使用ライセンス等");
					t_list.AddRange(BlueBack.VersionManager.Editor.Object_Setting.Create_RootReadMd_Asmdef_Dependence(a_argument));
					return t_list.ToArray();
				},

				//動作確認。
				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					return new string[]{
						"## 動作確認",
						"Unity " + UnityEngine.Application.unityVersion,
					};
				},

				//UPM。
				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					return new string[]{
						"## UPM",
						"### 最新",
						"* " + BlueBack.VersionManager.Editor.Object_Setting.projectparam.git_url + ".git?path=" + BlueBack.VersionManager.Editor.Object_Setting.projectparam.git_path + "#" + a_argument.version,
						"### 開発",
						"* " + BlueBack.VersionManager.Editor.Object_Setting.projectparam.git_url + ".git?path=" + BlueBack.VersionManager.Editor.Object_Setting.projectparam.git_path,
					};
				},

				//インストール。 
				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					return new string[]{
						"## Unityへの追加方法",
						"* Unity起動",
						"* メニュー選択：「Window->Package Manager」",
						"* ボタン選択：「左上の＋ボタン」",
						"* リスト選択：「Add package from git URL...」",
						"* 上記UPMのURLを追加「 https://github.com/～～/UPM#バージョン 」",
						"### 注",
						"Gitクライアントがインストールされている必要がある。",
						"* https://docs.unity3d.com/ja/current/Manual/upm-git.html",
						"* https://git-scm.com/",
					};
				},

				//例。
				(in BlueBack.VersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
					t_list.AddRange(BlueBack.VersionManager.Editor.Object_Setting.Create_RootReadMd_Exsample(a_argument));
					return t_list.ToArray();
				},
			};
		}
		#else
		{
			#warning "ASMDEF_TRUE"
		}
		#endif
	}
}
#endif

