using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FF;

public class UpdateChar : MonoBehaviour {
    public Transform listCharacterUse;
    public Transform lisrCharacter;
    public GameObject itemCharacter;

    public Text txtCoin;

    public void CharUpdate(int _index, float _hp, float _force, bool _unlock, bool _use){
        Character _char = new Character(_index, _hp, _force, _unlock, _use);
        Common.EditJsonListChar(_char);
    }

    public void Close_Onclick(){

    }

    public void OnEnable()
    {
        txtCoin.text = UserData.coin.ToString();
        LoadListItem();
        
    }
    void LoadListItem(){
        Common.LoadJsonListChar();
        for (int i = 0; i < UserData.listCharacter.listChar.Length; i++){
            createItem(UserData.listCharacter.listChar[i]);
        }
    }

    void createItem(Character _char)
    {
        GameObject go = Instantiate(itemCharacter, transform.position, Quaternion.identity);
        go.GetComponent<ItemCharacter>().SetItem(_char.force, _char.hp, _char.index, _char.unlock, _char.use);
        if (_char.use)
        {
            go.transform.SetParent(GameObject.Find("UpdateController").GetComponent<UpdateChar>().listCharacterUse);
        }
        else
        {
            go.transform.SetParent(GameObject.Find("UpdateController").GetComponent<UpdateChar>().lisrCharacter);
        }
        go.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }

    public void btnCoin_Onclick(){
        
    }

}
