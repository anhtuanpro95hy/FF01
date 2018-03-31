using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace FF{

    [Serializable]
    public class Character{
        public int index; // chi so cua nhan vat
        public float hp; // suc manh cua nhan vat
        public float force; // luc day 
        public bool unlock; // trang thai mo khoa
        public bool use;  // trang thai su dung
        public Character(int _index, float _hp, float _force, bool _unlock, bool _use){
            index = _index;
            hp = _hp;
            force = _force;
            unlock = _unlock;
            use = _use;
        }
    }

    [Serializable]
    public class ListCharacter{
        public Character[] listChar = new Character[50];
    }

    public class UserData : MonoBehaviour
    {
        public static ListCharacter listCharacter = new ListCharacter();

        public static int coin{
            set{
                PlayerPrefs.SetInt("coin", value);
                if(PlayerPrefs.GetInt("coin") < 0){
                    PlayerPrefs.SetInt("coin", 0);
                }
            }
            get{
                return PlayerPrefs.GetInt("coin");
            }
        }


    }
}


