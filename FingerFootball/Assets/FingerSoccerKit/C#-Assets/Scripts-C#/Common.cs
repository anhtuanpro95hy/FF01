using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using FF;
namespace FF{
    public class Common : MonoBehaviour
    {
        public static void LoadJsonListChar(){
            string FilePath = Path.Combine(Application.dataPath, "ListCharacter.txt"); // lay duong dan file
            string json = File.ReadAllText(FilePath);
            UserData.listCharacter = JsonUtility.FromJson<ListCharacter>(json);

        }
        public static void EditJsonListChar(Character _char)
        {
            LoadJsonListChar();
            for (int i = 0; i < UserData.listCharacter.listChar.Length; i++)
            {
                if (_char.index == UserData.listCharacter.listChar[i].index)
                {
                    UserData.listCharacter.listChar[i] = _char;
                }
            }

            File.WriteAllText(Path.Combine(Application.dataPath, "ListCharacter.txt"), JsonUtility.ToJson(UserData.listCharacter));  // luu file json
        }
        public static void ResetListChar(){
            //LoadJsonListChar();
            Debug.Log(UserData.listCharacter.listChar.Length);
            for (int i = 0; i < 50; i++){
                UserData.listCharacter.listChar[i] = new Character(i, 1, 10, false, false);
                Debug.Log(i);
            }
            File.WriteAllText(Path.Combine(Application.dataPath, "ListCharacter.txt"),JsonUtility.ToJson(UserData.listCharacter));
            Debug.Log("List: "+ File.ReadAllText(Path.Combine(Application.dataPath, "ListCharacter.txt")));
        }

    }
}

