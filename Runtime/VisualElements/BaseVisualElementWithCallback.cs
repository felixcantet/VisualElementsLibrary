using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace FCA.VisualElements
{
    /// <summary>
    /// Base class for VisualElements that have a value and send a change event when the value is changed.
    /// Use this to avoid boiletplate code for sending change events.
    /// </summary>
    /// <typeparam name="T">Could be any type</typeparam>
    public abstract class BaseVisualElementWithCallback<T> : UnityEngine.UIElements.VisualElement, INotifyValueChanged<T>
    {
        /// <summary>
        /// The protected value that is used to store the value of the element.
        /// </summary>
        protected T _value;

        /// <summary>
        /// Set the contained value without sending a change event.
        /// </summary>
        /// <param name="newValue">The new value of the element</param>
        public void SetValueWithoutNotify(T newValue)
        {
            this._value = newValue;
        }
        
        /// <summary>
        /// The value that is stored in the element.
        /// Trigger a change event when set.
        /// </summary>
        public T value
        {
            get => _value;
            set
            {
                var previousValue = _value;
                SetValueWithoutNotify(value);
                using(ChangeEvent<T> evt = ChangeEvent<T>.GetPooled(previousValue, value))
                {
                    evt.target = this;
                    SendEvent(evt);
                }
            }
        }
    }
}