using Amazon;
using Amazon.CloudWatchLogs.Model;
using ReadCloudWatch.Describers;
using ReadCloudWatch.Scope;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCloudWatch.Forms
{
    public partial class Main : Form
    {
        #region Private Methods

        private async Task DescribeEvents(GetLogEventsRequest eventsRequest)
        {
            var events = await new LogEventDescriber(eventsRequest).GetItemsAsync();

            if(!events.Any())
            {
                rtbMain.Text += $"{eventsRequest.EndTime}{Environment.NewLine}{eventsRequest.LogStreamName}";
                return;
            }

            foreach(var evt in events)
            {
                rtbMain.Text += $"{evt.Timestamp}{Environment.NewLine}{evt.Message}";
            }
        }

        private async Task DescribeGroups(TreeNode node)
        {
            try
            {
                await new LogGroupDescriber().FillNodeAsync(node);
            }
            catch(Exception? ex)
            {
                do
                {
                    rtbMain.Text += $"Message: {ex.Message}{Environment.NewLine}";
                    ex = ex.InnerException;
                } while(ex != null);
            }
        }

        private RegionEndpoint GetCurrentRegion()
        {
            var nd = tvMain.SelectedNode;

            do
            {
                if(nd?.Tag is RegionEndpoint region)
                {
                    return region;
                }

                nd = nd?.Parent;
            } while(nd?.Tag != null);

            return default;
        }

        private async void Main_Shown(object sender, EventArgs e) =>
            await new RegionDescriber().FillNodeAsync(tvMain.Nodes[0]);

        private async void TvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                rtbMain.Clear();

                var nd = e.Node;

                if(nd.Tag == null)
                {
                    return;
                }

                using(new AWSClientScope(GetCurrentRegion()))
                {
                    if(nd.Tag is RegionEndpoint region)
                    {
                        await DescribeGroups(nd);
                        return;
                    }

                    if(nd.Tag is LogGroup logGroup)
                    {
                        await new LogStreamDescriber(logGroup).FillNodeAsync(nd);
                        return;
                    }

                    if(nd.Tag is GetLogEventsRequest logEventsRequest)
                    {
                        await DescribeEvents(logEventsRequest);
                        return;
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion Private Methods

        #region Public Constructors

        public Main() => InitializeComponent();

        #endregion Public Constructors
    }
}