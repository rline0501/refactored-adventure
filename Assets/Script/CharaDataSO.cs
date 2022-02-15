using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharaDataSO", menuName = "Create CharaDataSO")]
public class CharaDataSO : ScriptableObject
{
    public List<CharaData> charaDatasList = new List<CharaData>();

    /// <summary>
    /// SOからキャラを検索
    /// </summary>
    /// <param name="searchCharaNo"></param>
    /// <returns></returns>
    public CharaData GetCharaData(int searchCharaNo)
    {
        foreach(CharaData data in charaDatasList)
        {
            if(data.charaNo == searchCharaNo)
            {
                return data;
            }
        }

        //無かった場合に検索結果なしの結果を出すために必要
        return null;
    }
}
