using UnityEngine;
using System.Collections.Generic;

public abstract class Skill : MonoBehaviour, ISokudochiKeisan,IDamageKeisan,HitKeisan
{
    //二段斬り
    public static int hitcount;
    public string skillName;
    [SerializeField]
    protected int shohibp;
    public StatusHosei statusHosei;

    [SerializeField]
    public StatusList StatusList;
    public StatusHosei statusHosei2;
    
    [SerializeField]
    protected int taisho;
    //0:敵単体
    //1:敵全体
    //2:味方単体
    //3:味方全体
    //4:敵単体ランダム
    //5:敵味方単体ランダム
    //6:敵味方全体
    //7:なし
    [SerializeField]
    protected int weapon;
    //0:剣
    //1:大剣
    //2:小剣
    //3:斧
    //4:ハンマー
    //5:槍
    //6:杖
    //7:体術
    //8:弓
    //9:火術
    //10:水術
    //11:風術
    //12:土術
    //13:光術
    //14:闇術
    //15:なし
    [SerializeField]
    protected int zokusei;
    //0:なし
    //1:火
    //2:水
    //3:風
    //4:土
    //5:光
    //6:闇
    [SerializeField]
    protected int type;
    //0:物理
    //1:魔法
    //2:なし
    [SerializeField]
    protected int range;
    //0:近接
    //1:間接
    //2;超間接
    public int price;
    [SerializeField]
    //  protected int sokudo;
    // [SerializeField]
    protected int meichu;
    [SerializeField]
    protected int tokushu;
    //0:なし
    //1:打撃無効
    //1:魔法無効
    //2:最速行動
    //3:最遅行動
    public int mode;
    //1:アタック
    //2:ディフェンス
    //3:トリック
    public GameObject battleManager;
    public GameObject skillUser;
  
    public int Number{get;set;}
    public BattleManager1 battleManager1;
    public IBasicAction userData;
   // public IBasicAction[] targetData = new IBasicAction[13];
  public IBasicAction userData2;
    public MemberCount memberCount;
   //  public IBasicAction[] battleMemberDatas=new IBasicAction[13];
  public bool seiko{get;set;}
    public List<GameObject> targetList=new List<GameObject>();
    public List<IBasicAction> targetDataList=new List<IBasicAction>();
  
    private void Start()
    {
        battleManager = GameObject.FindWithTag("BattleManager");
        battleManager1 = battleManager.GetComponent<BattleManager1>();
        userData=skillUser.GetComponent<IBasicAction>();
        userData2=skillUser.GetComponent<IBasicAction>();
      
        int x = MemberCount.PlayerCount();
        int y = MemberCount.EnemyCount();
        int z = MemberCount.AllMemberCount();
          
        HitCount();
            //本体
            //装備品補正
            //技補正
            //キャラ補正
    }
    public int WeaponSet
    {
        get;set;
    }
    public int TypeSet
    {
        get; set;
    }
    public int ShohiBpSet
    {
        get; set;
    }
public int ZokuseiSet{get;set;}
    public int TaishoSet
    {
        get; set;
    }
    public int SokudoSet
    {
        get; set;
    }
    public int MeichuSet
    {
        get;set;
    }
    public int RangeSet
    {
        get; set;
    }
    public int TokushuSet
    {
        get;set;
    } public virtual int AttackG(int a)
    {
        return (a + 2) * (a + 2) / 16 + 20;
    }

    public virtual int AttackF(int a)
    {
        return (a + 3) * (a + 3) / 12 + 20;
    }

    public virtual int AttackE(int a)
    {
        return (a + 4) * (a + 4) / 8 + 20;
    }
    public virtual int AttackD(int a)
    {
        return (a + 5) * (a + 5) / 6 + 20;
    }
    public virtual int AttackC(int a)
    {
        return (a + 6) * (a + 6) / 4 + 20;
    }
    public virtual int AttackB(int a)
    {
        return (a + 8) * (a + 8) / 2 + 20;
    }
    public virtual int AttackA(int a)
    {
        return (a + 10) * (a + 10) + 20;
    }
    public virtual int AttackS(int a)
    {
        return (a + 12) * (a + 12) * 2 + 20;
    }
    public int SokudochiA(int n)
    {
        return (n + 3) * (n + 3) / 32 * Random.Range(24, 40);

    }
    //速度補正+
    public int SokudochiB(int n)
    {
        return (n + 4) * (n + 4) / 32 * Random.Range(28, 48);
    }
    //速度補正++
    public int SokudochiC(int n)
    {
        return (n + 5) * (n + 5) / 32 * Random.Range(36, 56);
    }
    //速度補正-
    public int SokudochiD(int n)
    {
        return (n + 2) + (n + 2) / 32 * Random.Range(18, 32);
    }

    //速度補正--
    public int SokudochiE(int n)
    {
        return (n + 1) * (n + 1) / 32 * Random.Range(12, 24);
    }
      public virtual bool MeichuKeisan(int a, int b, int c)
    {
        //a:味方の技の基本命中率
        //b:味方の素早さ
        //c:敵の素早さ
        int d = (a + b - c);

       
        if (d >= 100)
        {
            //命中
            return true;
        }
        else if (d <= 0)
        {
            //失敗
            return false;
        }
        else
        {
            int e = Random.Range(0, 99);
            if (e <= d)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    public void StatusHosei()
    {
        
    }
    public virtual int SokudochiHontai(int speed ,ref IBasicAction userData2,ref StatusHosei statusHosei2)
    {        
            int speedCopy=speed;
         if(userData2.sobiWeapon!=null)
         {
           speedCopy=userData2.sobiWeapon.AttackHosei(speedCopy,ref userData2, ref statusHosei2);
         }
         if(userData2.sobiMainBogu!=null)
         {
           speedCopy=userData2.sobiMainBogu.AttackHosei(speedCopy,ref userData,ref statusHosei2);
         }
          if(userData2.sobiSubBogu!=null)
          {
           speedCopy=userData2.sobiSubBogu.AttackHosei(speedCopy,ref userData,ref statusHosei2);
          }
          if(userData2.accessory!=null)
          {
           speedCopy=userData2.accessory.AttackHosei(speedCopy,ref userData,ref statusHosei2);
           }
           speedCopy=userData2.SokudochiCharaHosei(speedCopy,ref userData2,ref statusHosei2);
           return speedCopy;
    }
    public virtual int SokudochiHontai()
    {
        return -1-userData2.MemberNumber;
    }
    public abstract void Hontai();
    
    public virtual void KakushuAttackHosei(int damage, ref IBasicAction userData2,ref StatusHosei statusHosei2)
    {   
         int damageCopy=damage;
         if(userData2.sobiWeapon!=null)
         {
           damageCopy=userData2.sobiWeapon.AttackHosei(damageCopy,ref userData2, ref statusHosei2);
         }
         if(userData2.sobiMainBogu!=null)
         {
           damageCopy=userData2.sobiMainBogu.AttackHosei(damageCopy,ref userData,ref statusHosei2);
         }
          if(userData2.sobiSubBogu!=null)
          {
           damageCopy=userData2.sobiSubBogu.AttackHosei(damageCopy,ref userData,ref statusHosei2);
          }
          if(userData2.accessory!=null)
          {
           damageCopy=userData2.accessory.AttackHosei(damageCopy,ref userData,ref statusHosei2);
           }
        bool seiko=userData2.AttackCharaHosei(damageCopy,ref userData,ref statusHosei2);
  
    }
    public virtual bool KakushuDefenceHosei(int damage,ref IBasicAction userData2,ref StatusHosei statusHosei2)
    {    int damageCopy=damage;
         if(userData2.sobiWeapon!=null)
         {
         damageCopy=userData2.sobiWeapon.DeffenceHosei(damageCopy,ref userData2,ref statusHosei2);
         }
         if(userData2.sobiMainBogu!=null)
         {
         damageCopy=userData2.sobiMainBogu.DeffenceHosei(damageCopy,ref userData2,ref statusHosei2);
         }
         if(userData2.sobiSubBogu!=null)
          {
         damageCopy=userData2.sobiSubBogu.DeffenceHosei(damageCopy,ref userData2,ref statusHosei2);
          }
           if(userData2.accessory!=null)
          {
         damageCopy=userData2.accessory.DeffenceHosei(damageCopy,ref userData2,ref statusHosei2);
          }
         bool seiko=userData2.DeffenceCharaHosei(damageCopy,ref userData2,ref statusHosei2);
         if(seiko==false)
         {
        return false;
       
         }
       return true;
     }
    public virtual void HitCount()
    {
        hitcount = 0;
    }

    
    public virtual bool Mahomukou(int damage)
    {

        int k = Random.Range(0, 9);
        if (k > 0)
        {
            userData.HpSet = 0;
           
            return false;

        }
        userData.HpSet = damage;
        return true;
    }
    public virtual bool DamageReceive(int damage, int type, int taisho,int range,IBasicAction user)
    {
        userData.HpSet=damage;
        return true;
        
    }
    /*public virtual bool DamageReceive(int damage, int type, int taisho, int range, EnemyBattleData user)
    {
        userData.HpSet = damage;
        return true;

    }*/
   //技固有のデータ
    public virtual void StatusNumberCopy()
    {
      
        Number=StatusList.Status[0].number;
       
    }
    public void StatusDataCopy(int number)

    {   
        statusHosei.anger=StatusList.Status[Number].anger;
        statusHosei2.anger=StatusList.Status[number].anger;
        statusHosei.blind=StatusList.Status[Number].blind;
         statusHosei2.blind=StatusList.Status[number].blind;
        statusHosei.charm=StatusList.Status[Number].charm;
        statusHosei2.charm=StatusList.Status[number].blind;
        statusHosei.confuse=StatusList.Status[Number].confuse;
     statusHosei2.confuse=StatusList.Status[number].confuse;
        statusHosei.dark=StatusList.Status[Number].dark;
       statusHosei2.dark=StatusList.Status[number].dark;
        statusHosei.death=StatusList.Status[Number].death;
       statusHosei2.death=StatusList.Status[number].death;
        statusHosei.earth=StatusList.Status[Number].earth;
        statusHosei2.earth=StatusList.Status[number].earth;
        statusHosei.fear=StatusList.Status[Number].fear;
     statusHosei2.fear=StatusList.Status[number].fear;
        statusHosei.fire=StatusList.Status[Number].fire;
       statusHosei2.fire=StatusList.Status[number].fire;
        statusHosei.light1=StatusList.Status[Number].light1;
        statusHosei2.light1=StatusList.Status[number].light1;
        statusHosei.maxBp=StatusList.Status[Number].maxBp;
       statusHosei2.maxBp=StatusList.Status[number].maxBp;
        statusHosei.maxHp=StatusList.Status[Number].maxHp;
        statusHosei2.maxHp=StatusList.Status[number].maxHp;
        statusHosei.maxLp=StatusList.Status[Number].maxLp;
    statusHosei2.maxLp=StatusList.Status[number].maxLp;
        statusHosei.meichu=StatusList.Status[Number].meichu;
       statusHosei2.meichu=StatusList.Status[number].meichu;
        statusHosei.mgc=StatusList.Status[Number].mgc;
        statusHosei2.mgc=StatusList.Status[number].mgc;
        statusHosei.negative=StatusList.Status[Number].negative;
    statusHosei2.negative=StatusList.Status[number].negative;
        statusHosei.poison=StatusList.Status[Number].poison;
       statusHosei2.poison=StatusList.Status[number].poison;
        statusHosei.psy=StatusList.Status[Number].psy;
     statusHosei2.psy=StatusList.Status[number].psy;
        statusHosei.purge=StatusList.Status[Number].purge;
        statusHosei2.purge=StatusList.Status[number].purge;
        statusHosei.Paralysis=StatusList.Status[Number].Paralysis;
        statusHosei2.Paralysis=StatusList.Status[number].Paralysis;
        statusHosei.range=StatusList.Status[Number].range;
         statusHosei2.range=StatusList.Status[number].range;
        statusHosei.shohiBp=StatusList.Status[Number].shohiBp;
         statusHosei2.shohiBp=StatusList.Status[number].shohiBp;
        statusHosei.sleep=StatusList.Status[Number].sleep;
        statusHosei2.sleep=StatusList.Status[number].sleep;
        statusHosei.spd=StatusList.Status[Number].spd;
         statusHosei2.spd=StatusList.Status[number].spd;
        statusHosei.stone=StatusList.Status[Number].stone;
         statusHosei2.stone=StatusList.Status[number].stone;
        statusHosei.str=StatusList.Status[Number].str;
        statusHosei2.str=StatusList.Status[number].str;
        statusHosei.stun=StatusList.Status[Number].stun;
        statusHosei2.stun=StatusList.Status[number].stun;
        statusHosei.taisho=StatusList.Status[Number].taisho;
        statusHosei2.taisho=StatusList.Status[number].taisho;
        statusHosei.tokushu=StatusList.Status[Number].tokushu;
        statusHosei2.tokushu=StatusList.Status[number].tokushu;
        statusHosei.type=StatusList.Status[Number].type;
         statusHosei2.type=StatusList.Status[number].type;
        statusHosei.vit=StatusList.Status[Number].vit;
        statusHosei2.vit=StatusList.Status[number].vit;
        statusHosei.water=StatusList.Status[Number].water;
        statusHosei2.water=StatusList.Status[number].water;
        statusHosei.weapon=StatusList.Status[Number].weapon;
        statusHosei2.weapon=StatusList.Status[number].weapon;
        statusHosei.wind=StatusList.Status[Number].wind;
       statusHosei2.wind=StatusList.Status[number].wind;
    
    }
   
    public virtual void Junbi()
    {   
        if(userData2 is BattleCharaData battleCharaData)
        {
             battleCharaData.BpSet=shohibp;
        } 
        HitCount();
        StatusNumberCopy();
        StatusDataCopy(Number);
        
    }
    public virtual void SokudochiJunbi()
    {
        userData2=skillUser.GetComponent<IBasicAction>();
        statusHosei2=userData2.reservedSkill.GetComponent<StatusHosei>();
    }
    }


