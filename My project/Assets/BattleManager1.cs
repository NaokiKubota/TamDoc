using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager1 : MonoBehaviour
{
    //�Q�[���}�l�[�W���[
    public GameObject GameManager;
    //�L�����o�X
    public GameObject canvas;
    //�o�g���S��
    public GameObject[] battleMembers = new GameObject[13];
    //�����̐���
    public GameObject[] battlePlayers = new GameObject[5];
    //�G�̐���
    public GameObject[] battleEnemies = new GameObject[8];
    //�����̃X�e�[�^�X
    public BattleCharaData[] playersStatus = new BattleCharaData[8];
    //�G�̃X�e�[�^�X
    //�����g�p�Z
    public int[] playerAction = new int[5];
    //�����^�[�Q�b�g
    public int[] charaTarget=new int[5];
    //�G�^�[�Q�b�g
    public int[] enemyTarget=new int[8];
    //�G�g�p�Z
    //�����p�l��
    public GameObject playerPanel;
    public GameObject[] panelSet=new GameObject[5];
    //�G�p�l��
    public GameObject enemyPanel;
    public GameObject[] panelSet2=new GameObject[8];
    //�����W�����W
    public Vector2 defaultPos;
    //�G�W�����W
    public Vector2 defaultPos2;
    //�{�^���J�E���g
    public int buttonCount;
    //���x�l�v�Z
    public int[] sokudochi = new int[13];
    //�{�^���X�g�b�p�[
    public GameObject buttonStopper;
    //�Z�Ăяo��
    delegate int SkillCall(int x);
    // Start is called before the first frame update
    void Start()
    {
        //�O�V�[���폜
        SceneManager.UnloadSceneAsync("SampleScene2");
        
        defaultPos.x = 6;
        defaultPos.y = 3;
        defaultPos2.x = -6;
        defaultPos2.y = 3;
        //�L�����o�X�̍��W
        Vector2 canvasPosition = canvas.GetComponent<RectTransform>().transform.position;
        //�����Ăяo��
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
            //��U�{�^���������Ȃ�����
            // clone.GetComponent<Button>().interactable = false;
            clone.GetComponent<ButtonClick4 >().charaNumber=i;
            clone.GetComponent<ButtonClick4>().memberNumber=i;
            clone.GetComponent<CharaScript>().charaPos = defaultPos;
            defaultPos.y -= 2;
           i++;
            if (i == 100)
            {
                Debug.Log("�������[�v�I");
                break;
            }
        }while(GameManager.GetComponent<GameManager>().member[i] != null);
        
        //�G�Ăяo��
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
                Debug.Log("�������[�v�I");
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
