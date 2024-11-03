using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace MiddleScene
{
    public class PanelBattle : IPanel
    {
        private Slider SliderHp;
        private Slider SliderMp;
        private Slider SliderArmor;
        private TextMeshProUGUI TextHp;
        private TextMeshProUGUI TextMp;
        private TextMeshProUGUI TextArmor;
        private TextMeshProUGUI TextGem;
        public PanelBattle(IPanel parent) : base(parent)
        {
            m_GameObject = UnityTool.Instance.GetGameObjectFromCanvas(GetType().Name);
            children.Add(new PanelPause(this));
       }
        protected override void OnInit()
        {
            base.OnInit();
            SliderHp = UnityTool.Instance.GetComponentFromChild<Slider>(m_GameObject, "SliderHp");
            SliderMp = UnityTool.Instance.GetComponentFromChild<Slider>(m_GameObject, "SliderMp");
            SliderArmor = UnityTool.Instance.GetComponentFromChild<Slider>(m_GameObject, "SliderArmor");
            TextHp = UnityTool.Instance.GetComponentFromChild<TextMeshProUGUI>(SliderHp.gameObject, "Text");
            TextMp = UnityTool.Instance.GetComponentFromChild<TextMeshProUGUI>(SliderMp.gameObject, "Text");
            TextArmor = UnityTool.Instance.GetComponentFromChild<TextMeshProUGUI>(SliderArmor.gameObject, "Text");
            TextGem = UnityTool.Instance.GetComponentFromChild<TextMeshProUGUI>(m_GameObject, "TextGem");
            UnityTool.Instance.GetComponentFromChild<Button>(m_GameObject, "ButtonPause").onClick.AddListener(() =>
            {
                EnterPanel(typeof(PanelPause));
                m_GameObject.SetActive(false);
            });
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            SliderHp.value = GetPlayer().m_Attr.CurrentHp / (float)GetPlayer().m_Attr.m_ShareAttr.MaxHp;
            SliderArmor.value = GetPlayer().m_Attr.CurrentArmor / (float)GetPlayer().m_Attr.m_ShareAttr.Armor;
            SliderMp.value = GetPlayer().m_Attr.CurrentMp / (float)GetPlayer().m_Attr.m_ShareAttr.Magic;
            TextHp.text = GetPlayer().m_Attr.CurrentHp + "/" + GetPlayer().m_Attr.m_ShareAttr.MaxHp;
            TextMp.text = GetPlayer().m_Attr.CurrentMp + "/" + GetPlayer().m_Attr.m_ShareAttr.Magic;
            TextArmor.text = GetPlayer().m_Attr.CurrentArmor + "/" + GetPlayer().m_Attr.m_ShareAttr.Armor;
            TextGem.text = ArchiveCommand.Instance.GetMaterialNum(MaterialType.Gem).ToString();
            //if(Input.GetKeyDown(KeyCode.B))
            //{
            //    EnterPanel(typeof(PanelBackpack));
            //}
        }
        private IPlayer GetPlayer()
        {
            return GameMediator.Instance.GetController<PlayerController>().Player;
        }
    }

}
