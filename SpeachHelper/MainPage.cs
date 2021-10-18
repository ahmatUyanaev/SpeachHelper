using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Microsoft.Speech.Recognition;

using SpeachHelper.Locator;
using SpeachHelper.SpeachRecognition;

namespace SpeachHelper
{
    public partial class MainPage : Form
    {
        private bool m_aeroEnabled = true;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);

                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };

                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
        }
    



        public static Bitmap BM = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        private SpeachRecognizer recognizer;

        public MainPage()
        {
            InitializeComponent();


            recognizer = ServiceLocator.GetService<SpeachRecognizer>();

            
            recognizer.RecognizeAsync();

            
        }

        private void addCommandBtnClick(object sender, System.EventArgs e)
        {
            var grammarConteiner = ServiceLocator.GetService<EdgeWordActionContainer>();
            grammarConteiner.AddBrowserWebSiteAction(wordsTextBox.Text, actionTextBox.Text);
            var updatedGrammer = new GrammarBuilder(new Choices(grammarConteiner.GetActions().Keys.ToArray()));
            recognizer.LoadGrammar(updatedGrammer);
        }

        private void MainPage_Load(object sender, System.EventArgs e)
        {

        }

       
    }
}
