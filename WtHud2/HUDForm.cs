using System.Windows.Forms;

namespace WtHud2
{
    public partial class HUDForm : Form
    {
        public HUDForm()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT

                return createParams;
            }
        }

        private void HUDForm_Load(object sender, System.EventArgs e)
        {
            // byte asymetrical grey color, that 99% not selectable even in advanced color dialog
            // Allows GUI label to work with standart "dark gray" color

            BackColor = System.Drawing.Color.FromArgb(0x61, 0x60, 0x62);
            TransparencyKey = System.Drawing.Color.FromArgb(0x61, 0x60, 0x62);
        }
    }
}
