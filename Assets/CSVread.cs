using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AddressableAssets;
public class CSVread : MonoBehaviour
{
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvData = new List<string[]>(); // CSVファイルの中身を入れるリスト
    static private Dictionary<string, Dictionary<string, string>> table = new Dictionary<string, Dictionary<string, string>>();
    //データテーブル（スクリプト上で扱うデータベース的な？）
    //↑他のスクリプト（クラス）からも参照する変数
    static public bool isLoaded = false;
    async void Awake()
    {
        csvFile = await Addressables.LoadAssetAsync<TextAsset>("svsets/PlayerParameters.csv").Task;
        StringReader reader = new StringReader(csvFile.text); // TextAssetをStringReaderに変換

        List<string> columns = new List<string>();
        List<string> names = new List<string>();
        
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1行ずつ読み込む
            csvData.Add(line.Split(',')); // csvDataリストに追加する
        }
        foreach (string c in csvData[0])//Columnの文字列を取得
        {
            columns.Add(c);
        }
        foreach (string[] n in csvData)//各Indexの[name]Columnを取得
        {
            names.Add(n[1]);
        }



        for (int i = 0; i < csvData.Count; i++)
        {
            Dictionary<string, string> row = new Dictionary<string, string>();

            for (int c = 0; c < columns.Count; c++)
            {
                row.Add(columns[c], csvData[i][c]);
            }

            table.Add(names[i], row);
        }
        isLoaded = true;//tableの読み込みが完了したときのフラグ
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            getCharactorData("侍","id");
        }
    }
    static public string getCharactorData(string name , string columns)//string型の変数を返す関数を定義
    {
        string ans = "None";
        if (isLoaded)
        {
            if (table.ContainsKey(name)==false) ans = "None_1";
            else if (table[name].ContainsKey(columns)==false) ans = "None_2";
            else ans = table[name][columns];
        }
        Debug.Log("【クエリログ】返り値= " + ans + " , 引数1(name)= " + name + " , 引数2(columns)= " + columns);//長期デバッグ用
        return ans;
    }
}