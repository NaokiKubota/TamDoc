using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField]
    protected string skillName;
    [SerializeField]
    protected int shohibp;
    [SerializeField]
    protected int iryoku;
    [SerializeField]
    protected int taisho;
    [SerializeField]
    protected int price;
    [SerializeField]
    protected int sokudo;
    [SerializeField]
    protected int meichu;
    [SerializeField]
    protected int range;
    public GameObject battleManager;
    public GameObject skillUser;
    public int skillID;


    public int taishoInfo
    {get;set;}
    public string NameInfo
    {
        set
        {
            skillName = value;
        }
        get
        {
            return skillName;
        }
    }

    private void Start()
    { 
    
   
    } 

}
