using Candidate_BussinessObjects;
using Candidate_DAO;
using Candidate_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CandidateManagment_WPF_TUE_Slot1
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private ICandidateProfileService _candidate;
        private IJobPosTingService jobPosTing;
        public CandidateProfileWindow()
        {
            InitializeComponent();
            _candidate = new CandidatePRofileService();
            jobPosTing = new JobPosTingService();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAccount();
        }
        private void LoadAccount()
        {
            this.dtgCandidateProfile.ItemsSource = _candidate.GetCandidateProfiles();

            this.cmbPostID.ItemsSource = jobPosTing.GetJobPostings();
            this.cmbPostID.DisplayMemberPath = "JobPostingTitle";
            this.cmbPostID.SelectedValuePath = "PostingId";

            txtCandidateId.Text = "";
            txtBirthday.Text = "";
            txtDescription.Text = "";
            txtImageURL.Text = "";
            txtFullname.Text = "";
            cmbPostID.SelectedValue = "";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidate = new CandidateProfile();
            candidate.CandidateId = txtCandidateId.Text;
            candidate.Fullname = txtFullname.Text;
            candidate.Birthday = DateTime.Parse(txtBirthday.Text);
            candidate.ProfileUrl = txtImageURL.Text;
            candidate.PostingId =  cmbPostID.SelectedValue.ToString();
            candidate.ProfileShortDescription = txtDescription.Text;

            if (_candidate.AddCandidateProfile(candidate))
            {
                MessageBox.Show("Add successfully");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("NGU!!!");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;

            DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex) as DataGridRow;
            if (row != null)
            {
                DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)RowColumn.Content).Text;
                CandidateProfile Profile = _candidate.GetCandidateProfileByID(id);
                if (Profile != null)
                {
                    txtCandidateId.Text = Profile.CandidateId;
                    txtBirthday.Text = Profile.Birthday.ToString();
                    txtDescription.Text = Profile.ProfileShortDescription;
                    txtImageURL.Text = Profile.ProfileUrl;
                    txtFullname.Text = Profile.Fullname;
                    cmbPostID.SelectedValue = Profile.PostingId;
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string candidateID = txtCandidateId.Text;
            if (candidateID.Length > 0 && _candidate.DeleteCandidateProfile(candidateID)) {
                MessageBox.Show("Delete success!!");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Something Wrong !");
            }
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidate = new CandidateProfile();
            candidate.CandidateId = txtCandidateId.Text;
            candidate.Fullname = txtFullname.Text;
            candidate.Birthday = DateTime.Parse(txtBirthday.Text);
            candidate.ProfileUrl = txtImageURL.Text;
            if (cmbPostID.SelectedItem is JobPosting selected)
            {
                candidate.PostingId = selected.PostingId;
            }

           
            candidate.ProfileShortDescription = txtDescription.Text;
            if (_candidate.UpdateCandidateProfile(candidate))
            {
                MessageBox.Show("Update successfully");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("NGU!!!");
            }
        }


    }
}
