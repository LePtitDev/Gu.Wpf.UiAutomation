﻿namespace Gu.Wpf.UiAutomation.Patterns
{
    using Gu.Wpf.UiAutomation.Definitions;
    using Gu.Wpf.UiAutomation.Patterns.Infrastructure;

    public abstract class TogglePatternBase<TNativePattern> : PatternBase<TNativePattern>, ITogglePattern
    {
        private AutomationProperty<ToggleState> toggleState;

        protected TogglePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        /// <inheritdoc/>
        public ITogglePatternProperties Properties => this.Automation.PropertyLibrary.Toggle;

        /// <inheritdoc/>
        public AutomationProperty<ToggleState> ToggleState => this.GetOrCreate(ref this.toggleState, this.Properties.ToggleState);

        /// <inheritdoc/>
        public abstract void Toggle();
    }
}
