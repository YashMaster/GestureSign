﻿using System;
using GestureSign.Common.Plugins;
using WindowsInput;
using WindowsInput.Native;
using GestureSign.Common.Localization;
using System.Windows.Forms;

namespace GestureSign.CorePlugins
{
    public class NextApplication : IPlugin
    {
        #region Private Variables

        IHostControl _HostControl = null;

        #endregion

        #region IAction Properties

        public string Name
        {
            get { return LocalizationProvider.Instance.GetTextValue("CorePlugins.NextApplication.Name"); }
        }

        public string Description
        {
            get { return LocalizationProvider.Instance.GetTextValue("CorePlugins.NextApplication.Description"); }
        }

        public object GUI
        {
            get { return null; }
        }

        public bool ActivateWindowDefault
        {
            get { return false; }
        }

        public string Category
        {
            get { return "Windows"; }
        }

        public bool IsAction
        {
            get { return true; }
        }

        public object Icon => IconSource.Window;

        #endregion

        #region IAction Methods

        public void Initialize()
        {

        }

        public bool Gestured(PointInfo ActionPoint)
        {
            InputSimulator simulator = new InputSimulator();
            try
            {
                simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LMENU, VirtualKeyCode.TAB);
            }
            catch (Exception)
            {
                if (!KeyboardHelper.ResendByKeybdEvent(new Keys[] { Keys.LMenu }, new Keys[] { Keys.Tab }))
                {
                    KeyboardHelper.ResetKeyState(ActionPoint.Window, Keys.LMenu);
                }
                return false;
            }

            return true;
        }

        public bool Deserialize(string SerializedData)
        {
            return true;
            // Nothing to deserialize
        }

        public string Serialize()
        {
            // Nothing to serialize, send empty string
            return "";
        }

        public void ShowGUI(bool IsNew)
        {
            // Nothing to do here
        }

        #endregion

        #region Host Control

        public IHostControl HostControl
        {
            get { return _HostControl; }
            set { _HostControl = value; }
        }

        #endregion
    }
}