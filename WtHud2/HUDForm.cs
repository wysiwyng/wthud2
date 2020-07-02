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
    }
}
