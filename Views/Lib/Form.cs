using System;
using System.Windows.Forms;
using System.Drawing;

namespace Views.Lib
{
    public delegate void HandleButton(object sender, EventArgs e);
    
    public class LabelField : Label
    {

        public LabelField(string Text, int X, int Y)
        {
            this.Text = Text;
            this.Location = new Point(X, Y);
        }

    }

    public class TextBoxField : TextBox 
    {

        public TextBoxField(int X, int Y, int Height, int Width)
        {
            this.Location = new Point(X, Y);
            this.Size = new Size(Height, Width);
            this.ForeColor = System.Drawing.Color.Purple;
        }
    }

    public class TextBoxPass : TextBoxField
    {
        public TextBoxPass(int X, int Y, int Height, int Width)
            : base(X, Y, Height, Width)
        {
            this.PasswordChar = '*';
        }
    }

    public class Field
    {
        public LabelField label;
        public TextBoxField textField;

        public Field(
            Control.ControlCollection Ref,
            string Text,
            int Y,
            bool isCenterTitle = false,
            bool isPass = false
        )
        {
            const int _MarginLabel = 35;
            const int _Height = 280;
            const int _Width = 30;

            this.label = new LabelField(Text, isCenterTitle ? 120 : 10, Y);
            if (!isPass)
            {
                this.textField = new TextBoxField(10, Y + _MarginLabel, _Height, _Width);
            }
            else
            {
                this.textField = new TextBoxPass(10, Y + _MarginLabel, _Height, _Width);
            }

            Ref.Add(label);
            Ref.Add(textField);
        }
    }

    public class ButtonForm : Button
    {
        public ButtonForm(
            Control.ControlCollection Ref,
            string Text,
            int X, 
            int Y,
            HandleButton handleAction 
        )
        {
            this.Text = Text;
            this.Location = new Point(X, Y);
            this.Size = new Size(80, 30);
            this.Click += new EventHandler(handleAction);
            Ref.Add(this);
        }
    }

    public class BaseForm : Form
    {
        public BaseForm(string Title)
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Title;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}