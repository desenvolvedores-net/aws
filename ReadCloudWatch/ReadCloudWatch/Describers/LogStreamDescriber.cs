using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;
using ReadCloudWatch.Describers.Contract;
using ReadCloudWatch.Scope;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCloudWatch.Describers
{
    internal class LogStreamDescriber : IDescriber<LogStream>
    {
        #region Public Properties

        public LogGroup LogGroup { get; }

        #endregion Public Properties

        #region Public Constructors

        public LogStreamDescriber(LogGroup logGroup) => LogGroup = logGroup;

        #endregion Public Constructors

        #region Public Methods

        public async Task FillNodeAsync(TreeNode node)
        {
            var describeLogStreamsRequest = new DescribeLogStreamsRequest()
            {
                LogGroupName = LogGroup.LogGroupName,
                Descending = true,
                OrderBy = OrderBy.LastEventTime
            };

            var describeLogStreams = (await AWSClientScope.Instance.Client.DescribeLogStreamsAsync(describeLogStreamsRequest)).LogStreams.OrderByDescending(o => o.LogStreamName);

            foreach(var stream in describeLogStreams)
            {
                var eventsRequest = new GetLogEventsRequest()
                {
                    LogStreamName = stream.LogStreamName,
                    LogGroupName = describeLogStreamsRequest.LogGroupName
                };

                var nodeEventRequest = new TreeNode(stream.LogStreamName)
                {
                    Tag = eventsRequest
                };

                node.Nodes.Add(nodeEventRequest);
            }

            node.Expand();
        }

        public async Task<IEnumerable<LogStream>> GetItemsAsync()
        {
            var describeLogStreamsRequest = new DescribeLogStreamsRequest()
            {
                LogGroupName = LogGroup.LogGroupName,
                Descending = true,
                OrderBy = OrderBy.LastEventTime
            };

            return (await AWSClientScope.Instance.Client.DescribeLogStreamsAsync(describeLogStreamsRequest)).LogStreams.OrderByDescending(o => o.LogStreamName);
        }

        #endregion Public Methods
    }
}