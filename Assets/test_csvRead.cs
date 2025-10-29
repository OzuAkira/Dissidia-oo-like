using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;　//追加
using System.Collections.Generic;
public class test_csvRead : MonoBehaviour
{
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvData = new List<string[]>(); // CSVファイルの中身を入れるリスト

    async void Start()
    {
        csvFile = await Addressables.LoadAssetAsync<TextAsset>("svsets/PlayerParameters.csv").Task;
        StringReader reader = new StringReader(csvFile.text); // TextAssetをStringReaderに変換

        Dictionary<string, float> cell = new Dictionary<string, float>();//エクセルでいう”セル”
        List<Dictionary<string, float>> table = new List<Dictionary<string, float>>();//テーブル（エクセルシート）
        List<string> calumns = new List<string>();




        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); // 1行ずつ読み込む
            csvData.Add(line.Split(',')); // csvDataリストに追加する
        }
        foreach (string c in csvData[0])
        {
            calumns.Add(c);
        }
        Debug.Log(calumns.Count);
        Debug.Log(csvData.Count);
        for (int i = 1; i < csvData.Count; i++) // csvDataリストの条件を満たす値の数（全て）
        {
            
            for (int c = 0; c < calumns.Count; c++)
            {
                Debug.Log(calumns[c]+" "+csvData[i][c]);
                table[i].Add(calumns[c],float.Parse(csvData[i-1][c]));
            }
        }
        //Debug.Log("---");
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(table[i]["id"] + " " + table[i]["name"]);
        }
    }
}

