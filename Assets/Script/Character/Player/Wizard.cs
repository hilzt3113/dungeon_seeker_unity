using UnityEngine;

public class Wizard : IPlayer
{
    public Wizard(GameObject obj, PlayerAttribute attr) : base(obj, attr)  { }
    protected override void OnCharacterStart()
    {
        base.OnCharacterStart();
        m_StateController.SetOtherState(typeof(WizardIdleState));
    }
    protected override void OnCharacterUpdate()
    {
        base.OnCharacterUpdate();
        if (InputUtility.Instance.GetKeyDown(KeyAction.Skill) && CanUseSkill())
        {
            m_Skill.StartSkill();
        }
    }
    protected override void OnCharaterDieUpdate()
    {
        base.OnCharaterDieUpdate();
        m_StateController.GameUpdate();
    }
}
