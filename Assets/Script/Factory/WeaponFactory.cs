using UnityEngine;

public enum PlayerWeaponType
{
    None,
    BadPistol,
    TheCode,
    H2O,
    CrimsonWineGlass,
    P250Pistol,
    Furnace,
    Icebreaker,
    PKP,
    AK47,
    UZI,
    SnowFoxL,
    AssaultRifle,
    MissileBattery,
    TheCodePlus,
    DesertEagle,
    GrenadePistol,
    NextNextNextGenSMG,
    EagleOfIceAndFire,
    DormantBubbleMachine,
    Basketball,
    Bow,
    Shower,
    GatlingGun,
    DoubleBladeSword,
    WoodenCross,
    BlueFireGatling,
    RainbowGatling,
}
public enum EnemyWeaponType
{
    None,
    Pike,
    Bow,
    Handgun,
    Shotgun,
    TrumpetFlower,
    Blowpipe,
    Hammer,
    Hoe,
    GoblinMagicStaff,
}
public enum WeaponCategory
{
    Pistol,
    Rifle,
    Shotgun,
    Missile,
    Laser,
    Bow,
    CloseCombat,
    Staff,
    ThrownWeapon,
    Other,
}
public class WeaponFactory
{
    private static WeaponFactory instance;
    public static WeaponFactory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WeaponFactory();
            }
            return instance;
        }
    }
    public WeaponFactory()
    {

    }
    public IPlayerWeapon GetPlayerWeapon(PlayerWeaponType type, ICharacter character)
    {
        IPlayerWeapon weapon = null;
        GameObject obj = Object.Instantiate(ProxyResourceFactory.Instance.Factory.GetWeapon(type), UnityTool.Instance.GetGameObjectFromChildren(character.gameObject, "GunOriginPoint").transform);
        obj.transform.localPosition = Vector3.zero;
        UnityTool.Instance.GetComponentFromChild<SpriteRenderer>(obj, type.ToString()).sortingLayerName = "Player";
        UnityTool.Instance.GetComponentFromChild<SpriteRenderer>(obj, type.ToString()).sortingOrder = 0;
        UnityTool.Instance.GetComponentFromChild<BoxCollider2D>(obj, type.ToString()).enabled = false;
        switch (type)
        {
            case PlayerWeaponType.BadPistol:
                weapon = new BadPistol(obj, character);
                break;
          
            case PlayerWeaponType.TheCode:
                weapon = new TheCode(obj, character);
                break;
            
            default: break;
        }
        return weapon;
    }
    public IPlayerWeapon GetPlayerWeapon(PlayerWeaponType type, ICharacter character, Transform parent, string layerName, int order)
    {
        IPlayerWeapon weapon = null;
        GameObject obj = Object.Instantiate(ProxyResourceFactory.Instance.Factory.GetWeapon(type), parent);
        obj.transform.localPosition = Vector3.zero;
        UnityTool.Instance.GetComponentFromChild<SpriteRenderer>(obj, type.ToString()).sortingLayerName = layerName;
        UnityTool.Instance.GetComponentFromChild<SpriteRenderer>(obj, type.ToString()).sortingOrder = order;
        obj.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        switch (type)
        {
            case PlayerWeaponType.BadPistol:
                weapon = new BadPistol(obj, character);
                break;
           
            case PlayerWeaponType.TheCode:
                weapon = new TheCode(obj, character);
                break;
           
        }
        return weapon;
    }
    public IEnemyWeapon GetEnemyWeapon(EnemyWeaponType type, ICharacter character)
    {
        IEnemyWeapon weapon = null;
        GameObject obj = Object.Instantiate(ProxyResourceFactory.Instance.Factory.GetEnemyWeapon(type), character.gameObject.transform.Find("GunOriginPoint"));
        obj.transform.localPosition = Vector3.zero;
        UnityTool.Instance.GetComponentFromChild<SpriteRenderer>(obj, type.ToString()).sortingLayerName = "EnemyWeapon";
        UnityTool.Instance.GetComponentFromChild<SpriteRenderer>(obj, type.ToString()).sortingOrder = 0;
        switch (type)
        {
            case EnemyWeaponType.Handgun:
                weapon = new Handgun(obj, character);
                break;
            case EnemyWeaponType.Bow:
                weapon = new EnemyBow(obj, character);
                break;        
            case EnemyWeaponType.Shotgun:
                weapon = new Shotgun(obj, character);
                break;
            case EnemyWeaponType.Blowpipe:
                weapon = new Blowpipe(obj, character);
                break;        
            case EnemyWeaponType.GoblinMagicStaff:
                weapon = new GoblinMagicStaff(obj, character);
                break;
            default: break;
        }
        return weapon;
    }
    public GameObject GetPlayerWeaponObj(PlayerWeaponType type, Vector2 pos)
    {
        GameObject obj = Object.Instantiate(ProxyResourceFactory.Instance.Factory.GetWeapon(type));
        obj.name=type.ToString();
        UnityTool.Instance.GetComponentFromChild<SpriteRenderer>(obj, type.ToString()).sortingLayerName = "Floor";
        UnityTool.Instance.GetComponentFromChild<SpriteRenderer>(obj, type.ToString()).sortingOrder = 10;
        UnityTool.Instance.GetComponentFromChild<BoxCollider2D>(obj, type.ToString()).enabled = true;
        obj.transform.position = pos;
        return obj;
    }
}
