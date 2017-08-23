﻿namespace Gu.Wpf.UiAutomation.Patterns
{
    using Gu.Wpf.UiAutomation.Definitions;
    using Gu.Wpf.UiAutomation.Patterns.Infrastructure;

    public abstract class ExpandCollapsePatternBase<TNativePattern> : PatternBase<TNativePattern>, IExpandCollapsePattern
    {
        private AutomationProperty<ExpandCollapseState> expandCollapseState;

        protected ExpandCollapsePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        /// <inheritdoc/>
        public IExpandCollapsePatternProperties Properties => this.Automation.PropertyLibrary.ExpandCollapse;

        /// <inheritdoc/>
        public AutomationProperty<ExpandCollapseState> ExpandCollapseState => this.GetOrCreate(ref this.expandCollapseState, this.Properties.ExpandCollapseState);

        /// <inheritdoc/>
        public abstract void Collapse();

        /// <inheritdoc/>
        public abstract void Expand();
    }
}
