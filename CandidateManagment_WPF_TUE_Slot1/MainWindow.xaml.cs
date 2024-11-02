using Microsoft.VisualBasic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Candidate_Service;
using Candidate_BussinessObjects;
namespace CandidateManagment_WPF_TUE_Slot1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHRAccountService HRAccountService;
        
        public MainWindow()
        {
            InitializeComponent();


            HRAccountService = new HRAccountService();


        }

        private void btnButton_Click(object sender, RoutedEventArgs e)
        {
            Hraccount email = HRAccountService.GetHraccountByEmail(txtEmail.Text);
            if (email != null && txtPassword.Text.Equals(email.Password) )
            {
                CandidateProfileWindow profileWindow = new CandidateProfileWindow();
                profileWindow.Show();
            }
            else
            {
                MessageBox.Show("NO DATA");
            }
        }

        private void btnCN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
     
    }
}