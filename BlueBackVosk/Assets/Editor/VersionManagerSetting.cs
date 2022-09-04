

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
			//UssUxml保存。
			BlueBack.VersionManager.Editor.Execute_Root_UssUxml_Save.Execute(false);

			//projectparam
			BlueBack.VersionManager.Editor.Execute_Editor_ProjectParamJson_Load.Execute();

			//object_root_readme_md
			BlueBack.VersionManager.Editor.StaticValue.readmemd_creator_callback = new BlueBack.VersionManager.Editor.ReadmeMdCreator.CallBackType[]{

				//概要。
				(in BlueBack.VersionManager.Editor.ReadmeMdCreator.Argument a_argument) => {
					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
					t_list.Add("# " + BlueBack.VersionManager.Editor.StaticValue.editor_projectparam_json.namespace_author + "." + BlueBack.VersionManager.Editor.StaticValue.editor_projectparam_json.namespace_package);
					t_list.AddRange(BlueBack.VersionManager.Editor.ReadmeMdCreator.Create_RootReadMd_Overview(a_argument));
					return t_list.ToArray();
				},

				//ライセンス。
				(in BlueBack.VersionManager.Editor.ReadmeMdCreator.Argument a_argument) => {
					return new string[]{
						"## ライセンス",
						"MIT License",
						"* " + BlueBack.VersionManager.Editor.StaticValue.editor_projectparam_json.git_url + "/blob/main/LICENSE",
					};
				},

				//依存。
				(in BlueBack.VersionManager.Editor.ReadmeMdCreator.Argument a_argument) => {
					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
					t_list.Add("## 依存 / 使用ライセンス等");
					t_list.AddRange(BlueBack.VersionManager.Editor.ReadmeMdCreator.Create_RootReadMd_Asmdef_Dependence(a_argument));
					return t_list.ToArray();
				},

				//動作確認。
				(in BlueBack.VersionManager.Editor.ReadmeMdCreator.Argument a_argument) => {
					return new string[]{
						"## 動作確認",
						"Unity " + UnityEngine.Application.unityVersion,
					};
				},

				//UPM。
				(in BlueBack.VersionManager.Editor.ReadmeMdCreator.Argument a_argument) => {
					return new string[]{
						"## UPM",
						"### 最新",
						"* " + BlueBack.VersionManager.Editor.StaticValue.editor_projectparam_json.git_url + ".git?path=" + BlueBack.VersionManager.Editor.StaticValue.editor_projectparam_json.git_path + "#" + a_argument.version,
						"### 開発",
						"* " + BlueBack.VersionManager.Editor.StaticValue.editor_projectparam_json.git_url + ".git?path=" + BlueBack.VersionManager.Editor.StaticValue.editor_projectparam_json.git_path,
					};
				},

				//インストール。 
				(in BlueBack.VersionManager.Editor.ReadmeMdCreator.Argument a_argument) => {
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
				(in BlueBack.VersionManager.Editor.ReadmeMdCreator.Argument a_argument) => {
					System.Collections.Generic.List<string> t_list = new System.Collections.Generic.List<string>();
					t_list.AddRange(BlueBack.VersionManager.Editor.ReadmeMdCreator.Create_RootReadMd_Exsample(a_argument));
					return t_list.ToArray();
				},
			};
		}
		#else
		{
		}
		#endif
	}
}
#endif

