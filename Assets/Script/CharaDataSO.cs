using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharaDataSO", menuName = "Create CharaDataSO")]
public class CharaDataSO : ScriptableObject
{
    public List<CharaData> charaDatasList = new List<CharaData>();

    /// <summary>
    /// SO����L����������
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

        //���������ꍇ�Ɍ������ʂȂ��̌��ʂ��o�����߂ɕK�v
        return null;
    }
}
