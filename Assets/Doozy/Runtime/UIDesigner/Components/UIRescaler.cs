// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using UnityEngine;

namespace Doozy.Runtime.UIDesigner.Components
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public class UIRescaler : UnityEngine.EventSystems.UIBehaviour
    {
        private RectTransform m_RectTransform;
        /// <summary> The RectTransform attached to the GameObject </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public RectTransform rectTransform => m_RectTransform ? m_RectTransform : m_RectTransform = GetComponent<RectTransform>();

        [SerializeField] private Vector2 ReferenceSize;
        public Vector2 referenceSize
        {
            get => ReferenceSize;
            set => ReferenceSize = value;
        }
        
        [SerializeField] private Vector2 TargetSize;
        public Vector2 targetSize
        {
            get => TargetSize;
            set => TargetSize = value;
        }

        protected void Reset()
        {
//            base.Reset();

            ReferenceSize = rectTransform.rect.size;
            TargetSize = ReferenceSize;

            UpdateScale();
        }
        
        #if UNITY_EDITOR
        protected override void OnValidate()
        {
            if (IsActive())
            {
                UpdateScale();
            }

            base.OnValidate();
        }
        #endif //UNITY_EDITOR
        
        protected override void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();
            UpdateScale();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            UpdateScale();
        }

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Updates the scale of the RectTransform based on the reference size and the target size
        /// </summary>
        public void UpdateScale()
        {
            Vector2 scale = rectTransform.localScale;
            scale.x = TargetSize.x / ReferenceSize.x;
            scale.y = TargetSize.y / ReferenceSize.y;
            rectTransform.localScale = scale;
        }
    }
}
