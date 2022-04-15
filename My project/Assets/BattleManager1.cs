using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager1 : MonoBehaviour
{
    //ゲームマネージャー
    public GameObject GameManager;
    //キャンバス
    public GameObject canvas;
    //バトル全体
    public GameObject[] battleMembers = new GameObject[13];
    //味方の勢力
    public GameObject[] battlePlayers = new GameObject[5];
    //敵の勢力
    public GameObject[] battleEnemies = new GameObject[8];
    //味方のステータス
    public BattleCharaData[] playersStatus = new BattleCharaData[8];
    //敵のステータス
    //味方使用技
    public int[] playerAction = new int[5];
    //味方ターゲット
    public int[] charaTarget=new int[5];
    //敵ターゲット
    public int[] enemyTarget=new int[8];
    //敵使用技
    //味方パネル
    public GameObject playerPanel;
    public GameObject[] panelSet=new GameObject[5];
    //敵パネル
    public GameObject enemyPanel;
    public GameObject[] panelSet2=new GameObject[8];
    //味方標準座標
    public Vector2 defaultPos;
    //敵標準座標
    public Vector2 defaultPos2;
    //ボタンカウント
    public int buttonCount;
    //速度値計算
    public int[] sokudochi = new int[13];
    //ボタンストッパー
    public GameObject buttonStopper;
    //技呼び出し
    delegate int SkillCall(int x);
    // Start is called before the first frame update
    void Start()
    {
        //前シーン削除
        SceneManager.UnloadSceneAsync("SampleScene2");
        
        defaultPos.x = 6;
        defaultPos.y = 3;
        defaultPos2.x = -6;
        defaultPos2.y = 3;
        //キャンバスの座標
        Vector2 canvasPosition = canvas.GetComponent<RectTransform>().transform.position;
        //味方呼び出し
        int i=0;
        int j = 0;
        do
        {
            battlePlayers[i] = GameManager.GetComponent<GameManager>().member[i];
            battleMembers[i]= GameManager.GetComponent<GameManager>().member[i];
            GameObject clone = Instantiate(battleMembers[i], defaultPos, Quaternion.identity, playerPanel.GetComponent<RectTransform>().transform);
            clone.GetComponent<CharaScript>().DataCopy();
            clone.GetComponent<CharaScript>().BattleDataCopy();
            clone.name = clone.GetComponent<CharaScript>().name;
            battlePlayers[i] = clone;
            battleMembers[i] = clone;
            //一旦ボタンを押せなくする
            // clone.GetComponent<Button>().interactable = false;
            clone.GetComponent<ButtonClick4 >().charaNumber=i;
            clone.GetComponent<ButtonClick4>().memberNumber=i;
            clone.GetComponent<CharaScript>().charaPos = defaultPos;
            defaultPos.y -= 2;
           i++;
            if (i == 100)
            {
                Debug.Log("無限ループ！");
                break;
            }
        }while(GameManager.GetComponent<GameManager>().member[i] != null);
        
        //敵呼び出し
       do
        {
            battleEnemies[j]= GameManager.GetComponent<GameManager>().enemyGroup[j];
            battleMembers[i] = GameManager.GetComponent<GameManager>().enemyGroup[j];
            GameObject clone = Instantiate(battleMembers[i], defaultPos2, Quaternion.identity, enemyPanel.GetComponent<RectTransform>().transform);
            clone.name = clone.GetComponent<gobrin>().testdata.name;
            battleEnemies[j] = clone;
            battleMembers[i] = clone;
            GetComponent<ButtonStop>().ButtonStop2();
            GetComponent<ButtonStop>().ButtonStop1();
            // clone.GetComponent<Button>().interactable = false;
            clone.GetComponent<ButtonClick4>().enemyNumber = j;
            clone.GetComponent<ButtonClick4 >().memberNumber = i;
            battleMembers[i].GetComponent<RectTransform>().transform.position = defaultPos2;
          
            defaultPos2.y -= 2;
            i++;
            j++;
            if (i == 100|| j==100)
            {
                Debug.Log("無限ループ！");
                break;
            }
        } while (GameManager.GetComponent<GameManager>().enemyGroup[j] != null);
        i = 0;
        j = 0;
        GetComponent<ButtonStop>().ButtonStop1();
        GetComponent<ButtonStop>().ButtonStop2();   
      
    }

    // Update is called once per frame
    void Update()
    {
        bool down = Input.GetKeyDown(KeyCode.A);
        if (down == true)
        {
            SceneManager.LoadScene("SampleScene2", LoadSceneMode.Additive);
            Resources.UnloadUnusedAssets();
            canvas.SetActive(false);
        }
        
    }
   /*public int RealSkill(int y)
    {
        battleMembers[0].GetComponent<CharaScript>().useSkill[0]
    }*/
}
