using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AddAchievement : MonoBehaviour
{

    public GameObject[] achievements;
    private int achievementIndex;
    public string thislogin;

    private void Update()
    {
        for (int i = 0; i < achievements.Length; i++)
        {
            if (i == achievementIndex)
            {
                achievements[i].SetActive(true);
            }
            else
            {
                achievements[i].SetActive(false);
            }
        }

        if (achievementIndex == 0)
        {
            if (PlayerMovement.abducted == true)
            {
                AddAchievementOne(PlayerPrefs.GetString("login", thislogin));
            }




            /*           else if (achievementIndex == 1)
                       {

                           if (something)
                           {
                               achievementIndex++;
                           }
                       }

                       else if (achievementIndex == 2)
                       {
                           if (something)
                           {
                               achievementIndex++;
                           }
                       }

                       else if (achievementIndex == 3)
                       {
                           // something to end;
                       } */
        }

    }

    IEnumerator AddAchievementOne(string log)
    {
        PlayerPrefs.GetString("login", log);
        WWWForm wwwf = new WWWForm();
        wwwf.AddField("SQL", "INSERT INTO player_conquista (idPlayer, idConquista) SELECT(SELECT p.id FROM player p WHERE p.login = '" + log + "'), c.idConquista FROM conquista c WHERE c.idConquista = '7'", System.Text.Encoding.UTF8);

        using (var w = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", wwwf))
        {
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                Debug.Log(w.error);
            }
            else
            {
                Players playerContainer = JsonUtility.FromJson<Players>(w.downloadHandler.text);
                if (playerContainer.objetos.Length > 0)
                {
                    achievementIndex++;
                }
            }
        }

    }

}