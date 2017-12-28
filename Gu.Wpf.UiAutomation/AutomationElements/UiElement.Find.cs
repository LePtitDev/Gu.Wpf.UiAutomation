﻿namespace Gu.Wpf.UiAutomation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;

    public partial class UiElement
    {
        /// <summary>
        /// Find the first <see cref="CheckBox"/> by x:Name, Content or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public CheckBox FindCheckBox(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.CheckBox, name),
            x => new CheckBox(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="ToggleButton"/> by x:Name, Content or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public ToggleButton FindToggleButton(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.Button, name),
            x => new ToggleButton(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="RadioButton"/> by x:Name, Content or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public RadioButton FindRadioButton(string name) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.RadioButton, name),
            x => new RadioButton(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="Button"/> by x:Name, Content or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public Button FindButton(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.Button, name),
            x => new Button(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="Slider"/> by x:Name, Content or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public Slider FindSlider(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.Slider, name),
            x => new Slider(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="ProgressBar"/> by x:Name, Content or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public ProgressBar FindProgressBar(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.ProgressBar, name),
            x => new ProgressBar(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="ComboBox"/> by x:Name, Content or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public ComboBox FindComboBox(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.ComboBox, name),
            x => new ComboBox(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="TextBlock"/> by x:Name, Content or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public TextBlock FindTextBlock(string name = null)
        {
            var condition = this.CreateCondition(ControlType.Text, name);
            if (this.TryFindFirst(
                TreeScope.Descendants,
                condition,
                x => new TextBlock(x),
                Retry.Time,
                out var textBlock))
            {
                return textBlock;
            }

            foreach (var child in TreeWalker.RawViewWalker.GetChildren(this.AutomationElement))
            {
                if (child.Current.ControlType.Id == ControlType.Text.Id)
                {
                    textBlock = new TextBlock(child);
                    if (textBlock.AutomationId == name ||
                        textBlock.Text == name)
                    {
                        return textBlock;
                    }
                }
                else if (this.TryFindFirst(
                    TreeScope.Descendants,
                    condition,
                    x => new TextBlock(x),
                    Retry.Time,
                    out textBlock))
                {
                    return textBlock;
                }
            }

            return this.FindFirst(
                TreeScope.Descendants,
                condition,
                x => new TextBlock(x),
                Retry.Time);
        }

        /// <summary>
        /// Find the first <see cref="Label"/> by x:Name, Content or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public Label FindLabel(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.Text, name),
            x => new Label(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="TextBox"/> by x:Name, Content or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public TextBox FindTextBox(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.Edit, name),
            x => new TextBox(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="TabControl"/> by x:Name, Content or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public TabControl FindTabControl(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.Tab, name),
            x => new TabControl(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="UserControl"/> by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public UserControl FindUserControl(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.Custom, name),
            x => new UserControl(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="GroupBox"/> box by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public GroupBox FindGroupBox(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.Group, name),
            x => new GroupBox(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="Expander"/> by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public Expander FindExpander(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.Group, name),
            x => new Expander(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="Menu"/> by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public Menu FindMenu(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.Menu, name),
            x => new Menu(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="MenuItem"/> by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public MenuItem FindMenuItem(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.MenuItem, name),
            x => new MenuItem(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="HorizontalScrollBar"/> by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public HorizontalScrollBar FindHorizontalScrollBar(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.ScrollBar, name),
            x => new HorizontalScrollBar(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="VerticalScrollBar"/> bar by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public VerticalScrollBar FindVerticalScrollBar(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.ScrollBar, name),
            x => new VerticalScrollBar(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="ListBox"/> by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public ListBox FindListBox(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.List, name),
            x => new ListBox(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="ListView"/> by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public ListView FindListView(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.DataGrid, name),
            x => new ListView(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="DataGrid"/> by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public DataGrid FindDataGrid(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.DataGrid, name),
            x => new DataGrid(x),
            Retry.Time);

        /// <summary>
        /// Find the first <see cref="TreeView"/> by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        public TreeView FindTreeView(string name = null) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(ControlType.Tree, name),
            x => new TreeView(x),
            Retry.Time);

        /// <summary>
        /// Find the first descendant by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        /// <param name="controlType">The control type</param>
        public UiElement FindDescendant(string name, ControlType controlType) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(controlType, name),
            Retry.Time);

        /// <summary>
        /// Find the first element by x:Name, Header or AutomationID
        /// </summary>
        /// <param name="name">x:Name, Content or AutomationID</param>
        /// <param name="controlType">The control type</param>
        /// <param name="wrap">The function to produce a T from the match. Normally x => new Foo(x)</param>
        public T FindDescendant<T>(string name, ControlType controlType, Func<AutomationElement, T> wrap)
            where T : UiElement => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(controlType, name),
            wrap,
            Retry.Time);

        public UiElement FindDescendant(ControlType controlType) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(controlType),
            Retry.Time);

        public T FindDescendant<T>(ControlType controlType, Func<AutomationElement, T> wrap)
            where T : UiElement => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(controlType),
            wrap,
            Retry.Time);

        public UiElement FindDescendant(ControlType controlType, int index) => this.FindAt(
            TreeScope.Descendants,
            this.CreateCondition(controlType),
            index,
            Retry.Time);

        public T FindDescendant<T>(ControlType controlType, int index, Func<AutomationElement, T> wrap)
            where T : UiElement => this.FindAt(
            TreeScope.Descendants,
            this.CreateCondition(controlType),
            index,
            wrap,
            Retry.Time);

        public UiElement FindDescendant(ControlType controlType, string name) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(controlType, name),
            Retry.Time);

        public T FindDescendant<T>(ControlType controlType, string name, Func<AutomationElement, T> wrap)
            where T : UiElement => this.FindFirst(
            TreeScope.Descendants,
            this.CreateCondition(controlType),
            wrap,
            Retry.Time);

        public UiElement FindDescendant(string name) => this.FindFirst(
            TreeScope.Descendants,
            this.CreateNameOrIdCondition(name),
            Retry.Time);

        /// <summary>
        /// Finds all elements in the given treescope and with the given condition.
        /// </summary>
        public IReadOnlyList<UiElement> FindAll(TreeScope treeScope, ConditionBase condition)
        {
            return this.AutomationElement.FindAll(treeScope, condition, x => new UiElement(x));
        }

        /// <summary>
        /// Finds all elements in the given treescope and with the given condition.
        /// </summary>
        public IReadOnlyList<T> FindAll<T>(TreeScope treeScope, ConditionBase condition, Func<AutomationElement, T> wrap)
            where T : UiElement
        {
            return this.AutomationElement.FindAll(treeScope, condition, wrap);
        }

        /// <summary>
        /// Finds all elements in the given treescope and with the given condition within the given timeout.
        /// </summary>
        public IReadOnlyList<UiElement> FindAll(TreeScope treeScope, ConditionBase condition, TimeSpan timeOut)
        {
            if (this.TryFindAll(treeScope, condition, timeOut, out var result))
            {
                return result;
            }

            throw new InvalidOperationException($"Did not find an element matching {condition}.");
        }

        /// <summary>
        /// Finds all elements in the given treescope and with the given condition within the given timeout.
        /// </summary>
        public bool TryFindAll(TreeScope treeScope, ConditionBase condition, TimeSpan timeOut, out IReadOnlyList<UiElement> result)
        {
            return this.TryFindAll(treeScope, condition, x => new UiElement(x), timeOut, out result);
        }

        /// <summary>
        /// Finds all elements in the given treescope and with the given condition within the given timeout.
        /// </summary>
        public bool TryFindAll<T>(TreeScope treeScope, ConditionBase condition, Func<AutomationElement, T> wrap, TimeSpan timeOut, out IReadOnlyList<T> result)
            where T : UiElement
        {
            result = null;
            var start = DateTime.Now;
            while (!Retry.IsTimeouted(start, timeOut))
            {
                result = this.AutomationElement.FindAll(treeScope, condition, wrap);
                if (result != null &&
                    result.Count > 0)
                {
                    return true;
                }

                Wait.For(Retry.PollInterval);
            }

            return result != null;
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition.
        /// </summary>
        public UiElement FindFirst(TreeScope treeScope, ConditionBase condition)
        {
            return this.FindFirst(treeScope, condition, Retry.Time);
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition.
        /// </summary>
        public T FindFirst<T>(TreeScope treeScope, ConditionBase condition, Func<AutomationElement, T> wrap)
            where T : UiElement
        {
            return this.FindFirst(treeScope, condition, wrap, Retry.Time);
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition within the given timeout period.
        /// </summary>
        public UiElement FindFirst(TreeScope treeScope, ConditionBase condition, TimeSpan timeOut)
        {
            if (this.TryFindFirst(treeScope, condition, timeOut, out var result))
            {
                return result;
            }

            throw new InvalidOperationException($"Did not find an element matching {condition}.");
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition within the given timeout period.
        /// </summary>
        public bool TryFindFirst(TreeScope treeScope, ConditionBase condition, TimeSpan timeOut, out UiElement result)
        {
            result = null;
            var start = DateTime.Now;
            while (!Retry.IsTimeouted(start, timeOut))
            {
                result = this.AutomationElement.FindFirst(treeScope, condition, x => new UiElement(x));
                if (result != null)
                {
                    return true;
                }

                Wait.For(Retry.PollInterval);
            }

            return result != null;
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition within the given timeout period.
        /// </summary>
        public T FindFirst<T>(TreeScope treeScope, ConditionBase condition, Func<AutomationElement, T> wrap, TimeSpan timeOut)
            where T : UiElement
        {
            if (this.TryFindFirst(treeScope, condition, wrap, timeOut, out var result))
            {
                return result;
            }

            throw new InvalidOperationException($"Did not find a {typeof(T).Name} matching {condition}.");
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition within the given timeout period.
        /// </summary>
        public bool TryFindFirst<T>(TreeScope treeScope, ConditionBase condition, Func<AutomationElement, T> wrap, TimeSpan timeOut, out T result)
            where T : UiElement
        {
            result = null;
            var start = DateTime.Now;
            do
            {
                if (this.AutomationElement.TryFindFirst(treeScope, condition, out var element))
                {
                    result = wrap(element);
                    return true;
                }

                Wait.For(Retry.PollInterval);
            }
            while (!Retry.IsTimeouted(start, timeOut));

            return result != null;
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition within the given timeout period.
        /// </summary>
        public UiElement FindAt(TreeScope treeScope, ConditionBase condition, int index, TimeSpan timeOut)
        {
            if (this.TryFindAt(treeScope, condition, index, timeOut, out var result))
            {
                return result;
            }

            throw new InvalidOperationException($"Did not find an element matching {condition} at index {index}.");
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition within the given timeout period.
        /// </summary>
        public bool TryFindAt(TreeScope treeScope, ConditionBase condition, int index, TimeSpan timeOut, out UiElement result)
        {
            result = null;
            var start = DateTime.Now;
            while (!Retry.IsTimeouted(start, timeOut))
            {
                result = this.AutomationElement.FindIndexed(treeScope, condition, index, x => new UiElement(x));
                if (result != null)
                {
                    return true;
                }

                Wait.For(Retry.PollInterval);
            }

            return result != null;
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition within the given timeout period.
        /// </summary>
        public T FindAt<T>(TreeScope treeScope, ConditionBase condition, int index, Func<AutomationElement, T> wrap, TimeSpan timeOut)
            where T : UiElement
        {
            if (this.TryFindAt(treeScope, condition, index, wrap, timeOut, out var result))
            {
                return result;
            }

            throw new InvalidOperationException($"Did not find an element matching {condition} at index {index}.");
        }

        /// <summary>
        /// Finds the first element which is in the given treescope with the given condition within the given timeout period.
        /// </summary>
        public bool TryFindAt<T>(TreeScope treeScope, ConditionBase condition, int index, Func<AutomationElement, T> wrap, TimeSpan timeOut, out T result)
            where T : UiElement
        {
            result = null;
            var start = DateTime.Now;
            while (!Retry.IsTimeouted(start, timeOut))
            {
                result = this.AutomationElement.FindIndexed(treeScope, condition, index, wrap);
                if (result != null)
                {
                    return true;
                }

                Wait.For(Retry.PollInterval);
            }

            return result != null;
        }

        public UiElement FindFirstChild()
        {
            return this.FindFirst(TreeScope.Children, TrueCondition.Default, Retry.Time);
        }

        public T FindFirstChild<T>(Func<AutomationElement, T> wrap)
            where T : UiElement
        {
            return this.FindFirst(TreeScope.Children, TrueCondition.Default, wrap, Retry.Time);
        }

        public UiElement FindChildAt(int index)
        {
            return this.FindAt(TreeScope.Children, TrueCondition.Default, index, Retry.Time);
        }

        public UiElement FindFirstChild(string automationId)
        {
            return this.FindFirst(TreeScope.Children, this.ConditionFactory.ByAutomationId(automationId));
        }

        public UiElement FindFirstChild(ConditionBase condition)
        {
            return this.FindFirst(TreeScope.Children, condition);
        }

        public UiElement FindFirstChild(Func<ConditionFactory, ConditionBase> newConditionFunc)
        {
            var condition = newConditionFunc(this.ConditionFactory);
            return this.FindFirstChild(condition);
        }

        public IReadOnlyList<UiElement> FindAllChildren()
        {
            return this.FindAll(TreeScope.Children, TrueCondition.Default);
        }

        public IReadOnlyList<T> FindAllChildren<T>(Func<AutomationElement, T> wrap)
            where T : UiElement
        {
            return this.AutomationElement.FindAll(TreeScope.Children, TrueCondition.Default, wrap);
        }

        public IReadOnlyList<UiElement> FindAllChildren(ConditionBase condition)
        {
            return this.AutomationElement.FindAll(TreeScope.Children, condition, x => new UiElement(x));
        }

        public IReadOnlyList<T> FindAllChildren<T>(ConditionBase condition, Func<AutomationElement, T> wrap)
            where T : UiElement
        {
            return this.AutomationElement.FindAll(TreeScope.Children, condition, wrap);
        }

        public IReadOnlyList<UiElement> FindAllChildren(Func<ConditionFactory, ConditionBase> newConditionFunc)
        {
            var condition = newConditionFunc(this.ConditionFactory);
            return this.AutomationElement.FindAll(TreeScope.Children, condition, x => new UiElement(x));
        }

        public IReadOnlyList<T> FindAllChildren<T>(Func<ConditionFactory, ConditionBase> newConditionFunc, Func<AutomationElement, T> wrap)
            where T : UiElement
        {
            var condition = newConditionFunc(this.ConditionFactory);
            return this.FindAllChildren(condition, wrap);
        }

        public UiElement FindFirstDescendant()
        {
            return this.FindFirst(TreeScope.Descendants, TrueCondition.Default);
        }

        public T FindFirstDescendant<T>(Func<AutomationElement, T> wrap)
            where T : UiElement
        {
            return this.FindFirst(TreeScope.Descendants, TrueCondition.Default, wrap);
        }

        public UiElement FindFirstDescendant(string automationId)
        {
            return this.FindFirst(TreeScope.Descendants, this.ConditionFactory.ByAutomationId(automationId));
        }

        public T FindFirstDescendant<T>(string automationId, Func<AutomationElement, T> wrap)
            where T : UiElement
        {
            return this.FindFirst(TreeScope.Descendants, this.ConditionFactory.ByAutomationId(automationId), wrap);
        }

        public UiElement FindFirstDescendant(ControlType controlType)
        {
            return this.FindFirst(TreeScope.Descendants, this.ConditionFactory.ByControlType(controlType));
        }

        public T FindFirstDescendant<T>(ControlType controlType, Func<AutomationElement, T> wrap)
            where T : UiElement
        {
            return this.FindFirst(TreeScope.Descendants, this.ConditionFactory.ByControlType(controlType), wrap);
        }

        public UiElement FindFirstDescendant(ConditionBase condition)
        {
            return this.FindFirst(TreeScope.Descendants, condition);
        }

        public UiElement FindFirstDescendant(Func<ConditionFactory, ConditionBase> newConditionFunc)
        {
            var condition = newConditionFunc(this.ConditionFactory);
            return this.FindFirstDescendant(condition);
        }

        public IReadOnlyList<UiElement> FindAllDescendants()
        {
            return this.FindAll(TreeScope.Descendants, TrueCondition.Default);
        }

        public IReadOnlyList<UiElement> FindAllDescendants(ConditionBase condition)
        {
            return this.FindAll(TreeScope.Descendants, condition);
        }

        public IReadOnlyList<UiElement> FindAllDescendants(Func<ConditionFactory, ConditionBase> newConditionFunc)
        {
            var condition = newConditionFunc(this.ConditionFactory);
            return this.FindAllDescendants(condition);
        }

        public UiElement FindFirstNested(Func<ConditionFactory, IList<ConditionBase>> nestedConditionsFunc)
        {
            var conditions = nestedConditionsFunc(this.ConditionFactory);
            return this.FindFirstNested(conditions.ToArray());
        }

        public IReadOnlyList<UiElement> FindAllNested(Func<ConditionFactory, IList<ConditionBase>> nestedConditionsFunc)
        {
            var conditions = nestedConditionsFunc(this.ConditionFactory);
            return this.FindAllNested(conditions.ToArray());
        }

        /// <summary>
        /// Finds the first element by looping thru all conditions.
        /// </summary>
        public UiElement FindFirstNested(params ConditionBase[] nestedConditions)
        {
            var currentElement = this;
            foreach (var condition in nestedConditions)
            {
                currentElement = currentElement.FindFirstChild(condition);
                if (currentElement == null)
                {
                    return null;
                }
            }

            return currentElement;
        }

        /// <summary>
        /// Finds all elements by looping thru all conditions.
        /// </summary>
        public IReadOnlyList<UiElement> FindAllNested(params ConditionBase[] nestedConditions)
        {
            var currentElement = this;
            for (var i = 0; i < nestedConditions.Length - 1; i++)
            {
                var condition = nestedConditions[i];
                currentElement = currentElement.FindFirstChild(condition);
                if (currentElement == null)
                {
                    return null;
                }
            }

            return currentElement.FindAllChildren(nestedConditions.Last());
        }

        /// <summary>
        /// Finds for the first item which matches the given xpath.
        /// </summary>
        public UiElement FindFirstByXPath(string xPath)
        {
            var xPathNavigator = new AutomationElementXPathNavigator(this);
            var nodeItem = xPathNavigator.SelectSingleNode(xPath);
            return (UiElement)nodeItem?.UnderlyingObject;
        }

        /// <summary>
        /// Finds all items which match the given xpath.
        /// </summary>
        public IReadOnlyList<UiElement> FindAllByXPath(string xPath)
        {
            var xPathNavigator = new AutomationElementXPathNavigator(this);
            var itemNodeIterator = xPathNavigator.Select(xPath);
            var itemList = new List<UiElement>();
            while (itemNodeIterator.MoveNext())
            {
                var automationItem = (UiElement)itemNodeIterator.Current.UnderlyingObject;
                itemList.Add(automationItem);
            }

            return itemList.ToArray();
        }

        public ConditionBase CreateCondition(ControlType controlType, string name)
        {
            if (name == null)
            {
                return this.CreateCondition(controlType);
            }

            return new AndCondition(
                this.CreateCondition(controlType),
                this.CreateNameOrIdCondition(name));
        }

        public PropertyCondition CreateCondition(ControlType controlType)
        {
            return this.ConditionFactory.ByControlType(controlType);
        }

        public OrCondition CreateNameOrIdCondition(string key)
        {
            return new OrCondition(
                this.ConditionFactory.ByName(key),
                this.ConditionFactory.ByAutomationId(key));
        }
    }
}