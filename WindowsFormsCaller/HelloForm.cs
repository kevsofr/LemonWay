using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCaller.LemonWayReference;

namespace WindowsFormsCaller
{
    public partial class HelloForm : Form
    {

        private LemonWayWSSoapClient ws = new LemonWayWSSoapClient();
        private WaitingForm waitingForm = new WaitingForm();
        private string msgInProgress = "Fibonacci {0} in progress, please wait.";
        TaskScheduler formScheduler;

        public HelloForm()
        {
            InitializeComponent();
        }

        private void HelloForm_Load(object sender, EventArgs e)
        {
            formScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        private void btnFibo_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            DoFibonacci(10, (msg) => ShowBusyForm(msg));
        }

        private void DoFibonacci(int i, Action<string> updateForm)
        {
            Task<string>.Factory.StartNew(() =>
            {
                updateForm(String.Format(msgInProgress, i));
                return StartFibonacci(i);
            }).ContinueWith((t) => { EndFibonacci(t.Result); }, CancellationToken.None, TaskContinuationOptions.None, formScheduler);
        }

        private void ShowBusyForm(string msg)
        {
            Task.Factory.StartNew(() =>
            {
                btnFibo.Enabled = false;
                waitingForm.ShowDialog(msg);
            }, CancellationToken.None, TaskCreationOptions.None, formScheduler);
        }
        
        private string StartFibonacci(int i)
        {
            return ws.Fibonacci(i, true);
        }

        private void EndFibonacci(string res)
        {           
            waitingForm.Close();
            lblResult.Text = res;
            btnFibo.Enabled = true;
        }
    }
}
