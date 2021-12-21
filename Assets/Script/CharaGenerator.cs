using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaGenerator : MonoBehaviour
{
    //�z�u����L������Prefab���i�݌v�}�j
    [SerializeField]
    private GameObject charaPrefab;

    //

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
                float z = Mathf.RoundToInt(hit.point.z)+0.5f;

                //GameObject�^�ϐ���CharaPrefab�����̉�
                GameObject chara = Instantiate(charaPrefab);

                //�擾����x,z���W�Ɏ��̉��������L����Prefab��z�u����
                chara.transform.position = new Vector3(x, 0, z);
            }

        }

    }
}
