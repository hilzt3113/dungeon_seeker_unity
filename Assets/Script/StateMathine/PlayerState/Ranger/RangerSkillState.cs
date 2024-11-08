public class RangerSkillState : PlayerState
{
    public RangerSkillState(PlayerStateController controller) : base(controller) { }
    protected override void StateStart()
    {
        base.StateStart();
        player.m_Skill.StartSkill();
    }
    protected override void StateUpdate()
    {
        base.StateUpdate();
        if (!player.m_Skill.isSkillUpdate)
        {
            m_Controller.SetOtherState(typeof(RangerIdleState));
        }
    }
    protected override void StateEnd()
    {
        base.StateEnd();
    }
}
