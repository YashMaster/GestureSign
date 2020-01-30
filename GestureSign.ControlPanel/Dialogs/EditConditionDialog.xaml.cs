﻿using System.Windows;
using MahApps.Metro.Controls;

namespace GestureSign.ControlPanel.Dialogs
{
    /// <summary>
    /// Interaction logic for EditConditionDialog.xaml
    /// </summary>
    public partial class EditConditionDialog : MetroWindow
    {
        public EditConditionDialog(string condition)
        {
            DataContext = condition;

            InitializeComponent();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            string variable = $"finger_{FingerIDComboBox.Text}_{VariableComboBox.Text}";
            int caretIndex = ConditionTextBox.CaretIndex;
            ConditionTextBox.Text = ConditionTextBox.Text.Insert(caretIndex, variable);
            ConditionTextBox.CaretIndex = caretIndex + variable.Length;

            ConditionTextBox.Focus();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ConditionTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            ConditionTextBox.Text = DataContext as string;
            ConditionTextBox.Focus();
        }

        private void VariableComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            VariableComboBox.Items.Add("start_X");
            VariableComboBox.Items.Add("start_X%");
            VariableComboBox.Items.Add("start_Y");
            VariableComboBox.Items.Add("start_Y%");
            VariableComboBox.Items.Add("end_X");
            VariableComboBox.Items.Add("end_X%");
            VariableComboBox.Items.Add("end_Y");
            VariableComboBox.Items.Add("end_Y%");
            VariableComboBox.Items.Add("ID");

            VariableComboBox.SelectedIndex = 0;
        }

        private void FingerIDComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                FingerIDComboBox.Items.Add(i);
            }
            FingerIDComboBox.SelectedIndex = 0;
        }
    }
}
