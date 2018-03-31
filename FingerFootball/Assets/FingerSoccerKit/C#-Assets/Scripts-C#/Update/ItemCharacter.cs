using System.Collections;
using System.Collections.Generic;
using FF;
using UnityEngine;
using UnityEngine.UI;

public class ItemCharacter : MonoBehaviour {
    public GameObject btnUpdateForce;
    public GameObject btnUpdateHp;

    public Image imgItem;
    public Text txtForce;
    public Text txtHp;
    public int index;
    public bool unlock;
    public bool use;

    public void SetItem( float _force, float _hp, int _index, bool _unlock, bool _use){
        txtForce.text ="Force: "+ _force;
        txtHp.text =   "Hp   : "+ _hp;
        index = _index;
        unlock = _unlock;
        use = _use;
        if(!unlock){ // chua unlock thi an nang cap
            btnUpdateForce.SetActive(false);
            btnUpdateHp.SetActive(false);
        }
    }

    public void btnItem_Onclick(){
        Common.LoadJsonListChar();
        Character _char = UserData.listCharacter.listChar[index];
        if(!UserData.listCharacter.listChar[index].unlock){            
            if(UserData.coin >= Config.coinChar){
                UserData.coin -= Config.coinChar;
                _char.unlock = true;
                Common.EditJsonListChar(_char);
                Debug.Log("Mua character thanh cong");
            }else{
                Debug.Log("Ko du coin de mua");
            }

        }else{
            if (UserData.listCharacter.listChar[index].use)
            {
                _char.use = false;
                Common.EditJsonListChar(_char);
                createItem(_char);
                Debug.Log("Loai bo thanh cong");
                Destroy(gameObject);
                return;
            }
            int temp =0;
            for (int i = 0; i < UserData.listCharacter.listChar.Length; i++){
                if(UserData.listCharacter.listChar[i].use){
                    temp += 1;
                }
            }
            if(temp >=5){
                Debug.Log("Ban chi dc su dung toi da 5 character");
                return;
            }else{
                _char.use = true;
                Common.EditJsonListChar(_char);
                Debug.Log("Su dung thanh cong");
                createItem(_char);
                Destroy(gameObject);
            }

        }
    }

    public void UpdateForce_Onclick(){
        Common.LoadJsonListChar();
        Character _char = UserData.listCharacter.listChar[index];
        if (UserData.coin >= Config.coinUpdate)
        {
            UserData.coin -= Config.coinUpdate;
            _char.force += _char.force * Config.percentUpdate; 
            Common.EditJsonListChar(_char);
        }else{
            Debug.Log("ko du coin");
        }
    }

    public void UpdateHp_Onclick(){
        Common.LoadJsonListChar();
        Character _char = UserData.listCharacter.listChar[index];
        if (UserData.coin >= Config.coinUpdate)
        {
            UserData.coin -= Config.coinUpdate;
            _char.hp += _char.hp * Config.percentUpdate;
            Common.EditJsonListChar(_char);
        }else
        {
            Debug.Log("ko du coin");
        }
    }

    void createItem(Character _char){
        GameObject go = Instantiate(GameObject.Find("UpdateController").GetComponent<UpdateChar>().itemCharacter, transform.position, Quaternion.identity);

        go.GetComponent<ItemCharacter>().SetItem(_char.force, _char.hp, _char.index, _char.unlock,_char.use);
        if(_char.use){
            go.transform.SetParent(GameObject.Find("UpdateController").GetComponent<UpdateChar>().listCharacterUse);
        }else{
            go.transform.SetParent(GameObject.Find("UpdateController").GetComponent<UpdateChar>().lisrCharacter);
        }

        go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

    }


}
