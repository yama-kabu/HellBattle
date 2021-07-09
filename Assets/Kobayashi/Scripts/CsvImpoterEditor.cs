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
		DrawDefaultInspector(); //inspector��ŃZ�b�g����CSV�t�@�C�����Q�Ƃ���

		if (GUILayout.Button("�e�f�[�^�̍쐬"))
		{
			// Debug.Log("�e�f�[�^�̍쐬�{�^���������ꂽ");
			SetCsvDataToScriptableObject(csvImpoter);
		}
	}

	#region CSV�t�@�C���̓ǂݍ��݁A�p�[�X�A�l�̃Z�b�g�A�A�Z�b�g�̕ۑ�
	void SetCsvDataToScriptableObject(CsvImporter csvImporter)
	{
		// �{�^���������ꂽ��p�[�X���s
		if (csvImporter.csvFile == null)
		{
			Debug.LogWarning(csvImporter.name + " : �ǂݍ���CSV�t�@�C�����Z�b�g����Ă��܂���B");
			return;
		}

		// csv�t�@�C����string�`���ɕϊ�
		string csvText = csvImporter.csvFile.text;

		// ���s���ƂɃp�[�X
		string[] afterParse = csvText.Split('\n');

		// �w�b�_�[�s�������ăC���|�[�g
		for (int i = 1; i < afterParse.Length; i++)
		{
			string[] parseByComma = afterParse[i].Split(',');

			int column = 0; //���ΓI�ɗ�����炷

			// �擪�̗񂪋�ł���΂��̍s�͓ǂݍ��܂Ȃ�
			if (parseByComma[column] == "")
			{
				continue;
			}

			// �s����ID�Ƃ��ăt�@�C�����쐬
			string fileName = "bulletData_" + i.ToString("D4") + ".asset";
			string path = "Assets/Kobayashi/Editor/" + fileName;

			// EnemyData�̃C���X�^���X����������ɍ쐬
			var bulletData = CreateInstance<BulletData>();

			// ���O
			bulletData.bulletName = parseByComma[column];

			// �ő�HP
			column += 1;
			bulletData.m_hp = int.Parse(parseByComma[column]);

			// �U����
			column += 1;
			bulletData.m_atk = int.Parse(parseByComma[column]);

			// �C���X�^���X���������̂��A�Z�b�g�Ƃ��ĕۑ�
			var asset = (BulletData)AssetDatabase.LoadAssetAtPath(path, typeof(BulletData));
			if (asset == null)
			{
				// �w��̃p�X�Ƀt�@�C�������݂��Ȃ��ꍇ�͐V�K�쐬
				AssetDatabase.CreateAsset(bulletData, path);
			}
			else
			{
				// �w��̃p�X�Ɋ��ɓ����̃t�@�C�������݂���ꍇ�͍X�V
				EditorUtility.CopySerialized(bulletData, asset);
				AssetDatabase.SaveAssets();
			}
			AssetDatabase.Refresh();
		}
		Debug.Log(csvImporter.name + " : �e�f�[�^�̍쐬���������܂����B");
	}
	#endregion
}
