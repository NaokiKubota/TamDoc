using UnityEngine;
using System.Collections.Generic;

public abstract class Skill : MonoBehaviour, ISokudochiKeisan,IDamageKeisan,HitKeisan
{
    //“ñ’ia‚è
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
    //0:“G’P‘Ì
    //1:“G‘S‘Ì
    //2:–¡•û’P‘Ì
    //3:–¡•û‘S‘Ì
    //4:“G’P‘Ìƒ‰ƒ“ƒ_ƒ€
    //5:“G–¡•û’P‘Ìƒ‰ƒ“ƒ_ƒ€
    //6:“G–¡•û‘S‘Ì
    //7:‚È‚µ
    [SerializeField]
    protected int weapon;
    //0:Œ•
    //1:‘åŒ•
    //2:¬Œ•
    //3:•€
    //4:ƒnƒ“ƒ}[
    //5:‘„
    //6:ñ
    //7:‘Ìp
    //8:‹|
    //9:‰Îp
    //10:…p
    //11:•—p
    //12:“yp
    //13:Œõp
    //14:ˆÅp
    //15:‚È‚µ
    [SerializeField]
    protected int zokusei;
    //0:‚È‚µ
    //1:‰Î
    //2:…
    //3:•—
    //4:“y
    //5:Œõ
    //6:ˆÅ
    [SerializeField]
    protected int type;
    //0:•¨—
    //1:–‚–@
    //2:‚È‚µ
    [SerializeField]
    protected int range;
    //0:‹ßÚ
    //1:ŠÔÚ
    //2;’´ŠÔÚ
    public int price;
    [SerializeField]
    //  protected int sokudo;
    // [SerializeField]
    protected int meichu;
    [SerializeField]
    protected int tokushu;
    //0:‚È‚µ
    //1:‘ÅŒ‚–³Œø
    //1:–‚–@–³Œø
    //2:Å‘¬s“®
    //3:Å’xs“®
    public int mode;
    //1:ƒAƒ^ƒbƒN
    //2:ƒfƒBƒtƒFƒ“ƒX
    //3:ƒgƒŠƒbƒN
    public GameObject battleManager;
    public GameObject skillUser;
    public GameObject[] targetChara = new GameObject[13];
    public int Number{get;set;}
    public BattleManager1 battleManager1;
    public IBasicAction userData;
   // public IBasicAction[] targetData = new IBasicAction[13];
  public IBasicAction userData2;
    public MemberCount memberCount;
   //  public IBasicAction[] battleMemberDatas=new IBasicAction[13];
  
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
            //–{‘Ì
            //‘•”õ•i•â³
            //‹Z•â³
            //ƒLƒƒƒ‰•â³
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
    //‘¬“x•â³+
    public int SokudochiB(int n)
    {
        return (n + 4) * (n + 4) / 32 * Random.Range(28, 48);
    }
    //‘¬“x•â³++
    public int SokudochiC(int n)
    {
        return (n + 5) * (n + 5) / 32 * Random.Range(36, 56);
    }
    //‘¬“x•â³-
    public int SokudochiD(int n)
    {
        return (n + 2) + (n + 2) / 32 * Random.Range(18, 32);
    }

    //‘¬“x•â³--
    public int SokudochiE(int n)
    {
        return (n + 1) * (n + 1) / 32 * Random.Range(12, 24);
    }
      public virtual bool MeichuKeisan(int a, int b, int c)
    {
        //a:–¡•û‚Ì‹Z‚ÌŠî–{–½’†—¦
        //b:–¡•û‚Ì‘f‘‚³
        //c:“G‚Ì‘f‘‚³
        int d = (a + b - c);

       
        if (d >= 100)
        {
            //–½’†
            return true;
        }
        else if (d <= 0)
        {
            //¸”s
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
    public virtual int SokudochiHontai()
    {        
            return userData.SokudochiA(userData.SpdSet);       
    }
    
    public abstract void Hontai();
    
    public virtual void KakushuAttackHosei(int damage, ref IBasicAction userData2,ref StatusHosei statusHosei2)
    {   
         int damageCopy=damage;
           damageCopy=userData2.sobiWeapon.AttackHosei(damageCopy,ref userData2, ref statusHosei2);
           damageCopy=userData2.sobiMainBogu.AttackHosei(damageCopy,ref userData,ref statusHosei2);
           damageCopy=userData2.sobiSubBogu.AttackHosei(damageCopy,ref userData,ref statusHosei2);
           damageCopy=userData2.accessory.AttackHosei(damageCopy,ref userData,ref statusHosei2);
           damageCopy=userData2.AttackCharaHosei(damageCopy,ref userData,ref statusHosei2);
  
    }
    public virtual void KakushuDefenceHosei(int damage,ref IBasicAction userData2,ref StatusHosei statusHosei2)
    {    int damageCopy=damage;
         damageCopy=userData2.sobiWeapon.DeffenceHosei(damageCopy,ref userData2,ref statusHosei2);
         damageCopy=userData2.sobiMainBogu.DeffenceHosei(damageCopy,ref userData2,ref statusHosei2);
         damageCopy=userData2.sobiSubBogu.DeffenceHosei(damageCopy,ref userData2,ref statusHosei2);
         damageCopy=userData2.accessory.DeffenceHosei(damageCopy,ref userData2,ref statusHosei2);
         userData2.DeffenceCharaHosei(damageCopy,ref userData2,ref statusHosei2);

       HitCount();   
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
    public virtual bool DamageReceive2(int damage,int type,int taisho)
    {
        userData.HpSet = damage;
        return true;
    }
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
   /* public void CharaDataCopy()
    {
        userData2.userDatasec=userData;
        userData2.MaxLp=statusHosei.maxLp;
        userData2.MaxBp=statusHosei.maxBp;
        userData2.MaxHp=statusHosei.maxHp;
        userData2.Str=statusHosei.str;
        userData2.Vit=statusHosei.vit;
        userData2.Mgc=statusHosei.mgc;
        userData2.Psy=statusHosei.psy;
        userData2.Spd=statusHosei.spd;
        userData2.Anger=statusHosei.anger;
        userData2.Blind=statusHosei.blind;
        userData2.Charm=statusHosei.charm;
        userData2.Confuse=statusHosei.confuse;
        userData2.Dark=statusHosei.dark;
        userData2.Death=statusHosei.death;
        userData2.Earth=statusHosei.earth;
        userData2.Fear=statusHosei.fear;
        userData2.Fire=statusHosei.fire;
        userData2.Light=statusHosei.light1;
        userData2.Negative=statusHosei.negative;
        userData2.Paralysis=statusHosei.Paralysis;
        userData2.Poison=statusHosei.poison;
        userData2.Purge=statusHosei.purge;
        userData2.Sleep=statusHosei.sleep;
        userData2.Stone=statusHosei.stone;
        userData2.Stun=statusHosei.stun;
        userData2.Water=statusHosei.water;
        //userData2.Weakness=userData.Weakness+StatusList.Status[Number].weakness;
        userData2.Wind=statusHosei.wind;
        userData2.meichu=statusHosei.meichu;
        userData2.Type=statusHosei.type;
        userData2.Taisho=statusHosei.taisho;
        userData2.tokushu=statusHosei.tokushu;
    }*/
    public void Junbi()
    {
        userData.BpSet=shohibp;
        HitCount();
        StatusNumberCopy();
        StatusDataCopy(Number);
        //CharaDataCopy();
    }
    }


