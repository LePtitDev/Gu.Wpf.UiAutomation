﻿namespace Gu.Wpf.UiAutomation
{
    using System;
    using System.Windows.Automation;

    public class Expander : HeaderedContentControl
    {
        public Expander(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public bool IsExpanded
        {
            get => this.AutomationElement.ExpandCollapsePattern()
                       .Current
                       .ExpandCollapseState == ExpandCollapseState.Expanded;

            set
            {
                if (value)
                {
                    this.Expand();
                }
                else
                {
                    this.Collapse();
                }
            }
        }

        public void Expand()
        {
            if (!this.IsEnabled)
            {
                throw new System.Windows.Automation.ElementNotEnabledException();
            }

            if (this.IsExpanded)
            {
                return;
            }

            if (this.FrameworkType == FrameworkType.WinForms)
            {
                // WinForms
                var openButton = this.FindButton();
                openButton.Invoke();
            }
            else
            {
                // WPF
                this.AutomationElement.ExpandCollapsePattern().Expand();
            }
        }

        /// <summary>
        /// Invokes <see cref="Expand()"/>.
        /// Then waits for <paramref name="delay"/>, useful if there is an animation.
        /// </summary>
        /// <param name="delay">The time to wait after the click. Useful if there is an animation for example.</param>
        public void Expand(TimeSpan delay)
        {
            this.Expand();
            Wait.For(delay);
        }

        public void Collapse()
        {
            if (!this.IsEnabled ||
                !this.IsExpanded)
            {
                return;
            }

            if (this.FrameworkType == FrameworkType.WinForms)
            {
                // WinForms
                var openButton = this.FindButton();
                openButton.Invoke();
            }
            else
            {
                // WPF
                this.AutomationElement.ExpandCollapsePattern().Collapse();
            }

            Wait.UntilResponsive(this);
        }
    }
}