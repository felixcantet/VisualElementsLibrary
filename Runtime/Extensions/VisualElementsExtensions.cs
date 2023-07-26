using UnityEngine.UIElements;

namespace FCA.VisualElements
{
    /// <summary>
    /// Static class defining various extension methods for VisualElements.
    /// </summary>
    public static class VisualElementsExtensions
    {
        /// <summary>
        /// Wrapper for the Add method of VisualElement that returns the added element
        /// </summary>
        /// <param name="v"></param>
        /// <param name="other"></param>
        /// <typeparam name="T"></typeparam>
        /// <example>
        /// <code>
        /// VisualElement v = new VisualElement();
        /// var toggle = v.AddChild(new Toggle(){text = "Toggle"})
        /// </code>
        /// </example>
        /// <returns>The added Element of type T where T is a VisualElement</returns>
        public static T AddChild<T>(this VisualElement v, T other) where T : VisualElement
        {
            v.Add(other);
            return other;
        }
    }
}