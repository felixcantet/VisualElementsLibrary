using UnityEngine;
using UnityEngine.UIElements;

namespace FCA.VisualElements
{
    public class FoldoutToggle : FoldoutTitle
    {
        private Toggle m_toggle;
        
        public Toggle toggle => m_toggle;
        public FoldoutToggle(string title, bool defaultState) : base(title)
        {
            this.m_toggle = this.AddChild(new Toggle()
            {
                style =
                {
                    position = Position.Absolute,
                    left = 10,
                    height = 20,
                    width = 20
                },
                value = defaultState
            });
            _value = defaultState;
        }

        public void RegisterToggleCallback(EventCallback<ChangeEvent<bool>> evt)
        {
            m_toggle.RegisterValueChangedCallback(evt);
        }
    }
}