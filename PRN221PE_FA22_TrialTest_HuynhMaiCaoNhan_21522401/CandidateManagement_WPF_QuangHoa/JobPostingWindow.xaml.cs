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

namespace CandidateManagement_WPF_X
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private IJobPostingService jobPostingService;
        public JobPostingWindow()
        {
            InitializeComponent();
            jobPostingService = new JobPostingService();
            
        }

        

        private void dtg_JobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.dtg_JobPosting.ItemsSource = jobPostingService.getJobPostingsList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.dtg_JobPosting.ItemsSource = jobPostingService.getJobPostingsList();
        }
    }
}
