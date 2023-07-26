using NUnit.Framework;
using FCA.VisualElements;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace FCA.VisualElements.Tests
{
    public class FoldoutsTest
    {
        private EditorWindow window;
        
        /// <summary>
        /// Initialize a Window before each test
        /// So we can test the Value Changed Callbacks
        /// </summary>
        [SetUp]
        public void OnBeforeTest()
        {
            window = EditorWindow.CreateWindow<EditorWindow>();    
        }
        
        /// <summary>
        /// Clear the window after each test
        /// </summary>
        [TearDown]
        public void OnAfterTest()
        {
            window.Close();
        }
        
        [Test]
        public void FoldoutTests_FoldoutTitleIsSet()
        {
            var titleFoldout = new FoldoutTitle("Title");
            var foldout = titleFoldout.Q<Foldout>();
            Assert.AreEqual(foldout.text, "Title");
        }
        
        [Test]
        public void FoldoutTests_AddToFoldout()
        {
            var titleFoldout = new FoldoutTitle("Title");
            var button = new Button();
            var returnValue = titleFoldout.AddToFoldout(new Button());
            var foldoutQuery = titleFoldout.Q<Foldout>();
            var buttonQuery = foldoutQuery.Q<Button>();
            Assert.NotNull(buttonQuery);
            Assert.AreEqual(buttonQuery, returnValue);
        }

        [Test]
        public void FoldoutTests_ToggleEventIsRegisteredAndTrigger()
        {
            var toggleFoldout = new FoldoutToggle("Title", false);
            var toggleState = false;
            // Event required to be attach to a panel to be trigger, we create a window to attach it to
            window.rootVisualElement.Add(toggleFoldout);
            toggleFoldout.RegisterToggleCallback(x =>
            {
                toggleState = true;
            });
            toggleFoldout.toggle.value = true; // Should Trigger Event
            Assert.IsTrue(toggleState);
        }
    }
}