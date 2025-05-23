using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaydayFranchiseRandomHeistSelecter
{
    public partial class FileNameSaver : Form
    {
        private TextBox inputBox;
        private Button okButton;
        private Button cancelButton;

        public string InputText => inputBox.Text;

        public FileNameSaver(string prompt)
        {
            this.Text = "Input Dialog";
            this.Width = 300;
            this.Height = 150;

            Label label = new Label() { Left = 10, Top = 10, Text = prompt, AutoSize = true };
            inputBox = new TextBox() { Left = 10, Top = 35, Width = 260 };

            okButton = new Button() { Text = "OK", Left = 115, Width = 75, Top = 70, DialogResult = DialogResult.OK };
            cancelButton = new Button() { Text = "Cancel", Left = 195, Width = 75, Top = 70, DialogResult = DialogResult.Cancel };

            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;

            this.Controls.Add(label);
            this.Controls.Add(inputBox);
            this.Controls.Add(okButton);
            this.Controls.Add(cancelButton);
        }
    }
}
