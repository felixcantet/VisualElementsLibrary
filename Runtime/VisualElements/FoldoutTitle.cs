using UnityEngine;
using UnityEngine.UIElements;

namespace FCA.VisualElements
{
    /// <summary>
    /// Foldout title is a Foldout with a Title Box
    /// The clickable Area of the Foldout is the whole title box
    /// </summary>
    public class FoldoutTitle : BaseVisualElementWithCallback<bool>
    {
        protected Foldout m_foldout;
        protected string m_title;

        public string Title => m_title;
        
        public FoldoutTitle(string title)
        {
            m_title = title;
            m_foldout = new Foldout()
            {
                text = title,
                style = { fontSize = 16}
            };
            m_foldout.viewDataKey = "foldout-expanded-state";
            m_foldout.RegisterValueChangedCallback(x => x.StopPropagation());
            var foldoutToggle = m_foldout.Q<Toggle>();
            foldoutToggle.style.marginLeft = 2;
            foldoutToggle.style.backgroundColor = UnityEngine.Color.black;
            foldoutToggle.style.unityTextAlign = TextAnchor.MiddleCenter;
            foldoutToggle.style.alignContent = Align.Center;
            var foldoutLabel = foldoutToggle.Q<Label>();
            foldoutLabel.style.flexGrow = 1;
            var toggleCheckmark = foldoutToggle.Q<VisualElement>("unity-checkmark");
            toggleCheckmark.style.display = DisplayStyle.None;
            this.Add(m_foldout);
        }
        
        /// <summary>
        /// Update the title of the Foldout
        /// </summary>
        /// <param name="title">The new title</param>
        public void SetTitle(string title)
        {
            m_title = title;
            m_foldout.text = title;
        }
        
        /// <summary>
        /// Manually set the expanded state of the Foldout
        /// </summary>
        /// <param name="expanded">The desired expanded state</param>
        public void SetFoldoutState(bool expanded)
        {
            m_foldout.value = expanded;
        }

        /// <summary>
        /// Add an element to the Foldout
        /// Wez don't want to specify a contentContainer in this case
        /// </summary>
        /// <param name="element">The element to add</param>
        /// <returns>The added element</returns>
        public T AddToFoldout<T>(T element) where T : VisualElement
        {
            m_foldout.Add(element);
            return element;
        }
    }
}