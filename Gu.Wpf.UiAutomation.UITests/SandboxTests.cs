﻿namespace Gu.Wpf.UiAutomation.UiTests
{
    using System;
    using System.Linq;
    using System.Windows.Automation;
    using NUnit.Framework;

    [Explicit("Script")]
    public class SandboxTests
    {
        private const string ExeFileName = "WpfApplication.exe";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(ExeFileName);
        }

        [Test]
        public void DumpTabControl()
        {
            using (var app = Application.Launch(ExeFileName, "TabControlWindow"))
            {
                var window = app.MainWindow;
                var element = window.FindTabControl().AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpTabItem()
        {
            using (var app = Application.Launch(ExeFileName, "TabControlWindow"))
            {
                var window = app.MainWindow;
                var element = window.FindTabControl().Items[0].AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpGroupBox()
        {
            using (var app = Application.Launch(ExeFileName, "GroupBoxWindow"))
            {
                var window = app.MainWindow;
                var element = window.FindGroupBox().AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpExpander()
        {
            using (var app = Application.Launch(ExeFileName, "ExpanderWindow"))
            {
                var window = app.MainWindow;
                var element = window.FindExpander().AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpWindow()
        {
            using (var app = Application.Launch(ExeFileName, "EmptyWindow"))
            {
                var window = app.MainWindow;
                var element = window.AutomationElement;
                DumpRecursive(element);
            }
        }

        [Test]
        public void DumpDataGrid()
        {
            using (var app = Application.Launch(ExeFileName, "DataGridWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindDataGrid().AutomationElement);
            }
        }

        [Test]
        public void DumpDataGridItem()
        {
            using (var app = Application.Launch(ExeFileName, "DataGridWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindDataGrid()[0, 0].AutomationElement);
            }
        }

        [Test]
        public void DumpListBox()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "ListBoxWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindListBox().AutomationElement);
            }
        }

        [Test]
        public void DumpListView()
        {
            using (var app = Application.AttachOrLaunch(ExeFileName, "ListViewWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.FindListView().AutomationElement);
            }
        }

        [Test]
        public void DumpMessageBox()
        {
            using (var app = Application.Launch(ExeFileName, "DialogWindow"))
            {
                var window = app.MainWindow;
                window.FindButton("Show MessageBox OKCancel").Click();
                var messageBox = window.FindMessageBox();
                var element = messageBox.AutomationElement;
                DumpRecursive(element);
                messageBox.Close();
            }
        }

        [Test]
        public void DumpScrollBarWindow()
        {
            using (var app = Application.Launch(ExeFileName, "ScrollBarWindow"))
            {
                var window = app.MainWindow;
                DumpRecursive(window.AutomationElement);
            }
        }

        private static void DumpRecursive(AutomationElement element, bool all = false, string padding = "")
        {
            DumpPropertiesAndPatterns(element, all, padding);
            foreach (var child in element.Children())
            {
                DumpRecursive(child, all, padding + "  ");
                Console.WriteLine();
            }
        }

        private static void DumpPropertiesAndPatterns(AutomationElement element, bool all = true, string padding = "")
        {
            var info = element.Current;
            Console.WriteLine($"{padding}ControlType: {info.ControlType.ProgrammaticName}");
            Console.WriteLine($"{padding}LocalizedControlType: {info.LocalizedControlType}");
            Console.WriteLine($"{padding}ClassName: {info.ClassName}");
            Console.WriteLine($"{padding}Name: {info.Name}");
            Console.WriteLine($"{padding}AutomationId: {info.AutomationId}");
            Console.WriteLine($"{padding}IsContentElement: {info.IsContentElement}");
            Console.WriteLine($"{padding}IsControlElement: {info.IsControlElement}");

            if (all)
            {
                foreach (var pattern in element.GetSupportedPatterns())
                {
                    Console.WriteLine($"{padding}{pattern.ProgrammaticName}");
                    var currentPattern = element.GetCurrentPattern(pattern);
                    Console.WriteLine($"{padding}{currentPattern}");
                    var currentProperty = currentPattern.GetType().GetProperty("Current");
                    if (currentProperty != null)
                    {
                        var value = currentProperty.GetValue(currentPattern);
                        foreach (var property in value.GetType().GetProperties())
                        {
                            Console.WriteLine($"{padding}{property.Name} {property.GetValue(value)}");
                        }
                    }

                    Console.WriteLine();
                }

                foreach (var property in element.GetSupportedProperties().OrderBy(x => x.ProgrammaticName))
                {
                    Console.WriteLine($"{padding}{property.ProgrammaticName.TrimStart("AutomationElementIdentifiers.").TrimEnd("Property")} {element.GetCurrentPropertyValue(property)}");
                }
            }
        }
    }
}
