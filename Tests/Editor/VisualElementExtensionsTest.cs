using NUnit.Framework;
using UnityEngine.UIElements;

namespace FCA.VisualElements.Tests
{
    public class VisualElementExtensionsTest
    {
        [Test]
        public void VisualElementExtensionsTest_AddChild()
        {
            var v = new VisualElement();
            var toggle = v.AddChild(new Toggle(){text = "Toggle"});
            Assert.NotNull(toggle);
        }
    }
}