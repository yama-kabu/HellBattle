using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CsvImporter))]
public class CsvImpoterEditor : Editor
{
	public override void OnInspectorGUI()
	{
		var csvImpoter = target as CsvImporter;
		DrawDefaultInspector(); //inspector上でセットしたCSVファイルを参照する

		if (GUILayout.Button("弾データの作成"))
		{
			// Debug.Log("弾データの作成ボタンが押された");
			SetCsvDataToScriptableObject(csvImpoter);
		}
	}

	#region CSVファイルの読み込み、パース、値のセット、アセットの保存
	void SetCsvDataToScriptableObject(CsvImporter csvImporter)
	{
		// ボタンを押されたらパース実行
		if (csvImporter.csvFile == null)
		{
			Debug.LogWarning(csvImporter.name + " : 読み込むCSVファイルがセットされていません。");
			return;
		}

		// csvファイルをstring形式に変換
		string csvText = csvImporter.csvFile.text;

		// 改行ごとにパース
		string[] afterParse = csvText.Split('\n');

		// ヘッダー行を除いてインポート
		for (int i = 1; i < afterParse.Length; i++)
		{
			string[] parseByComma = afterParse[i].Split(',');

			int column = 0; //相対的に列をずらす

			// 先頭の列が空であればその行は読み込まない
			if (parseByComma[column] == "")
			{
				continue;
			}

			// 行数をIDとしてファイルを作成
			string fileName = "bulletData_" + i.ToString("D4") + ".asset";
			string path = "Assets/Kobayashi/Editor/" + fileName;

			// EnemyDataのインスタンスをメモリ上に作成
			var bulletData = CreateInstance<BulletData>();

			// 名前
			bulletData.bulletName = parseByComma[column];

			// 最大HP
			column += 1;
			bulletData.m_hp = int.Parse(parseByComma[column]);

			// 攻撃力
			column += 1;
			bulletData.m_atk = int.Parse(parseByComma[column]);

			// インスタンス化したものをアセットとして保存
			var asset = (BulletData)AssetDatabase.LoadAssetAtPath(path, typeof(BulletData));
			if (asset == null)
			{
				// 指定のパスにファイルが存在しない場合は新規作成
				AssetDatabase.CreateAsset(bulletData, path);
			}
			else
			{
				// 指定のパスに既に同名のファイルが存在する場合は更新
				EditorUtility.CopySerialized(bulletData, asset);
				AssetDatabase.SaveAssets();
			}
			AssetDatabase.Refresh();
		}
		Debug.Log(csvImporter.name + " : 弾データの作成が完了しました。");
	}
	#endregion
}
