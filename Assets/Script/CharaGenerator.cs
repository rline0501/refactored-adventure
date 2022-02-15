using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaGenerator : MonoBehaviour
{
    //�z�u����L������Prefab���i�݌v�}�j
    [SerializeField]
    private CharaBase charaPrefab;

    //
    [SerializeField]
    public CharaDataSO charaDataSO;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //mousePotision�Ŏw�肵�����W�Ɍ������ăJ��������Ray�𔭎˂���
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Ray�̉���(���ˌ��A�p�x*�����A�F�A������)
            Debug.DrawRay(ray.origin, ray.direction*50, Color.blue, 1.0f);

            //Ray�����m�������W�̏��𓾂邱�Ƃ��o���邩�i��ʊO�Ȃǂ��N���b�N�����犴�m���Ȃ��j
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity) == true)
            {
                //Ray�̓��������}�X��x���W�l���ۂ߂Đ����ɂ���x�ɑ���i�}�X�������W�p�j
                float x = Mathf.RoundToInt(hit.point.x);

                //Ray�̓��������}�X��z���W�l���ۂ߂Đ����ɂ���z�ɑ���i�}�X�������W�p�j
                float z = Mathf.RoundToInt(hit.point.z);

                //GameObject�^�ϐ���CharaPrefab�����̉�(SO�Q�Ƃ��Đ������郁�\�b�h�ɒu������)
                GenerateChara(new Vector3(x, hit.point.y, z));

                Debug.Log("�L������z�u");

                

                //���������L�����ɃX�e�[�^�X��ݒ�
                //chara.SetCharaStates(100, 10);
            }

        }

    }

    /// <summary>
    /// �L�����𐶐����āA�L�����ʂ̃X�e�[�^�X���㏑������
    /// </summary>
    private void GenerateChara(Vector3 newPos)
    {
        ///�����������L�����̔ԍ���CharaDataSO�֐錾����SO������𓾂�B���邽�߂̃��\�b�h��p��
        CharaData charaData = charaDataSO.GetCharaData(0);

        ///�L��������
        CharaBase chara = Instantiate(charaPrefab, transform.position, Quaternion.identity);
        
        //�擾����x,z���W�Ɏ��̉��������L����Prefab��z�u����
        chara.transform.position = newPos;

        ///�L�����̏����X�e�[�^�X���A�ŏ��ɏE����CharaDataSO�̃L�����f�[�^�ŏ㏑������
        ///�L�����̃f�[�^���������L�����ϐ�����CharaBase���Q�b�g���āA�����Ɋ��ł���悤�ɂ��Ă��烁�\�b�h��SO�̃f�[�^�ɏ㏑������
        chara.SetCharaStates(charaData);
    }
}
