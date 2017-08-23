﻿namespace Gu.Wpf.UiAutomation.Patterns
{
    using Gu.Wpf.UiAutomation.Definitions;
    using Gu.Wpf.UiAutomation.Patterns.Infrastructure;
    using Gu.Wpf.UiAutomation.Shapes;

    public abstract class TextPatternBase<TNativePattern> : PatternBase<TNativePattern>, ITextPattern
    {
        protected TextPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        /// <inheritdoc/>
        public ITextPatternEvents Events => this.Automation.EventLibrary.Text;

        /// <inheritdoc/>
        public abstract ITextRange DocumentRange { get; }

        /// <inheritdoc/>
        public abstract SupportedTextSelection SupportedTextSelection { get; }

        /// <inheritdoc/>
        public abstract ITextRange[] GetSelection();

        /// <inheritdoc/>
        public abstract ITextRange[] GetVisibleRanges();

        /// <inheritdoc/>
        public abstract ITextRange RangeFromChild(AutomationElement child);

        /// <inheritdoc/>
        public abstract ITextRange RangeFromPoint(Point point);
    }
}